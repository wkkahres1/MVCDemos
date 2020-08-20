using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity; //added this one
using System.ComponentModel.DataAnnotations; // added this for validation

namespace MVCSimpleApp.Models
{
    public class Employee
    {
        public int ID { get; set; }
        //Add these Annotation Attributes for validation

        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }

        [Display(Name = "Joining Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime JoiningDate { get; set; }

        [Range(22,60)]
        public int Age { get; set; }
    }

    //add this to connect to database
    //also need to specify the connection string under <configuration> tag for our database in Web.config
    public class EmpDBContext : DbContext
    {
        public EmpDBContext()
        { }
        public DbSet<Employee> Employees { get; set; } //entity you want to query and save
    }
}

//To update limitations on database, open PackageManger Window from Tools -> NuGet Package 
//Manager -> Package Manager Console
//
//Commands
//1. Enable-Migrations
//2. add-migration DataAnnotations
//3. update-database