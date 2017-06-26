using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyAspNetMvcApp.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }

        public static string getProjectName(int Id)
        {
            var db = new ApplicationDbContext();
            return db.Projects.Find(Id).Name;
        }
    }
   
}