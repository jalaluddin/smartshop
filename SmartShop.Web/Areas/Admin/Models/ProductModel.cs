using SmartShop.Inventory;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        public List<HttpPostedFileBase> ProductImages { get; set; }

        public ProductModel()
        {
            _productManagementService = new ProductManagementService();
            _productCategoryManagementService = new ProductCategoryManagementService();
            ProductCategories = _productCategoryManagementService.GetAllCategories();
            ProductImages = new List<HttpPostedFileBase>();
        }

        public void AddProduct(string name, double price, Guid productCategoryId, double specialPrice, int quantity, string description, bool isNew, List<HttpPostedFileBase> productImages)
        {
            var productImageList = new List<ProductImage>();

            foreach(var image in productImages)
            {
                productImageList.Add(UploadFeaturedImage(image)); 
            }
            //featuredImage = UploadFeaturedImage(featuredImageFile);
            _productManagementService.AddProduct(name, price, productCategoryId, specialPrice, quantity, description, isNew, productImageList);
        }

        private ProductImage UploadFeaturedImage(HttpPostedFileBase imageFile)
        {
            if(imageFile != null)
            {
                string uploadPath = ConfigurationManager.AppSettings["TemporaryFileLocation"];
                string originalName = imageFile.FileName;
                string newName = Guid.NewGuid().ToString().Replace("-", "") + originalName.Substring(originalName.IndexOf('.'));
                string fullPath = uploadPath + "/" + newName;
                imageFile.SaveAs(HttpContext.Current.Server.MapPath(fullPath));

                ProductImage image = new ProductImage();
                image.ImageUrl = fullPath;
                image.OriginalName = originalName;
                image.CurrentName = newName;

                return image;
            }
            return null;
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