using SmartShop.Inventory;
using SmartShop.Web.Areas.Admin.Models;
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
            var productModel = new ProductModel();

            return View(productModel);
        }

        [HttpPost]
        public ActionResult Add(ProductModel productModel )
        {
             try
             {
                productModel.AddProduct();
                TempData["message"] = "Successfully Product Added";
                TempData["alertType"] = "success";

            }
            catch(Exception e)
            {
                App_Start.LoggerConfig.Logger.Debug(e.Message);
                TempData["message"] = "Failed to Add Product";
                TempData["alertType"] = "danger";
            }

            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            return View();
        }

        public JsonResult GetJsonData(Web.Models.DataTablesAjaxRequestModel model)
        {
            var jsonData = new ProductListModel().GetProductJsonData(model);

            return Json(jsonData, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Delete(Guid? id)
        {
            try
            {
                new ProductModel().DeleteProduct(id);
                TempData["message"] = "Successfully Deleted";
                TempData["alertType"] = "success";

            }
            catch(Exception e)
            {
                App_Start.LoggerConfig.Logger.Debug(e.InnerException.InnerException.Message);
                TempData["message"] = "Failed to Deleted";
                TempData["alertType"] = "danger";
            }

            return RedirectToAction("List");
        }
    }
}