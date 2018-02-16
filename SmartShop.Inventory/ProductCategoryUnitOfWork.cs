using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.Inventory
{
    public class ProductCategoryUnitOfWork
    {
        private ProductManagementContext _db;

        public ProductCategoryRepository ProductCategoryRepository { get; set; }

        public ProductCategoryUnitOfWork(ProductManagementContext db)
        {
            _db = db;
            ProductCategoryRepository = new ProductCategoryRepository(db);
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
