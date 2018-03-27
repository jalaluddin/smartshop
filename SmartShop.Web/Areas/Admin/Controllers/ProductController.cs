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
            var productModel = new ProductModel();

            return View(productModel);
        }

        [HttpPost]
        public ActionResult Add(ProductModel productModel )
        {
            productModel.AddProduct();
            return View(productModel);
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
                
                new ProductModel().DeleteProduct(id);
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