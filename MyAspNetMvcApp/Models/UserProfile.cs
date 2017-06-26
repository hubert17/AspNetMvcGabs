﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyAspNetMvcApp.Models
{
    public class UserProfile
    {
        [Key]
        public string UserName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string AltEmail { get; set; }

        public DateTime? LastLogin { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public bool? InActive { get; set; }

    }


}