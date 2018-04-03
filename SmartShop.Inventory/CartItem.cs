using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.Inventory
{
    public class CartItem
    {
        public Product Item { get; private set; }
        public int Quantity { get; private set; }
        public CartItem(Product product)
        {
            Item = product;
            Quantity = 1;
        }
        public void IncreaseQuantity()
        {
            Quantity++;
        }
        public void DecreaseQuantity()
        {
            Quantity--;
        }
    }
}
