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
            return View();
        }

        /*public JsonResult GetJsonData(ProductCategoryDatatableModel datatableModel)
        {
            var jsonData = new ProductCategoryDatatableModel().GetProductCategoryJsonData(datatableModel);

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }*/
        
        public JsonResult GetJsonData()
        {
            ProductManagementContext db = new ProductManagementContext();

            // All Post Data
            string[] columnOrder = { null, "Name" ,null ,null ,"CreatedAt", null};
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = columnOrder[Convert.ToInt32(Request["order[0][column]"])];
            string sortDirection = Request["order[0][dir]"];


            List<ProductCategory> records = db.ProductCategory.ToList();

            int recordsTotal = records.Count();
            length = (length == -1 ? recordsTotal : length); // To Show All records
            //filter
            records = records.Where(w => w.Name.ToLower().Contains(searchValue.ToLower())).ToList();
      
            int recordsFiltered = records.Count();

            //sorting (required System.Linq.Dynamic)
            if(sortColumnName != null)
            {
                records = records.OrderBy(sortColumnName+" "+ sortDirection).ToList();
            }
             
            //Paging

            records = records.Skip(start).Take(length).ToList();

            

            int serial = start + 1;
            var dataSet = (
                    from record in records
                    select new string[]
                    {       serial++.ToString(),
                            record.Name.ToString(),
                            record.IsActive.ToString(),
                            (record.ParentCatgory != null ? record.ParentCatgory.Name.ToString() : "-" ),
                            record.CreatedAt.ToShortDateString(),
                            "<a href='#'>Delete</a>"
                    }
                );

            var jsonData = new
            {
                recordsTotal = recordsTotal,
                recordsFiltered = recordsFiltered,
                data = dataSet
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
    }
}