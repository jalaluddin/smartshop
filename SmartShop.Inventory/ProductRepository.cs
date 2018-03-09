using SmartShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.Inventory
{
    public class ProductRepository : Repository<Product>
    {
        private ProductManagementContext _context;
        public ProductRepository(ProductManagementContext context)
            : base(context)
        {
            _context = context;
        }
    }
}
