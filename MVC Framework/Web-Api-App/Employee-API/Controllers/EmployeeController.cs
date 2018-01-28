using Employee_API.Models.DTO;
using EmployeeDTO_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Employee_API.Controllers
{
    [RoutePrefix("api/v1/Swabhav/Employee")]
    public class EmployeeController : ApiController
    {
        EmpService empService = new EmpService();

        [Route("GetAllEmployees")]
        public IHttpActionResult GetAllEmployees()
        {
            return Ok(empService.GetList());
        }

        [Route("GetEmployeeById/id")]
        public IHttpActionResult GetEmployeeById(Guid id)
        {
            return Ok(empService.GetEmployeeDTOById(id));
        }

        [Route("AddNewEmployee")]
        public IHttpActionResult PostAddNewEmployee(EmployeeDTO employeeDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Data");
            empService.AddEmployeeDTO(employeeDTO);
            return Ok("Employee SuccessFully Added");   
        }

        [Route("UpdateEmployeeDetails/id")]
        public IHttpActionResult PutUpdateEmployeeDetails(Guid id,EmployeeDTO newEmployeeDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Data");
            empService.UpdateEmployeeDTO(empService.GetEmployeeDTOById(id), newEmployeeDTO);
            return Ok("Employee SuccessFully updated");
        }

        [Route("DeleteEmployeeById/id")]
        public IHttpActionResult DeleteEmployeeById(Guid id)
        {
            empService.DeleteEmployeeDTO(id);
            return Ok("Employee Successfully Removed");
        }

        [Route("GetEmployeeByName/name")]
        public IHttpActionResult GetEmployeeByName(string name=null)
        {
            SearchEmployeeDTO searchEmployeeDTO = new SearchEmployeeDTO();
            if (name==null)
            {
                searchEmployeeDTO.Employees = empService.GetList();
            }
            else
            {
                var searchEmployees = empService.Search(name);
                searchEmployeeDTO.Employees = searchEmployees;
            }
            return Ok(searchEmployeeDTO.Employees);
        }
    }
}
