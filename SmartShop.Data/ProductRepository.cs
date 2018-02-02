using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.Data
{
    public class ProductRepository : Repository<Product> 
    {
        private SmartShopContext _db;
        public ProductRepository(SmartShopContext db) : base(db)
        {
            _db = db;
        }
    }
}
