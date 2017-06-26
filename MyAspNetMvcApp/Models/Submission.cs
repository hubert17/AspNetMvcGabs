using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyAspNetMvcApp.Models
{
    public class Submission
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string PartnersName { get; set; }
        public string YearSection { get; set; }
        public string Link { get; set; }
        public string Notes { get; set; }
        public DateTime SubmitDate { get; set; }

        public int ProjectId { get; set; }
    }
}