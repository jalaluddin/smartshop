using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartShop.Inventory;

namespace SmartShop.Web.Areas.Admin.Controllers
{
    public class ProductCategoryController : Controller
    {
        private ProductManagementContext _context;
        private ProductCategoryManagementUnitOfWork _productCategoryManagementUnitOfWork;

        // GET: Admin/ProductCategory
        public ActionResult Index()
        {
            _context = new ProductManagementContext();
            _productCategoryManagementUnitOfWork = new ProductCategoryManagementUnitOfWork(_context);

            ProductCategory productCategory = new ProductCategory();

            productCategory.Name = "Women";
            productCategory.IsActive = true;

            _productCategoryManagementUnitOfWork.repository.Add(productCategory);

            ProductCategory productCategory2 = new ProductCategory();

            productCategory2.Name = "Clothing";
            productCategory2.IsActive = true;
            productCategory2.ParentCatgory = productCategory;

            _productCategoryManagementUnitOfWork.repository.Add(productCategory2);

            _productCategoryManagementUnitOfWork.Save();

            return View();
        }
    }
}