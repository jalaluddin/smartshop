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
                SessionHelper.Cart.AddItem(item);
            }
        }

        public void ResetCart()
        {
            new ShoppingCart().ClearCart();
        }
    }
}