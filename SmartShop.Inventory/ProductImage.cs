using SmartShop.Data;
using System;

namespace SmartShop.Inventory
{
    public class ProductImage : Entity 
    {
        public string Caption { get; set; }
        public string ImageUrl { get; set; }    
        public string OriginalName { get; set; }
        public string CurrentName { get; set; }
        public bool IsFeaturedImage { get; set; }
    }
}