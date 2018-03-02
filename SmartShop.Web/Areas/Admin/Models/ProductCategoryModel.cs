using Newtonsoft.Json;
using SmartShop.Data;
using SmartShop.Inventory;
using SmartShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace SmartShop.Web.Areas.Admin.Models
{
    public class ProductCategoryModel
    {
        private ProductCategoryManagementService _productCategoryManagementService;

        public string Name { get; set; }
        public bool IsActive { get; set; }
        public Guid ParentCategoryId { get; set; }


        public ProductCategoryModel()
        {
            _productCategoryManagementService = new ProductCategoryManagementService();
        }

        //public IEnumerable<ProductCategory> ViewAll()
        //{
        //    return _productCategoryManagementService.ViewAll();
        //}

        public void AddCategory(string name, bool isActive, Guid parentCategoryId)
        {
            _productCategoryManagementService.AddCategory(name, isActive, parentCategoryId);
        }

        public string GetProductCategoryJson(DataTablesAjaxRequestModel datatableModel, Guid? category)
        {
            return JsonConvert.SerializeObject(_productCategoryManagementService.ViewAll());
        }
    }
}