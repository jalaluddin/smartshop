using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartShop.Data;
using SmartShop.Inventory;
using SmartShop.Web.Areas.Admin.Models;
using SmartShop.Web.Models;

namespace SmartShop.Web.Areas.Admin.Controllers
{
    public class ProductCategoryController : Controller
    {        
        // GET: Admin/ProductCategory
        public ActionResult Index()
        {
            var productCategoryModel = new ProductCategoryModel();
            var listOfCategory = productCategoryModel.GetCodingProblemSubCategoryJson();
            return View(listOfCategory);
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

        public JsonResult GetCodingProblemSubCategory(DataTablesAjaxRequestModel datatableModel, Guid? category)
        {
            if (category.HasValue)
            {
                ProductCategoryModel productCategoryModel = new ProductCategoryModel();
                var jsonData = productCategoryModel.GetCodingProblemSubCategoryJson(datatableModel, category.Value);

                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}