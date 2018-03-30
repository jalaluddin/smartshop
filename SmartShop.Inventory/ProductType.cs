using SmartShop.Data;
using System;

namespace SmartShop.Inventory
{
    public class ProductType : Entity 
    {
        public string Name { get; set; }
        public Guid Product_ID { get; set; }
    }
}