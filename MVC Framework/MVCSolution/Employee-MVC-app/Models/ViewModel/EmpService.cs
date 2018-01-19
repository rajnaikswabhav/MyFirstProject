using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employee_MVC_app.Models.ViewModel
{
    public class EmpService
    {
        private static List<Employee> empList= new List<Employee>()
        {
                new Employee {ID=Guid.NewGuid(),Name="Akshay",Salary=21500 },
                new Employee {ID=Guid.NewGuid(),Name="Raj",Salary=21500 },
                new Employee {ID=Guid.NewGuid(),Name="Suraj",Salary=24500 },
                new Employee {ID=Guid.NewGuid(),Name="Omkar",Salary=20000 },
                new Employee {ID=Guid.NewGuid(),Name="Prathmesh",Salary=30000 },
        };
        

        public List<Employee> GetList()
        {
            return empList;
        }

        public void AddEmployee(Employee employee)
        {
                employee.ID = Guid.NewGuid();
                empList.Add(employee);
        }

        public Employee GetEmployeeById(Guid id)
        {
            return empList.Where(e => e.ID == id).FirstOrDefault();
        }

        public void UpdateEmployee(Employee employee)
        {
            empList.Where(e => e.ID == employee.ID)
                .ToList().ForEach(c => {
                    c.Name = employee.Name;
                    c.Salary = employee.Salary;
                });
        }

        public void DeleteEmployee(Guid id)
        {
            empList.Remove(empList.Where(e => e.ID == id).Select(e => e).FirstOrDefault());
        }

        public List<Employee> Search(SearchVM vm)
        {
            return empList.Where(e => e.Name.Equals(vm.FName) || e.Salary>vm.Salary).ToList();
        }


    }
}