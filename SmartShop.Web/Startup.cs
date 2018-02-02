using System;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SmartShop.Web.Startup))]
namespace SmartShop.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateInitialRolesAndAdminUser();
        }
    }
}
