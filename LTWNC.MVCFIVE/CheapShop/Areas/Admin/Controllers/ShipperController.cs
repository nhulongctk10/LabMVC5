using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CheapShop.DAL;
using CheapShop.Models;

namespace CheapShop.Areas.Admin.Controllers
{
    public class ShipperController : AdminController
    {
        private ShopDbContext db = new ShopDbContext();
        public  ActionResult Index()
        {
            return View(db.Shippers.ToList());
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            var success = true;
            try
            {
                Shipper shipper = db.Shippers.Find(id);
                db.Shippers.Remove(shipper);
                db.SaveChanges();
            }
            catch (Exception)
            {
                success = false;
            }
            return Json(success);
        }

       

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompanyName,Phone,Address")] Shipper shipper)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Shippers.Add(shipper);
                    db.SaveChanges();
                    return Redirect(shipper.ShipperId);
                }
            }
            catch (Exception exception)
            {
             ModelState.AddModelError("","Có lỗi trong khi thêm mới. Error: "+exception.Message);   
            }
            return View(shipper);
        }

        public ActionResult Edit(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var shipper = db.Shippers.Find(id);
            if (shipper==null)
            {
                return HttpNotFound();
            }
            return View(shipper);   
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "ShipperId,CompanyName,Phone,Address")] Shipper shipper)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(shipper).State = EntityState.Modified;
                    db.SaveChanges();
                    return Redirect(shipper.ShipperId);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("","Có lỗi khi cập nhật Shipper, Error: "+ex.Message);
            }
            return View(shipper);
        }

    }
}