using Employee_MVC_app.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employee_MVC_app.Controllers
{
    public class EmployeeController : Controller
    {
        private EmpService empService = new EmpService();

        // GET: Employee
        public ActionResult Index()
        {
            return View(empService.GetList());
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            empService.AddEmployee(employee);
            return RedirectToAction("Index");      
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            return View(empService.GetEmployeeById(id));
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            empService.UpdateEmployee(employee);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            empService.DeleteEmployee(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Search()
        {
            SearchVM vm = new SearchVM();
            vm.Employees = empService.GetList();
            return View(vm);
        }

        [HttpPost]
        public ActionResult Search(SearchVM vm)
        {
            if (vm.FName==null && vm.Salary==0)
            {
                vm.Employees = empService.GetList();
            }
            else
            {
                var searchEmployees = empService.Search(vm);
                vm.Employees = searchEmployees;
            }
            return View(vm);
        }
    }
}