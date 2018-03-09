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

        public ProductManagementService()
        {
            _context = new ProductManagementContext();
            _productManagementUnitOfWork = new ProductManagementUnitOfWork(_context);
        }
        public List<Product> GetPagedProducts(int index, int length, string searchValue,
            string sortColumnName, string sortDirection, out int recordsTotal, out int recordsFiltered)
        {
            recordsTotal = 0;
            recordsFiltered = 0;

            return _productManagementUnitOfWork.ProductRepository.GetDynamic(out recordsTotal, out recordsFiltered,
                x => x.Name.Contains(searchValue), sortColumnName + " " + sortDirection, "", index, length).ToList();
        }

        public void DeleteProduct(Guid id)
        {
            _productManagementUnitOfWork.ProductRepository.Delete(id);
            _productManagementUnitOfWork.Save();
        }
    }
}
