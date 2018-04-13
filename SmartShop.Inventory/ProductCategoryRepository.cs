using SmartShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.Inventory
{
    public class ProductCategoryRepository : Repository<ProductCategory>, IProductCategoryRepository
    {
        private ProductManagementContext _context;
        public ProductCategoryRepository(ProductManagementContext context)
            :base(context)
        {
            _context = context;
        }
    }
}
