using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.Inventory
{
    public class ProductCategoryManagementService
    {
        private ProductManagementContext _context;
        private ProductCategoryManagementUnitOfWork _productCategoryManagementUnitOfWork;

        public ProductCategoryManagementService()
        {
            _context = new ProductManagementContext();
            _productCategoryManagementUnitOfWork = new ProductCategoryManagementUnitOfWork(_context);
        }
        public void AddCategory(string name, bool isActive, Guid parentCategoryId)
        {
            ProductCategory productCategory = new ProductCategory();

            productCategory.Name = name;
            productCategory.IsActive = isActive;
            productCategory.ParentCatgory = _productCategoryManagementUnitOfWork.ProductCategoryRepository.GetByID(parentCategoryId);

            _productCategoryManagementUnitOfWork.ProductCategoryRepository.Add(productCategory);
                       
            _productCategoryManagementUnitOfWork.Save();
        }
    }
}
