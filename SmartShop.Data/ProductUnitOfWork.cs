using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.Data
{
    public class ProductUnitOfWork : IDisposable
    {
        private SmartShopContext _db;

        public ProductRepository ProductRepository { get; set; }

        public ProductUnitOfWork(SmartShopContext db)
        {
            _db = db;
            ProductRepository = new ProductRepository(db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
