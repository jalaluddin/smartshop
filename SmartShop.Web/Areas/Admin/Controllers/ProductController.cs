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
    public class ProductController : Controller
    {
        // GET: Admin/Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            ProductManagementContext db = new ProductManagementContext();
            Product p = new Product();
            //p.ID = new Guid();
            p.Name = "Test";
            p.Price = 100;

            db.Product.Add(p);
            db.SaveChanges();

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
    }
}