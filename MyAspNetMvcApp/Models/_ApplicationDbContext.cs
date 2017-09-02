using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MyAspNetMvcApp.Areas.Account.Models;

namespace MyAspNetMvcApp.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("DbConnJetAccess")
        {
        }

        // DO NOT REMOVE THIS!
        public DbSet<UserProfile> UserProfiles { get; set; }

        // Put your database tables here...
        public DbSet<Project> Projects { get; set; }
        public DbSet<Submission> Submissions { get; set; }
        public DbSet<Book> Books { get; set; }

    }
}