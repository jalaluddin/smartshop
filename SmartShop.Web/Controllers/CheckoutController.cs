using SmartShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartShop.Web.Controllers
{
    public class checkoutController : Controller
    {
        // GET: Checkout
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetCodingProblemSubCategory(DataTablesAjaxRequestModel datatableModel, Guid? category)
        {
            if (category.HasValue)
            {
                SubmitCodingProblemModel model = new SubmitCodingProblemModel();
                var jsonData = model.GetCodingProblemSubCategoryJson(datatableModel, category.Value);

                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}