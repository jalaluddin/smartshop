using SmartShop.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartShop.Web.Areas.Admin.Models
{
    public class ProductModel
    {
        private ProductManagementService _productManagementService;
        private ProductCategoryManagementService _productCategoryManagementService;

        public string Name { get; set; }
        public double Price { get; set; }
        public virtual List<ProductCategory> ProductCategories { get; set; }
        public Guid ProductCategoryId { get; set; }
        public double SpecialPrice { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public bool IsNew { get; set; }

        public ProductModel()
        {
            _productManagementService = new ProductManagementService();
            _productCategoryManagementService = new ProductCategoryManagementService();
            ProductCategories = _productCategoryManagementService.GetAllCategories();
        }

        public void AddProduct(string name, double price, Guid productCategoryId, double specialPrice, int quantity, string description, bool isNew)
        {
            _productManagementService.AddProduct(name, price, productCategoryId, specialPrice, quantity, description, isNew);
        }

        public void DeleteProduct(Guid? id)
        {
            if (id.HasValue)
            {
                _productManagementService.DeleteProduct(id.Value);
            }
            else
            {
                throw new Exception();
            }
                
        }
       
    }
}