using SmartShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public IEnumerable<ProductCategory> ViewAll()
        {
            return _productCategoryManagementUnitOfWork.ProductCategoryRepository.Get();
        }

        public void AddCategory(string name, bool isActive, Guid parentCategoryId)
        {
            ProductCategory productCategory = new ProductCategory();

            productCategory.Name = name;
            productCategory.IsActive = isActive;
            productCategory.ParentCatgory = _productCategoryManagementUnitOfWork.ProductCategoryRepository.GetByID(parentCategoryId);

            _productCategoryManagementUnitOfWork.ProductCategoryRepository.Insert(productCategory);
                       
            _productCategoryManagementUnitOfWork.Save();
        }        

        public IEnumerable<ProductCategory> GetCategories(out int total, out int totalDisplay,
            Expression<Func<ProductCategory, bool>> filter = null,
            Func<IQueryable<ProductCategory>, IOrderedQueryable<ProductCategory>> orderBy = null,
            int pageIndex = 1, int pageSize = 10)
        {
            total = 0;
            totalDisplay = 0;
            return _productCategoryManagementUnitOfWork.ProductCategoryRepository.Get(out total, out totalDisplay, filter, orderBy, 
                "", pageIndex, pageSize, false);
        }
    }
}
