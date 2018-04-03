using SmartShop.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartShop.Web.Models
{
    public static class SessionHelper
    {
        public static ShoppingCart Cart
        {
            get
            {
                var cart = (ShoppingCart)HttpContext.Current.Session["Cart"];
                if (cart == null)
                {
                    cart = new ShoppingCart();
                    HttpContext.Current.Session["Cart"] = cart;
                }
                return cart;
            }
        }
    }
}