using SmartShop.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartShop.Web.Areas.Admin.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddCategory()
        {
            ProductManagementContext db = new ProductManagementContext();
            ProductCategoryUnitOfWork uow = new ProductCategoryUnitOfWork(db);

            var parent=uow.ProductCategoryRepository.GetByID(new Guid("8606dcda-1830-c335-f537-08d57534d961"));

            ProductCategory pc = new ProductCategory();
            pc.Name = "Cap2";
            pc.IsActive = true;
            pc.ParentCategory = parent;

            uow.ProductCategoryRepository.Add(pc);
            uow.Save();

            return View();
        }

    }
}