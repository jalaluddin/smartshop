using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.Inventory
{
    public class ShoppingCart
    {
        public List<CartItem> Items { get; private set; }
        public double TotalAmount
        {
            get
            {
                return Items.Sum(x => (x.Item.SpecialPrice == 0 ? x.Item.Price : x.Item.SpecialPrice) * x.Quantity);
            }
        }

        public ShoppingCart()
        {
            Items = new List<CartItem>();
        }
        public void RemoveItem(Guid productID)
        {
            var item = Items.Where(x => x.Item.ID == productID).FirstOrDefault();
            Items.Remove(item);
        }
        public void AddItem(CartItem cartItem)
        {
            var item = Items.Where(x => x.Item.ID == cartItem.Item.ID).FirstOrDefault();
            if (item != null)
            {
                item.IncreaseQuantity();
            }
            else
            {
                Items.Add(cartItem);
            }

        }
        public void ClearCart()
        {
            Items = new List<CartItem>();
        }
    }
}
