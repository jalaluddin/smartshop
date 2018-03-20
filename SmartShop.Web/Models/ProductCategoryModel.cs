using SmartShop.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartShop.Web.Models
{
    public class ProductCategoryModel
    {
        public IEnumerable<ProductCategory> GetMainProductCategoryList()
        {
            return new ProductCategoryManagementService().GetMainProductCatrgoryList();
        }
    }
}