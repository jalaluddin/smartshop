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

        public void DeleteCategory(Guid id)
        {
            _productCategoryManagementUnitOfWork.ProductCategoryRepository.Delete(id);
            _productCategoryManagementUnitOfWork.Save();
        }

        public int GetCount()
        {

            return _productCategoryManagementUnitOfWork.ProductCategoryRepository.GetCount();
            
        }

        public List<ProductCategory> GetPagedCategories(int index, int length, string searchValue, 
            string sortColumnName, string sortDirection, out int recordsTotal, out int recordsFiltered)
        {
            recordsTotal = 0;
            recordsFiltered = 0;

            return _productCategoryManagementUnitOfWork.ProductCategoryRepository.GetDynamic(out recordsTotal, out recordsFiltered,
                x => x.Name.Contains(searchValue), sortColumnName + " " + sortDirection, "", index, length).ToList();
        }


        public ProductCategory GetProductCategory(Guid id)
        {
            return _productCategoryManagementUnitOfWork.ProductCategoryRepository.GetByID(id);
        }

    }
}
