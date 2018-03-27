using SmartShop.Data;
using SmartShop.Web.App_Start;
using SmartShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartShop.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            ViewBag.MainProductCategoryList = new ProductCategoryModel().GetMainProductCategoryList();
        }

        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult About()
        {
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

        public ActionResult Details()
        {
            return View();
        }
    }
}