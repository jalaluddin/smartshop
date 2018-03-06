using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartShop.Inventory;
using SmartShop.Web.Areas.Admin.Models;
using SmartShop.Web.Models;
using System.Linq.Dynamic;

namespace SmartShop.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class ProductCategoryController : Controller
    {        
        // GET: Admin/ProductCategory
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {
            var productCategoryModel = new ProductCategoryModel();
            return View(productCategoryModel);
        }

        [HttpPost]
        public ActionResult Add(ProductCategoryModel productCategoryModel)
        {
            productCategoryModel.AddCategory(productCategoryModel.Name, productCategoryModel.IsActive, productCategoryModel.ParentCategoryId);
            return View(productCategoryModel);
        }

        public ActionResult List()
        {
            return View();
        }

        public JsonResult GetJsonData(DataTablesAjaxRequestModel model)
        {
            var jsonData = new ProductCategoryListModel().GetProductCategoryJson(model);

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult List(Guid? id)
        {
            try
            {
                var model = new ProductCategoryModel();
                model.DeleteProductCategory(id);
                ViewBag.Message = "Successfuly deleted item.";
                ViewBag.Success = true;
            }
            catch
            {
                ViewBag.Message = "Failed to delete item.";
                ViewBag.Success = false;
            }

            return View();
        }
    }
}