using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SmartShop.Web.Models
{
    public class AreaAuthorizationAttribute : AuthorizeAttribute
    {
        protected enum FailType
        {
            None,
            NotLoggedIn,
            InsufficientPermission,
            NotOfUserType,
            NotInRole
        }

        public string Url { get; set; }

        public string Permissions
        {
            get;
            set;
        }

        public string UserType
        {
            get;
            set;
        }

        public string SessionItemName
        {
            get;
            set;
        }

        protected FailType CauseOfFailure
        {
            get;
            set;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            List<string> roles = SplitItems(Roles);
            List<string> permissions = SplitItems(Permissions);
            List<string> userTypes = SplitItems(UserType);

            var sessionItemName = string.IsNullOrWhiteSpace(SessionItemName) ? "CurrentUser" : SessionItemName;

            UserIdentity user = (UserIdentity)httpContext.Session[sessionItemName];
            if (user == null)
            {
                CauseOfFailure = FailType.NotLoggedIn;
                return false;
            }
            else
            {
                if (!user.CheckUserType(userTypes.ToArray<string>()))
                {
                    CauseOfFailure = FailType.NotOfUserType;
                    return false;
                }
                else if (!user.CheckPermission(permissions.ToArray<string>()))
                {
                    CauseOfFailure = FailType.InsufficientPermission;
                    return false;
                }
                else if (!user.CheckRole(roles.ToArray<string>()))
                {
                    CauseOfFailure = FailType.NotInRole;
                    return false;
                }
                else
                {
                    CauseOfFailure = FailType.None;
                    return true;
                }
            }
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            bool skipAuthorization = filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), inherit: true)
                          || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), inherit: true);

            if (skipAuthorization)
            {
                return;
            }

            base.OnAuthorization(filterContext);

            if (CauseOfFailure == FailType.NotLoggedIn)
            {
                filterContext.Result = new RedirectResult(Url + "?ReturnUrl=" + filterContext.HttpContext.Request.RawUrl);
            }
            else if (CauseOfFailure == FailType.NotInRole || CauseOfFailure == FailType.InsufficientPermission ||
                CauseOfFailure == FailType.NotOfUserType)
            {
                if (filterContext.Result is HttpUnauthorizedResult)
                {
                    filterContext.Result = new RedirectToRouteResult(
                      new RouteValueDictionary {
                      { "area", HttpContext.Current.Request.RequestContext.RouteData.DataTokens["area"] },
                      { "controller", "Error" },
                      { "action", "AccessDenied" },
                      { "ReturnUrl", filterContext.HttpContext.Request.RawUrl }
                    });
                }
            }
        }

        protected List<string> SplitItems(string item)
        {
            List<string> filteredItems = new List<string>();
            List<string> items = new List<string>();
            if (!string.IsNullOrEmpty(item) && !string.IsNullOrWhiteSpace(item))
                items = item.Split(',').ToList<string>();

            foreach (var splittedItem in items)
            {
                string filteredItem = splittedItem.Trim();
                if (!string.IsNullOrEmpty(filteredItem))
                    filteredItems.Add(filteredItem);
            }

            return filteredItems;
        }
    }
}