using SmartShop.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.Inventory
{
    public class ProductCategoryRepository : Repository<ProductCategory>
    {
        public ProductCategoryRepository(DbContext context) : base(context)
        {
        }
    }
}
