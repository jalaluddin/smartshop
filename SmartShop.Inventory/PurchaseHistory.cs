using SmartShop.Data;
using SmartShop.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.Inventory
{
    public class PurchaseHistory : Entity
    {
        public Product Product { get; set; }
        public ProductType ProductType { get; set; }
        public Customer Customer { get; set; }
        public int Quantity { get; set; }
        public double PurchasePrice { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
