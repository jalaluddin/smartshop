﻿using SmartShop.Data;
using System;

namespace SmartShop.Inventory
{
    public class ProductAdditionalInformation : Entity 
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}