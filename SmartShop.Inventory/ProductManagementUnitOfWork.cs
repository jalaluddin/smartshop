using SmartShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.Inventory
{
    public class ProductManagementUnitOfWork : UnitOfWork, IProductManagementUnitOfWork
    {
        public ProductRepository ProductRepository { get; set; }
        public ProductImageRepository ProductImageRepository { get; set; }

        public ProductManagementUnitOfWork(ProductManagementContext context) :base(context)
        {
            ProductRepository = new ProductRepository(context);
            ProductImageRepository = new ProductImageRepository(context);
        }

        
    }
}
