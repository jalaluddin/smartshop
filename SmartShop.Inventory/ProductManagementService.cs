using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.Inventory
{
    public class ProductManagementService
    {
        private ProductManagementContext _context;
        private ProductManagementUnitOfWork _productManagementUnitOfWork;

        private ProductCategoryManagementUnitOfWork _productCategoryManagementUnitOfWork;

        public ProductManagementService()
        {
            _context = new ProductManagementContext();
            _productManagementUnitOfWork = new ProductManagementUnitOfWork(_context);
            _productCategoryManagementUnitOfWork = new ProductCategoryManagementUnitOfWork(_context);
        }
        public List<Product> GetPagedProducts(int index, int length, string searchValue,
            string sortColumnName, string sortDirection, out int recordsTotal, out int recordsFiltered)
        {
            recordsTotal = 0;
            recordsFiltered = 0;

            return _productManagementUnitOfWork.ProductRepository.GetDynamic(out recordsTotal, out recordsFiltered,
                x => x.Name.Contains(searchValue), sortColumnName + " " + sortDirection, "", index, length).ToList();
        }
        public Product GetProductDetails(Guid id)
        {
            return _productManagementUnitOfWork.ProductRepository.GetByID(id);
        }
        public IEnumerable<Product> GetProductList()
        {
            return _productManagementUnitOfWork.ProductRepository.Get();
        }
        public void AddProduct(string name,List<ProductImage> productImages, double price, 
            Guid productCategoryId, double specialPrice, int quantity, string description, bool isNew,
            List<ProductType> productTypes, List<ProductAdditionalInformation> productAdditionalInformations)
        {
            Product product = new Product();

            product.Name = name;
            product.Price = price;
            product.ProductCategory = _productCategoryManagementUnitOfWork.ProductCategoryRepository.GetByID(productCategoryId);
            product.SpecialPrice = specialPrice;
            product.Quantity = quantity;
            product.Description = description;
            product.IsNew = isNew;
            product.ProductImages = productImages;
            product.ProductTypes = productTypes;
            product.ProductAdditionalInformations = productAdditionalInformations;

            _productManagementUnitOfWork.ProductRepository.Insert(product);
            _productManagementUnitOfWork.Save();
        }

        public void DeleteProduct(Guid id)
        {
            _productManagementUnitOfWork.ProductRepository.Delete(id);
            _productManagementUnitOfWork.Save();
        }

        public IEnumerable<Product> GetLatestDesignProductList()
        {
            return _productManagementUnitOfWork.ProductRepository.Get(w => w.IsNew);
        }

        public IEnumerable<Product> GetSpacialOffersProductList()
        {
            return _productManagementUnitOfWork.ProductRepository.Get(w => w.SpecialPrice > 0 );
        }
    }
}
