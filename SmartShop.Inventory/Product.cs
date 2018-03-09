using SmartShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.Inventory
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        public double SpecialPrice { get; set; }
        public int Quantity { get; set; }
        public ProductType Type { get; set; }
        public List<ProductImage> Images { get; set; }
        public ProductImage FeaturedImage { get; set; }
        public string Description { get; set; }
        public List<ProductReviews> ProductReviews { get; set; }
        public ProductAdditionalInformation ProductAdditionalInformation { get; set; }
        public bool IsNew { get; set; }


    }
}
