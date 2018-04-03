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

    }
}