using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Website_EcommerceShoe_ASPNETMVC.Startup))]
namespace Website_EcommerceShoe_ASPNETMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
