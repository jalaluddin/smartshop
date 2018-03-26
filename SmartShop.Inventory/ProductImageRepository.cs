using SmartShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.Inventory
{
    public class ProductImageRepository : Repository<ProductImage>
    {
        private ProductManagementContext _context;
        public ProductImageRepository(ProductManagementContext context)
            : base(context)
        {
            _context = context;
        }
    }
}
