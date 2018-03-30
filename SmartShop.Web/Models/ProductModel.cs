using SmartShop.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartShop.Web.Models
{
    public class ProductModel
    {
        public Product GetProductDetais(Guid? id)
        {
            return new ProductManagementService().GetProductDetais(id.Value);
        }
    }
}