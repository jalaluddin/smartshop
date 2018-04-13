using SmartShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.Inventory
{
    public class ProductCategoryManagementUnitOfWork : UnitOfWork, IProductCategoryManagementUnitOfWork
    {
        public IProductCategoryRepository ProductCategoryRepository { get; set; }

        public ProductCategoryManagementUnitOfWork(ProductManagementContext context) : base(context)
        {
            ProductCategoryRepository = new ProductCategoryRepository(context);
        }
    }
}
