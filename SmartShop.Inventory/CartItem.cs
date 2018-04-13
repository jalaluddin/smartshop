using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.Inventory
{
    public class CartItem
    {
        public Product Product { get; private set; }
        public int Quantity { get; private set; }
        public CartItem(Product product)
        {
            Product = product;
            Quantity = 1;
        }
        public CartItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
        public void IncreaseQuantity()
        {
            Quantity++;
        }
        public void DecreaseQuantity()
        {
            if (Quantity > 1)
            {
                Quantity--;
            }
            else
            {
                throw new Exception();
            }
            
        }
    }
}
