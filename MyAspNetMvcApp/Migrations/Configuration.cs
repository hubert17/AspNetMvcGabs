namespace MyAspNetMvcApp.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MyAspNetMvcApp.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyAspNetMvcApp.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MyAspNetMvcApp.Models.ApplicationDbContext context)
        {
            SeedIdentity(context);
        }

        private void SeedIdentity(MyAspNetMvcApp.Models.ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (!context.Roles.Any(r => r.Name == "admin"))
            {
                roleManager.Create(new IdentityRole("admin"));
            }

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var username = "admin1";
            if ((userManager.FindByName(username) == null))
            {
                
                var user = new ApplicationUser
                {
                    UserName = username,
                    UserProfile = new UserProfile { UserName = username, LastName = "Admin", FirstName = "Admin", RegistrationDate = DateTime.Now, InActive = false}
                };
                userManager.Create(user, "password1");
                userManager.AddToRole(user.Id, "admin");


            }
            username = "user1";
            if ((userManager.FindByName(username) == null))
            {
                var user = new ApplicationUser
                {
                    UserName = username,
                    UserProfile = new UserProfile { UserName = username, LastName= "User", FirstName = "User", RegistrationDate = DateTime.Now, InActive = false}
                };
                userManager.Create(user, "userpass1");
            }

        }

    }
}
