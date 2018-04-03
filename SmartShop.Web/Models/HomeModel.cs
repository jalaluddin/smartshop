using SmartShop.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartShop.Web.Models
{
    public class HomeModel
    {
        public List<Product> LatestProduct { get; set; }
        public List<Product> SpecialOfferProduct { get; set; }
        public List<ProductCategory> ProductCategory { get; set; }
    }
}