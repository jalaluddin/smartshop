﻿using SmartShop.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartShop.Web.Areas.Admin.Models
{
    public class ProductCategoryModel
    {
        private ProductCategoryManagementService _productCategoryManagementService;

        public Guid ID { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public Guid ParentCategoryId { get; set; }


        public ProductCategoryModel()
        {
            _productCategoryManagementService = new ProductCategoryManagementService();
        }
        public ProductCategoryModel(Guid id)
        {
            _productCategoryManagementService = new ProductCategoryManagementService();
            var category=_productCategoryManagementService.GetProductCategory(id);

            this.ID = category.ID;
            this.Name = category.Name;
            this.IsActive = category.IsActive;
        }
        public void AddCategory(string name, bool isActive, Guid parentCategoryId)
        {
            _productCategoryManagementService.AddCategory(name, isActive, parentCategoryId);
        }

        internal void DeleteProductCategory(Guid? id)
        {
            if(id.HasValue)
                _productCategoryManagementService.DeleteCategory(id.Value);
        }

        public ProductCategory LoadProductCategoryData(Guid? id)
        {
            if (id.HasValue)
            {
                return _productCategoryManagementService.GetProductCategory(id.Value);
            }
            else
            {
                throw new Exception();
            }
                
        }
    }
}