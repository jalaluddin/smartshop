using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartShop.Inventory;
using System.Linq.Dynamic;
using SmartShop.Web.Models;

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
            var productCategoryModel = new Models.ProductCategoryModel();            
            
            return View(productCategoryModel);
        }

        [HttpPost]
        public ActionResult Add(Models.ProductCategoryModel productCategoryModel)
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
            var jsonData = new Models.ProductCategoryListModel().GetProductCategoryJson(model);

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult List(Guid? id)
        {
            try
            {
                var model = new Models.ProductCategoryModel();
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

        public ActionResult Edit(Guid? id)
        {
            var model = new Models.ProductCategoryModel(id.Value);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Models.ProductCategoryModel productCategoryModel)
        {
            new Models.ProductCategoryModel().UpdateCategory(productCategoryModel.ID, productCategoryModel.Name, productCategoryModel.IsActive, productCategoryModel.ParentCategoryId);

            var model = new Models.ProductCategoryModel(productCategoryModel.ID);
            return View(model);
        }
    }
}