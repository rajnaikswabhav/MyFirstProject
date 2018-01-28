using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employee_API.Models.DTO
{
    public class EmployeeDTO
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
    }
}