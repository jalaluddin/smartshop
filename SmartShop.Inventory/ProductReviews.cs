﻿using SmartShop.Data;

namespace SmartShop.Inventory
{
    public class ProductReviews : Entity 
    {
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string Description { get; set; }
        public bool IsPublished { get; set; }
    }
}