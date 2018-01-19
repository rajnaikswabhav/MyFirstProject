using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employee_MVC_app.Models.ViewModel
{
    public class SearchVM
    {
        public string FName { get; set; }
        public double Salary { get; set; }
        public List<Employee> Employees { get; set; }
    }
}