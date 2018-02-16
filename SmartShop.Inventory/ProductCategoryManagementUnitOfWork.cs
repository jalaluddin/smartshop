using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.Inventory
{
    public class ProductCategoryManagementUnitOfWork : IDisposable
    {
        private ProductManagementContext _context;
        public ProductCategoryRepository repository { get; set; }

        public ProductCategoryManagementUnitOfWork(ProductManagementContext context)
        {
            _context = context;
            repository = new ProductCategoryRepository(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
