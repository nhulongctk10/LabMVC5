using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CheapShop.DAL;
using CheapShop.Models;
using PagedList;

namespace CheapShop.Areas.Admin.Controllers
{
    public class ProductHistoriesController : Controller
    {
        private ShopDbContext db = new ShopDbContext();

        // GET: Admin/ProductHistories
        public ActionResult Index(int? page, int? pageSize)
        {
            var productHistories = db.ProductHistories.Include(p => p.Account).Include(p => p.Product);
            return View(productHistories.ToList());
        }

        // GET: Admin/ProductHistories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductHistory productHistory = db.ProductHistories.Find(id);
            if (productHistory == null)
            {
                return HttpNotFound();
            }
            return View(productHistory);
        }


        // GET: Admin/ProductHistories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductHistory productHistory = db.ProductHistories.Find(id);
            if (productHistory == null)
            {
                return HttpNotFound();
            }
            return View(productHistory);
        }

        // POST: Admin/ProductHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductHistory productHistory = db.ProductHistories.Find(id);
            db.ProductHistories.Remove(productHistory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
