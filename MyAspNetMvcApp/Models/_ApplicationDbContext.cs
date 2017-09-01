using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MyAspNetMvcApp.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, 
    // please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        private string _userNameEmailBackingField;

        public override string UserName
        {
            get { return _userNameEmailBackingField; }
            set { _userNameEmailBackingField = value; }
        }

        public override string Email
        {
            get { return _userNameEmailBackingField; }
            set { _userNameEmailBackingField = value; }
        }

        public virtual UserProfile UserProfile { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("DbConnJetAccess")
        {
        }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //Put your database tables here...
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Submission> Submissions { get; set; }

        public DbSet<Book> Books { get; set; }
    }
}