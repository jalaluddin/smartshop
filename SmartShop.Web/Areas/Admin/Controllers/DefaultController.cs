using Microsoft.AspNet.Identity.Owin;
using SmartShop.Web.Controllers;
using SmartShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SmartShop.Web.Areas.Admin.Controllers
{
    public class DefaultController : AccountController
    {
        [AllowAnonymous]
        public override ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public override async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await UserManager.FindByNameAsync(model.Username);

            if (!await UserManager.IsInRoleAsync(user.Id, "Admin"))
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, shouldLockout: false);

            

            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl ?? "/Admin/Dashboard/Index");
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }
    }
}