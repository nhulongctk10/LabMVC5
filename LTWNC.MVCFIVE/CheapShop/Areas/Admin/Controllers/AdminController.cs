using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CheapShop.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,Manager,Salesman")]
    public class AdminController : Controller
    {
        protected virtual ActionResult Redirect(object id)
        {
            var saveAction = Request.Form["save-action"];
            switch (saveAction)
            {
                case "save-new":
                    return RedirectToAction("Create");
                    break;
                case "save-edit":
                    return RedirectToAction("Edit",new{id});
                    break;
                case "save":
                    string url = HttpContext.Request.Url.AbsolutePath;
                    return Redirect(url);
                    break;
                default:
                    return RedirectToAction("Index");
            }
        }

        protected virtual bool OnUpdateToggle(string propName, bool value, object[] keys)
        {
            return true;
        }

        [HttpPost]
        public JsonResult UpdateToggle(string args)
        {
            bool success = false;
            string html = string.Empty;

            try
            {
                var data = args.Split('_');
                var propName = data[0];                 //ten thuoc tin
                var value = !bool.Parse(data[1]);       //gia tri hien tai
                var keys = data.Skip(2).ToArray();      //Id cua mau tin

                if (OnUpdateToggle(propName,value,keys))
                {
                    success = true;

                    html = string.Format("{0}_{1}_{2}",
                        propName,
                        value.ToString().ToLower(),
                        string.Join("_",keys));
                }
            }
            catch (Exception ex)
            {
                success = false;
                html = ex.Message;
            }

            return Json(new
            {
                Result = success,
                Message = html
            });
        }

    }
}