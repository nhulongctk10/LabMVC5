using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using CheapShop.Core.DataAnnotations;
using CheapShop.DAL;
using CheapShop.Models;

namespace CheapShop.Areas.Admin.Controllers
{
    public class CategoryController : AdminController
    {
        private ShopDbContext db = new ShopDbContext();

        // GET: Admin/Category
        public ActionResult Index()
        {
            var categories = db.Categories.Include(c => c.Parent).OrderBy(x => x.ParentId).ThenBy(x => x.OrderNo).ToList();

            return View(SortKhongDeQuy(categories));
        }

        private void Order(List<Category> listCates, IEnumerable<Category> parentList, Category parent)
        {
            listCates.Add(parent);
            foreach (var item in parentList.ToList().FindAll(x => x.ParentId == parent.CategoryId))
            {
                Order(listCates, parentList, item);
            }
        }

        private List<Category> Sort(IEnumerable<Category> models)
        {
            var result = new List<Category>();
            var listNull = models.ToList().Where(x => x.ParentId == null);
            foreach (var item in listNull)
            {
                Order(result, models, item);
            }
            return result;
        }

        private List<Category> SortKhongDeQuy(List<Category> models)
        {
            var rs = new List<Category>();
            foreach (var item in models)
            {
                if (!rs.Exists(x => x.CategoryId == item.ParentId))
                    rs.Add(item);
                else
                {
                    rs.Insert(rs.FindLastIndex(x => x.CategoryId == item.ParentId || x.ParentId == item.ParentId) + 1, item);
                }
            }

            return rs;
        }

        [HttpPost]
        public JsonResult UpdateOrderNo(int cid,  string method)
        {
            StringBuilder query = new StringBuilder();
            var success = true;
            var cate1 = db.Categories.Find(cid);
            int currOrder = cate1.OrderNo;
            Category cate2 = null;

            if (method.ToLower().Equals("down"))
            {
                //query.AppendFormat("UPDATE dbo.Categories SET OrderNo = {0} WHERE CategoryId = {1} and OrderNo = {2}", currOrder + 1, cid, currOrder);
               
                cate2 = db.Categories.SingleOrDefault(x => x.ParentId == cate1.ParentId && x.OrderNo == (currOrder + 1));
                cate1.OrderNo = currOrder + 1;
            }
            else
            {
                //query.AppendFormat("UPDATE dbo.Categories SET OrderNo = {0} WHERE CategoryId = {1} and OrderNo = {2}", currOrder - 1, cid, currOrder);
                
                cate2 = db.Categories.SingleOrDefault(x => x.ParentId == cate1.ParentId && x.OrderNo == (currOrder - 1));
                cate1.OrderNo = currOrder - 1;
            }

            try
            {
                //var rs = db.Database.ExecuteSqlCommand(query.ToString())>0;
                if (cate2 != null)
                {
                    db.Entry(cate1).State = EntityState.Modified;
                    db.SaveChanges();

                    cate2.OrderNo = currOrder;
                    db.Entry(cate2).State = EntityState.Modified;
                    return Json(db.SaveChanges()>0);
                }
            }
            catch (Exception)
            {
                success = false;
            }
            return Json(success);
        }

        public ActionResult List()
        {
            var categories = PopulateCategories();
            return View(categories);
        }

        public ActionResult Create()
        {
            var emptyCate = new Category();
            InitFormData(emptyCate);
            return View(emptyCate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[FileType("jpg,jpeg,png,gif")]
        //[FileSize(1024*1024)]
        public ActionResult Create(HttpPostedFileBase upload, [Bind(Include = "Name,Alias,Description,Actived,ParentId,OrderNo")] Category category)
        {
            //Kiem tra hinh duoc upload co hop le?
            ValidateUploadImage(upload);

            if (db.Categories.SingleOrDefault(x => x.Alias == category.Alias) != null)
                ModelState.AddModelError("Alias", "Alias này đã tồn tại trong CSDL");
            if (ModelState.IsValid)
            {
                //Lưu hình được upload lên Server
                saveUploadFile(upload, category);

                //Thêm nhóm mặt hàng vào CSDL
                db.Categories.Add(category);
                db.SaveChanges();

                return new RedirectResult("Index");
            }
            InitFormData(category);
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Category category = db.Categories.Find(id);
            if (category == null)
                return HttpNotFound();

            InitFormData(category);
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [FileType("jpg,jpeg,png,gif")]
        [FileSize(1024 * 1024)]
        public ActionResult Edit(HttpPostedFileBase upload, [Bind(Include = "CategoryId, Name,Alias,Description,Actived,ParentId,OrderNo,RowVersion")] Category category)
        {
            //Kiểm tra hình được upload có hợp lệ?
            ValidateUploadImage(upload);

            if (db.Categories.SingleOrDefault(c => c.Alias == category.Alias && c.CategoryId != category.CategoryId) != null)
                ModelState.AddModelError("Alias", "Alias này đã tồn tại trong CSDL");

            if (ModelState.IsValid)
            {
                //Lưu hình được upload lên Server
                saveUploadFile(upload, category);

                //Thêm nhóm mặt hàng vào CSDL
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            InitFormData(category);
            return View();
        }

        private List<Category> PopulateCategories()
        {
            //Lấy tất cả các categories
            var allCates = db.Categories
                .OrderBy(c => c.ParentId)
                .ThenBy(c => c.OrderNo)
                .ToList();


            //Chỉ lấy những nhóm mặt hàng cha của tất cả các nhóm
            var groupCates = allCates
                .Where(x => !x.ParentId.HasValue || x.ParentId == 0)
                .ToList();

            //Với mỗi nhóm cha, tìm nhóm con của nó
            foreach (var category in groupCates)
            {
                AddSubCategory(category, allCates);
            }
            return groupCates;
        }
        private void AddSubCategory(Category category, List<Category> allCates)
        {
            //Tìm các nhóm con của nhóm category
            category.ChildCates = allCates
                .Where(x => x.ParentId == category.CategoryId)
                .ToList();

            //với mỗi nhóm con, gọi đệ quy để tìm các nhóm con của nó
            foreach (var subcate in category.ChildCates)
            {
                AddSubCategory(subcate, allCates);
            }
        }

        /// <summary>
        /// Phương thức cập nhật lại thứ tự các nhóm mặt hàng
        /// </summary>
        /// <param name="cid">Mã nhóm mặt hàng đổi thứ tự</param>
        /// <param name="pid">Mã nhóm mặt hàng cha</param>
        /// <param name="siblings">Mã các nhóm mặt hàng anh em</param>
        /// <returns>Trả về true nếu cập nhật thành công</returns>

        [HttpPost]
        public JsonResult Reorder(int cid, int pid, int[] siblings)
        {
            var success = true;
            try
            {
                StringBuilder query = new StringBuilder();
                for (int i = 0; i < siblings.Length; i++)
                {
                    query.AppendFormat("UPDATE dbo.Categories SET OrderNo = {0}" +
                                       "WHERE CategoryId = {1};", i + 1, siblings[i]);

                    //query.AppendFormat("UPDATE dbo.Categories SET ParentId = {0}" +
                    //                   "WHERE CategoryId = {1};", pid, siblings[i]);
                    query.AppendLine();
                }

                //Tạo chuổi truy vấn cập nhật thuộc tính ParentId
                if (pid > 0)
                    query.AppendFormat("UPDATE dbo.Categories SET ParentId = {0}" +
                                       "WHERE CategoryId ={1}",pid, cid);
                success = db.Database.ExecuteSqlCommand(query.ToString()) > 0;
            }
            catch (Exception)
            {
                success = false;
            }
            return Json(success);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        protected override bool OnUpdateToggle(string propName, bool value, object[] keys)
        {
            string query = string.Format(
                "UPDATE dbo.Categories SET {0} = @p0 WHERE CategoryId = @p1", propName);

            return db.Database.ExecuteSqlCommand(query, value, keys[0]) > 0;

        }

        private void ConvertToTreeStructure(IEnumerable<Category> source, List<int> disableIds, int level,
            List<Category> result)
        {

            foreach (var cate in source)
            {
                //thay đổi tên nhóm bằng cách thêm dấu
                var cateName = (level > 0) ? "".PadLeft(level + 1, '-') : "";
                cateName += cate.Name;

                //tao nhóm mặt hàng mới, thêm vào kết quả
                result.Add(new Category
                {
                    CategoryId = cate.CategoryId,
                    Name = cate.Name
                });

                //chỉ cho người dùng chọn nhóm cha là những nhóm ở mưc 0,1
                //Mục đích là không thể tạo ra quá nhiều mức con
                if (level > 1)
                    disableIds.Add(cate.CategoryId);

                ConvertToTreeStructure(cate.ChildCates, disableIds, level + 1, result);
            }
        }

        /// <summary>
        /// Phương thức chuẩn bị dữ liệu để hiển thị lên DropDownList   
        /// </summary>
        /// <param name="category"></param>
        private void InitFormData(Category category)
        {
            //lấy tất cả các nhóm mặt hàng và gom nhóm chúng
            var groupedCates = PopulateCategories();

            //tạo 2 danh sách kết quả
            var disableIds = new List<int>();
            var categories = new List<Category>();

            //Chuyển danh sách nhóm mặt hàng đã gom nhóm
            //Về lại dạng thông thường để hiển thị lên DropdownList
            ConvertToTreeStructure(groupedCates, disableIds, 0, categories);

            //Tạo danh sách chọn làm dữ liệu nguồn cho Dropdownlist
            if (category.ParentId > 0)
                ViewBag.ParentId = new SelectList(categories, "CategoryId", "Name", category.ParentId, disableIds);
            else
                ViewBag.ParentId = new SelectList(categories, "CategoryId", "Name", (object)null, disableIds);
        }

        private void ValidateUploadImage(HttpPostedFileBase upload)
        {
            var allowImageFileTypes = new[] { ".jpg", ".jpeg", ".gif", ".png" };

            //Kiểm tra tính hợp lệ của tập tin được Upload
            if (upload != null)
            {
                //Kiểm tra trường hợp file rỗng
                if (upload.ContentLength == 0)
                    ModelState.AddModelError("IconPath", "Tập tin không có nội dung");

                //Kiểm tra trường hợp file >1MB
                if (upload.ContentLength > 1024 * 1024)
                    ModelState.AddModelError("IconPath", "Dung lượng tập tin quá lơn(>1MB)");

                //Lấy phần mở rộng
                var imageExt = Path.GetExtension(upload.FileName);

                //Kiểm tra trường hợp Upload các file không đúng định dạng cho phép
                if (!allowImageFileTypes.Contains(imageExt))
                {
                    ModelState.AddModelError("IconPath", "Chỉ được phép upload tập tin JPG,JPEG,GIF AND PNG)");
                }
            }
        }

        private void saveUploadFile(HttpPostedFileBase upload, Category category)
        {
            //Bảo đảm là có file hợp lệ thì mới lưu
            if (upload != null && upload.ContentLength > 0)
            {
                //Xóa icon cũ nếu có
                if (!string.IsNullOrEmpty(category.IconPath))
                {
                    var oldFilePath = Server.MapPath(category.IconPath);
                    System.IO.File.Delete(oldFilePath);
                }

                //lấy đường dẫn tuyệt đối của thư mục lưu file
                var targetFolder = Server.MapPath("~/Uploads/Icons");

                //Tạo tên mới cho tập tin và đường dẫn tuyệt đối để lưu
                var uniqueFileName = DateTime.Now.Ticks + "_" + upload.FileName;
                var targetFilePath = Path.Combine(targetFolder, uniqueFileName);

                //luu file
                upload.SaveAs(targetFilePath);

                //Lấy đường dẫn tương đối của tập tin vừa upload
                category.IconPath = Path.Combine("~/Uploads/Icons", uniqueFileName);
            }
        }
    }
}