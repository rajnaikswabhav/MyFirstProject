using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employee_API.Models.DTO
{
    public class SearchEmployeeDTO
    {
        public List<EmployeeDTO> Employees { get; set; }
    }
}