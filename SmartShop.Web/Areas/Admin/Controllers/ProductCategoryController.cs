﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            ProductManagementContext db = new ProductManagementContext();
            ProductCategoryManagementUnitOfWork uow = new ProductCategoryManagementUnitOfWork(db);

             var model = uow.ProductCategoryRepository.Get();
            return View(model);
        }

        public ActionResult List2()
        {
            ProductManagementContext db = new ProductManagementContext();
            ProductCategoryManagementUnitOfWork uow = new ProductCategoryManagementUnitOfWork(db);

            var model = uow.ProductCategoryRepository.Get();
            return View(model);
        }

        public JsonResult GetJsonData(ProductCategoryDatatableModel datatableModel)
        {
            var jsonData = new ProductCategoryDatatableModel().GetProductCategoryJsonData(datatableModel);

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
    }
}