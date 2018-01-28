using Employee_API.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeDTO_API.Models
{
    public class EmpService
    {
            private static List<EmployeeDTO> empList = new List<EmployeeDTO>()
        {
                new EmployeeDTO {ID=Guid.NewGuid(),Name="Akshay",Salary=21500 },
                new EmployeeDTO {ID=Guid.NewGuid(),Name="Raj",Salary=21500 },
                new EmployeeDTO {ID=Guid.NewGuid(),Name="Suraj",Salary=24500 },
                new EmployeeDTO {ID=Guid.NewGuid(),Name="Omkar",Salary=20000 },
                new EmployeeDTO {ID=Guid.NewGuid(),Name="Prathmesh",Salary=30000 },
        };


            public List<EmployeeDTO> GetList()
            {
                return empList;
            }

            public void AddEmployeeDTO(EmployeeDTO EmployeeDTO)
            {
                EmployeeDTO.ID = Guid.NewGuid();
                empList.Add(EmployeeDTO);
            }

            public EmployeeDTO GetEmployeeDTOById(Guid id)
            {
                return empList.Where(e => e.ID == id).FirstOrDefault();
            }

            public void UpdateEmployeeDTO(EmployeeDTO oldEmployeeDTO, EmployeeDTO newEmployeeDTO)
            {
                empList.Where(e => e.ID == oldEmployeeDTO.ID)
                    .ToList().ForEach(c => {
                        if (newEmployeeDTO.Name != null) 
                            c.Name = newEmployeeDTO.Name;
                        if (newEmployeeDTO.Salary != null)
                            c.Salary = newEmployeeDTO.Salary;
                    });
            }

            public void DeleteEmployeeDTO(Guid id)
            {
                empList.Remove(empList.Where(e => e.ID == id).Select(e => e).FirstOrDefault());
            }

        public List<EmployeeDTO> Search(string name)
            {
               return empList.Where(e => e.Name.ToLower().Equals(name.ToLower())).ToList();
            }
        }
}