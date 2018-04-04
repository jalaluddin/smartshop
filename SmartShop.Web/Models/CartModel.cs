using SmartShop.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartShop.Web.Models
{
    public class CartModel
    {
        public void AddProductToCart(Guid? productID)
        {
            if (productID.HasValue)
            {
                var product = new ProductManagementService().GetProductDetails(productID.Value);
                CartItem item = new CartItem(product);
                SessionHelper.ShoppingCart.AddItem(item);
            }
        }

        public void ResetCart()
        {
            SessionHelper.ShoppingCart.ClearCart();
        }

        public void DecreaseQuantity(Guid? id)
        {
            if (id.HasValue)
            {
                SessionHelper.ShoppingCart.DecreaseQuantityOfItem(id.Value);
            }
        }

        public void IncreaseQuantity(Guid? id)
        {
            if (id.HasValue)
            {
                SessionHelper.ShoppingCart.IncreaseQuantityOfItem(id.Value);
            }
        }

        public void RemoveCartItem(Guid? id)
        {
            if (id.HasValue)
            {
                SessionHelper.ShoppingCart.RemoveItem(id.Value);
            }
        }
    }
}