using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MyAspNetMvcApp.Areas.Account.Models
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

        public string PasswordResetCode { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}