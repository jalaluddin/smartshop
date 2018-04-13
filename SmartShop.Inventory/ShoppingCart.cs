using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.Inventory
{
    public class ShoppingCart
    {
        public List<CartItem> CartItems { get; private set; }
        public double TotalAmount
        {
            get
            {
                return CartItems.Sum(x => (x.Product.SpecialPrice == 0 ? x.Product.Price : x.Product.SpecialPrice) * x.Quantity);
            }
        }

        public ShoppingCart()
        {
            CartItems = new List<CartItem>();
        }
        public void RemoveItem(Guid productID)
        {
            var item = CartItems.Where(x => x.Product.ID == productID).FirstOrDefault();
            CartItems.Remove(item);
        }
        public void AddItem(CartItem cartItem)
        {
            var item = CartItems.Where(x => x.Product.ID == cartItem.Product.ID).FirstOrDefault();
            if (item != null)
            {
                item.IncreaseQuantity();
            }
            else
            {
                CartItems.Add(cartItem);
            }

        }
        public void IncreaseQuantityOfItem(Guid id)
        {
            var item = CartItems.Where(x => x.Product.ID == id).FirstOrDefault();
            if (item != null)
            {
                item.IncreaseQuantity();
            }

        }
        public void DecreaseQuantityOfItem(Guid id)
        {
            var item = CartItems.Where(x => x.Product.ID == id).FirstOrDefault();
            if (item != null)
            {
                try
                {
                    item.DecreaseQuantity();
                }
                catch
                {
                    RemoveItem(id);
                }
                
            }

        }
        public void ClearCart()
        {
            CartItems = new List<CartItem>();
        }
    }
}
