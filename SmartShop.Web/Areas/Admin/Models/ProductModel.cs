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
        public HttpPostedFileBase[] ProductImages { get; set; }
        public int ImageSelection { get; set; }
        public string[] ProductTypes { get; set; }
        public string[] ProductAdditionalInformationName { get; set; }
        public string[] ProductAdditionalInformationDescription { get; set; }

        public ProductModel()
        {
            _productManagementService = new ProductManagementService();
            _productCategoryManagementService = new ProductCategoryManagementService();
            ProductCategories = _productCategoryManagementService.GetAllCategories();
        }

        public void AddProduct()
        {
            List<ProductType> productTypeList = new List<ProductType>();
            List<ProductAdditionalInformation> productAdditionalInformationList = new List<ProductAdditionalInformation>();

            var images = UploadImages(ProductImages);
            if (ImageSelection !=0)
            {
                images[ImageSelection - 1].IsFeaturedImage = true;
            }
            for (int i  = 0; i  < ProductTypes.Length; i ++)
            {
                if (ProductTypes[i] != "")
                {
                    ProductType productType = new ProductType();
                    productType.Name = ProductTypes[i];
                    productTypeList.Add(productType);
                }

            }
            for (int i = 0; i < ProductAdditionalInformationDescription.Length; i++)
            {
                if (ProductAdditionalInformationName[i] != "" && ProductAdditionalInformationDescription[i] != "")
                {
                    ProductAdditionalInformation productAdditionalInformation = new ProductAdditionalInformation();
                    productAdditionalInformation.Name = ProductAdditionalInformationName[i];
                    productAdditionalInformation.Description = ProductAdditionalInformationDescription[i];

                    productAdditionalInformationList.Add(productAdditionalInformation);
                }
            }
            
            _productManagementService.AddProduct(Name, images, Price, ProductCategoryId, SpecialPrice, Quantity, Description, IsNew , productTypeList, productAdditionalInformationList);
        }

        private List<ProductImage> UploadImages(HttpPostedFileBase[] imageFiles)
        {
            List<ProductImage> productImage = new List<ProductImage>();
            if(imageFiles != null)
            {
                string uploadPath = ConfigurationManager.AppSettings["TemporaryFileLocation"];
                for (int i = 0; i < imageFiles.Length; i++)
                {
                    if (imageFiles[i] !=null)
                    {
                        string originalName = imageFiles[i].FileName;
                        string newName = Guid.NewGuid().ToString().Replace("-", "") + originalName.Substring(originalName.IndexOf('.'));
                        string fullPath = uploadPath + "/" + newName;
                        imageFiles[i].SaveAs(HttpContext.Current.Server.MapPath(fullPath));

                        ProductImage image = new ProductImage();
                        image.ImageUrl = fullPath.TrimStart('~');
                        image.OriginalName = originalName;
                        image.CurrentName = newName;

                        productImage.Add(image);
                    }
                }
                return productImage;
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