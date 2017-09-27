﻿using MyAspNetMvcApp.Areas.Account.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyAspNetMvcApp.Models.OrderApp
{
    public class Customer
    {
        [Key]
        public string UserName { get; set; }
        public UserProfile Profile { get; set; }
        public int Gender { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public int Province { get; set; }
    }
}