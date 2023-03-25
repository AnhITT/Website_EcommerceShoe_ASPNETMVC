using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System.Web.Helpers;
using Website_EcommerceShoe_ASPNETMVC.Models;

[assembly: OwinStartupAttribute(typeof(Website_EcommerceShoe_ASPNETMVC.Startup))]
namespace Website_EcommerceShoe_ASPNETMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
            this.CreateRolesandUsers();
            ConfigureAuth(app);
        }
        public void CreateRolesandUsers()
        {
            var rolemanager = new RoleManager<IdentityRole>
                (new RoleStore<IdentityRole>(new ApplicationDbContext()));
            var appDbContext = new ApplicationDbContext();
            var appUserStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(appUserStore);
            var passwdHash = Crypto.HashPassword("A@admin123");

            //Tao role Admin
            if (!rolemanager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                rolemanager.Create(role);
            }
            //Tao acc Admin
            if (userManager.FindByName("admin") == null)
            {
                var user = new ApplicationUser { 
                    //UserName = "admin",
                    //Email = "admin@gmail.com",
                    //PasswordHash = passwdHash,
                    
                };
                user.UserName = "admin@gmail.com";
                user.Email = "admin@gmail.com";
                string userPwd = "A@admin123";
                var chkUser = userManager.Create(user, userPwd);
                if (chkUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admin");
                }
            }
            //Tao Role User
            if (!rolemanager.RoleExists("User"))
            {
                var role = new IdentityRole();
                role.Name = "User";
                rolemanager.Create(role);
            }
        }
    }
}
