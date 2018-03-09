using SmartShop.Inventory;
using SmartShop.Web.Areas.Admin.Models;
using SmartShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartShop.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        // GET: Admin/Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {

            return View();
        }

        public ActionResult List()
        {
            return View();
        }

        public JsonResult GetJsonData(DataTablesAjaxRequestModel model)
        {
            var jsonData = new ProductListModel().GetProductJsonData(model);

            return Json(jsonData, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Delete(Guid? id)
        {
            try
            {
                
                new PorductModel().DeleteProduct(id);
                TempData["message"] = "Successfully Deleted";
                TempData["alertType"] = "success";

            }
            catch
            {
                TempData["message"] = "Failed to Deleted";
                TempData["alertType"] = "danger";
            }

            return RedirectToAction("List");
        }
    }
}