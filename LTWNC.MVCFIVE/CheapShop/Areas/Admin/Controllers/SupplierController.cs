using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CheapShop.DAL;
using PagedList;
using CheapShop.Models;
using System.Net;
using System.Data.Entity;

namespace CheapShop.Areas.Admin.Controllers
{
    public class SupplierController : AdminController
    {
        private ShopDbContext db = new ShopDbContext();

        // GET: Admin/Supplier
        public ActionResult Index(string keyword, int? page, int? pageSize, bool? status)
        {
            var suppliers = db.Suppliers.AsQueryable();
            if (!string.IsNullOrEmpty(keyword))
            {
                suppliers =
                    suppliers.Where(
                        x =>
                            x.Name.Contains(keyword) ||
                            x.ContactName.Contains(keyword) ||
                            x.Description.Contains(keyword) ||
                            x.Address.Contains(keyword));
            }
            if (!page.HasValue || page.Value < 1)
                page = 1;
            if (!pageSize.HasValue || page.Value < 5)
                pageSize = 5;

            ViewBag.status = status;
            if (status != null && ViewBag.status!=null)
                suppliers = suppliers.Where(x => x.Actived == status);
            
            ViewBag.Keyword = keyword;
            ViewBag.PageSize = new SelectList(new[] { 5, 10, 15, 20, 50, 100 }, pageSize);
            ViewBag.CurrentPageSize = pageSize;

            var data = suppliers.OrderBy(x => x.Name).ToPagedList(page.Value, pageSize.Value);
            return View(data);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }

        protected override bool OnUpdateToggle(string propName, bool value, object[] keys)
        {
            try
            {
                string query = string.Format("Update dbo.Suppliers SET {0} = @p0 where SupplierId = @p1", propName);
                return db.Database.ExecuteSqlCommand(query, value, keys[0]) > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection data)
        {
            var supplier = new Supplier();
            try
            {
                UpdateModel(supplier, new[]{
                    "Name","Description","ContactName","ContactTitle","Address","Email",
                    "Phone","Fax","HomePage","Actived"});
                if (ModelState.IsValid)
                {
                    db.Suppliers.Add(supplier);
                    db.SaveChanges();
                    return Redirect(supplier.SupplierId);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Đã có lỗi xảy ra khi tạo supplier, Error: " + ex.Message);
            }
            return View(supplier);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var sup = db.Suppliers.Find(id);
            if (sup == null)
                return HttpNotFound();
            return View(sup);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection data)
        {
            var sup = new Supplier();
            try
            {
                UpdateModel(sup, new[]{
                    "SupplierId","Name","Description","ContactName",
                    "ContactTitle","Address","Email",
                    "Phone","Fax","HomePage","Actived","RowVersion"
                });

                if (ModelState.IsValid)
                {
                    db.Entry(sup).State = EntityState.Modified;
                    db.SaveChanges();
                    return Redirect(sup.SupplierId);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(sup);
        }

        public ActionResult Detail(int id)
        {
            var supplier = db.Suppliers.Find(id);
            return View(supplier);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id==null)
             return   new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var supplier = db.Suppliers.Find(id);
            if(supplier==null)
                return HttpNotFound();

            return View(supplier);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                Supplier supplier = db.Suppliers.Find(id);
                db.Suppliers.Remove(supplier);
                db.SaveChanges();
                return Json(new
                {
                    success = true,
                    redirectUrl =Url.Action("Index","Supplier")

                });
            }
            catch (Exception)
            {
            }
            return Json(false);
        }

    }
}