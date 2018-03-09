using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.Inventory
{
    public class ProductManagementUnitOfWork
    {
        private ProductManagementContext _context;
        public ProductRepository ProductRepository { get; set; }

        public ProductManagementUnitOfWork(ProductManagementContext context)
        {
            _context = context;
            ProductRepository = new ProductRepository(_context);
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
