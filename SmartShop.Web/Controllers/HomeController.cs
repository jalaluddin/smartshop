using SmartShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartShop.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            SmartShopContext db = new SmartShopContext();
            ProductUnitOfWork uow = new ProductUnitOfWork(db);

            Product p = new Product();
            p.ProductName = "Shovon";
            p.ProductPrice = 100;

            uow.ProductRepository.Add(p);

            uow.Save();

            uow.ProductRepository.GetAll();

            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Electronics()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}