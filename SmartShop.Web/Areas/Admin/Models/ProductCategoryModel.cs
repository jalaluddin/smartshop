using SmartShop.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
        public void AddCategory(string name, bool isActive, Guid parentCategoryId)
        {
            _productCategoryManagementService.AddCategory(name, isActive, parentCategoryId);
        }
    }
}