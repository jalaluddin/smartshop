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

            _productCategoryManagementUnitOfWork.ProductCategoryRepository.Insert(productCategory);
                       
            _productCategoryManagementUnitOfWork.Save();
        }

        public int GetCount()
        {

            return _productCategoryManagementUnitOfWork.ProductCategoryRepository.GetCount();
            
        }

        public List<ProductCategory> GetResult(int start, int length, string searchText, string order/*, out int totalRecords, out int totalDisplayableRecords*/)
        {
            List<ProductCategory> records = _context.ProductCategory.
                // Where(w=> w.Name.Contains("/"+searchText+"/")).
                OrderBy(o => o.ID).
                Skip(start).
                Take(length).ToList();

            return records;
            //return _productCategoryManagementUnitOfWork.ProductCategoryRepository.Get().ToList(/*totalRecords, totalDisplayableRecords*/);
        }
    }
}
