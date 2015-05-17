using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CheapShop.Areas.Admin.Models;
using CheapShop.DAL;
using CheapShop.Models;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using PagedList;

namespace CheapShop.Areas.Admin.Controllers
{
    public class ProductController : AdminController
    {
        private ShopDbContext db = new ShopDbContext();

        // GET: Admin/Product
        public ActionResult Index(ProductSearchModel searchModel)
        {
            var products = db.Products.Include(p => p.Supplier);

            if (!string.IsNullOrWhiteSpace(searchModel.Keyword))
                products = products.Where(x => x.Name.Contains(searchModel.Keyword) ||
                                               x.ShortIntro.Contains(searchModel.Keyword) ||
                                               x.Description.Contains(searchModel.Keyword));
            products = products.OrderBy(x => x.Name);

            if (!searchModel.PageSize.HasValue)
                searchModel.PageSize = 10;
            if (!searchModel.PageIndex.HasValue)
                searchModel.PageIndex = 1;

            ViewBag.PageSize = new SelectList(new[] { 5, 10, 25, 50, 100 }, searchModel.PageSize.Value);
            ViewBag.SearchModel = searchModel;

            return View(products.ToPagedList(searchModel.PageIndex.Value, searchModel.PageSize.Value));
        }


        public ActionResult Create()
        {
            var createModel = new ProductCreateViewModel();
            InitFormData(createModel);
            return View(createModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductCreateViewModel createModel)
        {
            var discount = EnsureDiscountValue(createModel);

            var imagePath = SaveUploadFile(createModel.Upload, null);

            if (string.IsNullOrEmpty(imagePath)) ModelState.AddModelError("Upload", "Bạn chưa chọn hình cho sản phẩm");

            if (createModel.SelectedCategories == null || !createModel.SelectedCategories.Any())
                ModelState.AddModelError("SelectedCategoires", "Bạn phải chọn ít nhất một nhóm mặt hàng cho sản phẩm");

            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    Name = createModel.Name,
                    Alias = createModel.Alias,
                    ProductCode = createModel.ProductCode,
                    ShortIntro = createModel.ShortIntro,
                    Description = createModel.Description,
                    QtyPerUnit = createModel.QtyPerUnit,
                    Quantity = createModel.Quantity,
                    Price = createModel.Price,

                    SupplierId = createModel.SupplierId,
                    Actived = createModel.Actived,
                    Discount = discount,
                    Thumbnail = imagePath,
                    Category = new List<Category>()
                };

                UpdateProductCategories(product, createModel.SelectedCategories);

                var history = new ProductHistory
                {
                    AccountId = User.Identity.GetUserId(),
                    ActionTime = DateTime.Now,
                    ProductId = product.ProductId,
                    HistoryAction = ProductHistoryAction.Create,
                    OriginalProduct = null,
                    ModifiedProduct = JsonConvert.SerializeObject(product)
                };

                var productProfiles = new ProductProfile
                {
                    ProductId = product.ProductId,
                    Sales = 0,
                    TotalScore = 0,
                    ViewCount = 0,
                    VoteCount = 0,
                };

                try
                {
                    db.Products.Add(product);
                    db.ProductHistories.Add(history);
                    //db.ProductProfiles.Add(productProfiles);

                    db.SaveChanges();
                    return Redirect(product.ProductId);
                }
                catch (Exception exception)
                {
                    string error = exception.Message;
                    return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
                }

            }

            InitFormData(createModel);
            return View(createModel);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var product = db.Products.Include(p => p.Category).SingleOrDefault(p => p.ProductId == id);

            var selectedCates = product.Category.Select(x => x.CategoryId).ToArray();

            var editModel = new ProductEditViewModel
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Alias = product.Alias,
                ProductCode = product.ProductCode,
                ShortIntro = product.ShortIntro,
                Description = product.Description,
                QtyPerUnit = product.QtyPerUnit,
                Quantity = product.Quantity,
                Price = product.Price,
                SupplierId = product.SupplierId,
                Actived = product.Actived,
                RowVersion = product.RowVersion,
                Discount = product.Discount,
                ThumbImage = product.Thumbnail,
                SelectedCategories = selectedCates
            };

            InitFormData(editModel);
            return View(editModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductEditViewModel editModel)
        {
            var discount = EnsureDiscountValue(editModel);

            // Lưu file hình được upload kèm
            var imagePath = SaveUploadFile(editModel.Upload, editModel.ThumbImage);

            // Bảo đảm phải có ít nhất 1 nhóm mặt hàng được chọn
            if (editModel.SelectedCategories == null || !editModel.SelectedCategories.Any()) ModelState.AddModelError("SelectedCategories", "Bạn phải chọn ít nhất một nhóm mặt hàng cho sản phẩm");

            if (ModelState.IsValid)
            {
                // Lấy thông tin sản phẩm trước khi cập nhật
                var oldProd = db.Products.AsNoTracking().Single(x => x.ProductId == editModel.ProductId);

                var product = new Product
                {
                    ProductId = editModel.ProductId,
                    Name = editModel.Name,
                    Alias = editModel.Alias,
                    ProductCode = editModel.ProductCode,
                    ShortIntro = editModel.ShortIntro,
                    Description = editModel.Description,
                    QtyPerUnit = editModel.QtyPerUnit,
                    Quantity = editModel.Quantity,

                    Price = editModel.Price,
                    SupplierId = editModel.SupplierId,
                    Actived = editModel.Actived,
                    RowVersion = editModel.RowVersion,
                    Discount = discount,
                    Thumbnail = imagePath,
                    Category = new List<Category>()
                };
                UpdateProductCategories(product, editModel.SelectedCategories);

                var history = new ProductHistory
                {
                    AccountId = User.Identity.GetUserId(),
                    ActionTime = DateTime.Now,
                    ProductId = product.ProductId,
                    HistoryAction = ProductHistoryAction.UpdateFull,
                    OriginalProduct = JsonConvert.SerializeObject(oldProd),
                    ModifiedProduct = JsonConvert.SerializeObject(product)
                };

                db.Entry(product).State = EntityState.Modified;
                db.ProductHistories.Add(history);

                db.SaveChanges();
                return Redirect(product.ProductId);
            }
            InitFormData(editModel);
            return View(editModel);
        }

        public PartialViewResult ProductImage(int productId)
        {
            var proImages = db.Pictures.Where(p => p.ProductId == productId).ToList();

            return PartialView("_ProductImages", proImages);
        }

        [HttpGet]
        public PartialViewResult InsertProductImage(int productId)
        {
            ViewBag.ProductId = productId;
            return PartialView("_InsertProductImage");
        }

        [HttpPost]
        public ActionResult InsertProductImage(Picture model, HttpPostedFileBase upload)
        {
            try
            {
                var path = SaveUploadFile(upload, null);

                Picture pt = new Picture
                {
                    ProductId = model.ProductId,
                    Caption = model.Caption,
                    Path = path,
                    Actived = model.Actived,
                    OrderNo = model.OrderNo
                };
                db.Pictures.Add(pt);
                int rowEff = db.SaveChanges();
            }
            catch (Exception)
            {
                // Ghi Log
                //return Json(false);
            }
            
            var imageList = db.Pictures.Where(p => p.ProductId == model.ProductId).ToList();
            return PartialView("_ProductImages", imageList);
        }

        public ActionResult ProductDetails(int? id, int? page, int? pageSize, int? currentTab)
        {
            if (!page.HasValue || page.Value < 1)
                page = 1;
            if (!pageSize.HasValue || pageSize.Value < 10)
                pageSize = 10;

            if (!currentTab.HasValue || currentTab < 1)
                currentTab = 1;

            ViewBag.CurrentPage = page;
            ViewBag.CurrentTab = currentTab;
            ViewBag.PageSize = new SelectList(new[] { 10, 20, 35, 50, 100 }, pageSize);

            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var product = db.Products
                .Include(p => p.ProductProfiles)
                .Include(p => p.ProductHistories)
                .SingleOrDefault(p => p.ProductId == id);

            if (product != null)
            {
                List<Comment> comments = product.Comments.ToList();
                foreach (var comment in comments)
                {
                    comment.Replier = db.Accounts.Find(comment.AccountId);
                }

                var viewModel = new ProductDetailsViewModel
                {
                    Product = product,
                    Picture = product.Pictures.OrderBy(x => x.OrderNo).ToList(),
                    Comment = comments,
                    ProductProfile = product.ProductProfiles,
                    ProductHistory = product.ProductHistories.ToList()
                };

                return View(viewModel);
            }
            return HttpNotFound();

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }

        protected override bool OnUpdateToggle(string propName, bool value, object[] keys)
        {
            string query = string.Format("UPDATE dbo.Products SET {0} = @p0 WHERE ProductId = @p1", propName);
            return db.Database.ExecuteSqlCommand(query, value, keys[0]) > 0;
        }




        /// <summary>
        /// Phương thức kiểm tra alias đang nhập trong form create
        /// và edit có bị trùng bới alias đã có trong CSDL chưa
        /// </summary>
        /// <param name="alias">Tên định danh của SP đang cập nhật</param>
        /// <param name="productId"></param>
        /// <returns>Trả về true nếu không bị trùng</returns>
        public JsonResult CheckUniqueAlias(string alias, int? productId)
        {
            if (!productId.HasValue) productId = 0;

            var result = db.Products.SingleOrDefault(x => x.Alias == alias && x.ProductId != productId.Value) == null;

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CheckUniqueCode(string productCode, int? productId)
        {
            if (!productId.HasValue) productId = 0;

            var result = db.Products.SingleOrDefault(x => x.ProductCode == productCode && x.ProductId == productId.Value) == null;

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        private float EnsureDiscountValue(ProductCreateViewModel model)
        {
            var discount = 0.0f;

            if (model.Discount >= model.Price)
            {
                ModelState.AddModelError("Discount", "Tiền giảm giá không được >= Giá bán");
                discount = 0;
            }
            else if (model.Discount >= 100) discount = (float)Math.Round(model.Discount / model.Price, 2);
            else if (model.Discount > 1) discount = model.Discount / 100.0f;
            return discount;
        }

        /// <summary>
        /// Phương thức chuẩn bị dữ liệu cho Form nhập SP
        /// </summary>
        /// <param name="model"></param>
        private void InitFormData(ProductCreateViewModel model)
        {
            var allCates = db.Categories.Where(x => x.Actived).OrderBy(x => x.ParentId).ThenBy(x => x.OrderNo).ToList();

            var suppliers = db.Suppliers.Where(x => x.Actived).OrderBy(x => x.Name).ToList();

            if (model.SelectedCategories == null)
            {
                model.Categories = new MultiSelectList(allCates, "CategoryId", "Name");
                model.Suppliers = new SelectList(suppliers, "SupplierId", "Name");
            }
            else
            {
                model.Categories = new MultiSelectList(allCates, "CategoryId", "Name", model.SelectedCategories);
                model.Suppliers = new SelectList(suppliers, "SupplierId", "Name", model.SupplierId);
            }
        }

        private string SaveUploadFile(HttpPostedFileBase upload, string oldFilePath)
        {
            if (upload != null && upload.ContentLength > 0)
            {
                var targetFolder = Server.MapPath("~/Uploads/Pictures");

                var uniqueFileName = DateTime.Now.Ticks + "_" + upload.FileName;
                var targetFilePath = Path.Combine(targetFolder, uniqueFileName);

                upload.SaveAs(targetFilePath);

                if (!string.IsNullOrEmpty(oldFilePath))
                {
                    oldFilePath = Server.MapPath(oldFilePath);
                    System.IO.File.Delete(oldFilePath);
                }

                return Path.Combine("~/Uploads/Pictures", uniqueFileName);
            }
            return oldFilePath;
        }

        private void UpdateProductCategories(Product product, int[] selectedCategories)
        {
            if (selectedCategories == null) return;

            var categories = db.Categories.ToList();

            var currentCateIds = new HashSet<int>(product.Category.Select(x => x.CategoryId));

            foreach (var cate in categories)
            {
                if (selectedCategories.Contains(cate.CategoryId))
                {
                    if (!currentCateIds.Contains(cate.CategoryId)) product.Category.Add(cate);
                }
                else
                {
                    if (currentCateIds.Contains(cate.CategoryId))
                        product.Category.Remove(cate);
                }
            }
        }

    }

}