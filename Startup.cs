using lsad.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(lsad.Startup))]
namespace lsad
{
    public partial class Startup
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRoles();
            CreateUsers();
        }
        public void CreateUsers()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = new ApplicationUser();
            user.Email = "yazanalkhatib956@gmail.com";
            user.UserName = "yazanalkhatib";
            var check = userManager.Create(user,"YAZANk98!");
            if (check.Succeeded)
            {
                userManager.AddToRole(user.Id, "Admins");
            }
        }
        public void CreateRoles()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            IdentityRole role;
            if (!roleManager.RoleExists("Admins"))
            {
                role = new IdentityRole();
                role.Name = "Admins";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("Seller"))
            {
                role = new IdentityRole();
                role.Name = "Seller";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("Customor"))
            {
                role = new IdentityRole();
                role.Name = "Customor";
                roleManager.Create(role);
            }
        }
    }
}
