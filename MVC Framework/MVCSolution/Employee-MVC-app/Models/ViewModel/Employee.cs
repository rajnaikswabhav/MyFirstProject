using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Employee_MVC_app.Models.ViewModel
{
    public class Employee
    {
        public Guid ID { get; set; }

        [Required(ErrorMessage ="Name is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Salary  is Required")]
        public int Salary { get; set; }
    }
}