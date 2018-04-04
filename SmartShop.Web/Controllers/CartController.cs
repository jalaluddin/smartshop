using SmartShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartShop.Web.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult AddProduct(Guid? id)
        {
            new CartModel().AddProductToCart(id);
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult ResetCart()
        {
            new CartModel().ResetCart();
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult MinusQuantity(Guid? id)
        {
            new CartModel().DecreaseQuantity(id);
            return Redirect("/Checkout");
        }

        public ActionResult PlusQuantity(Guid? id)
        {
            new CartModel().IncreaseQuantity(id);
            return Redirect("/Checkout");
        }
        public ActionResult RemoveItem(Guid? id)
        {
            new CartModel().RemoveCartItem(id);
            return Redirect("/Checkout");
        }

    }
}