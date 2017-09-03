using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyAspNetMvcApp.Areas.Account.ViewModels
{

    public class ManageUserViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please enter a valid email")]
        [Display(Name = "Email")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [System.Web.Mvc.Remote("CheckExistingEmail", "Account", ErrorMessage = "Email already exists")]
        public string UserName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 10)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone")]
        [System.Web.Mvc.Remote("CheckExistingPhoneNumber", "Account", ErrorMessage = "Phone number already exists")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Lastname")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Firstname")]
        public string FirstName { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public string Email { get; set; }

        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public string Code { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

}
