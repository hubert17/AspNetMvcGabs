namespace MyAspNetMvcApp.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MyAspNetMvcApp.Models;
    using MyAspNetMvcApp.Areas.Account.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using MyAspNetMvcApp.Areas.App.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            SeedIdentity(context);
            SeedLookup(context);

        }

        private void SeedLookup(ApplicationDbContext context)
        {
            context.Lookups.AddOrUpdate(
              p => p.Key,
                new Lookup { Type = "gender", Key = 1, Value = "Male" },
                new Lookup { Type = "gender", Key = 2, Value = "Female" }
            );

        }

        private void SeedIdentity(ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (!context.Roles.Any(r => r.Name == "admin"))
            {
                roleManager.Create(new IdentityRole("admin"));
            }

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var username = System.Configuration.ConfigurationManager.AppSettings["AdminUsername"];
            if ((userManager.FindByName(username) == null))
            {

                var user = new ApplicationUser
                {
                    UserName = username,
                    PhoneNumber = "1234567890",
                    UserProfile = new UserProfile { UserName = username, LastName = "Admin", FirstName = "Temp", RegistrationDate = DateTime.Now, InActive = false }
                };
                userManager.Create(user, System.Configuration.ConfigurationManager.AppSettings["AdminPassword"]);
                userManager.AddToRole(user.Id, "admin");


            }
            username = System.Configuration.ConfigurationManager.AppSettings["TempUsername"];
            if ((userManager.FindByName(username) == null))
            {
                var user = new ApplicationUser
                {
                    UserName = username,
                    PhoneNumber = "9876543210",
                    UserProfile = new UserProfile { UserName = username, LastName = "User", FirstName = "Temp", RegistrationDate = DateTime.Now, InActive = false }
                };
                userManager.Create(user, System.Configuration.ConfigurationManager.AppSettings["TempPassword"]);
            }

        }

    }
}
