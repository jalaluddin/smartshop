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

        public Guid ID { get; set; }
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

        //Properties for product edit

        public List<ProductImage> ExistingProductImages { get; set; }
        public List<ProductType> ExistingProductTypes { get; set; }
        public List<ProductAdditionalInformation> ExistingAdditionalInformations { get; set; }


        public ProductModel()
        {
            _productManagementService = new ProductManagementService();
            _productCategoryManagementService = new ProductCategoryManagementService();
            ProductCategories = _productCategoryManagementService.GetAllCategories();
        }

        public ProductModel(Guid id) : this()
        {
            var product = _productManagementService.GetProductDetails(id);

            this.ID = product.ID;
            this.Name = product.Name;
            this.Price = product.Price;
            if (product.ProductCategory != null)
            {
                this.ProductCategoryId = product.ProductCategory.ID;
            }
            this.SpecialPrice = product.SpecialPrice;
            this.Quantity = product.Quantity;
            this.Description = product.Description;
            this.IsNew = product.IsNew;
            if (product.ProductImages != null)
            {
                this.ExistingProductImages = product.ProductImages;
            }
            if (product.ProductTypes != null)
            {
                this.ExistingProductTypes = product.ProductTypes;
            }
            if (product.ProductAdditionalInformations != null)
            {
                this.ExistingAdditionalInformations = product.ProductAdditionalInformations;
            }


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
                        image.ImageUrl = fullPath;
                        image.OriginalName = originalName;
                        image.CurrentName = newName;

                        productImage.Add(image);
                    }
                }
                return productImage;
            }
            return null;
        }

        public void UpdateProduct()
        {
            for (int i = 0; i < productTypes.Length; i++)
            {
                if (productTypes[i] != "")
                {
                    ProductType productType = _productManagementService;
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
            _productManagementService.UpdateProduct(id, name, productImages, price, productCategoryId, specialPrice, quantity, description, isNew, productTypes, productAdditionalInformations);
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