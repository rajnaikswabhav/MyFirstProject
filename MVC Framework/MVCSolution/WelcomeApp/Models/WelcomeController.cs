using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WelcomeApp.Models.ViewModel;

namespace WelcomeApp.Controllers
{
    public class WelcomeController:Controller
    {
        public string Index()
        {
            return "<h1>Welcome to MVC</h1>";
        }

        public string GetEmp(int? id)
        {
            return "Get Employee Details of "+id;
        }

        public ActionResult SayHello(string name)
        {
            return Content("Hello " + name);
        }

        public ActionResult Browse()
        {
            ViewBag.Message = "Hello Swabhav";
            return View();
        }

        public ActionResult DisplayEmp()
        {
            DisplayEmpVM vm = new DisplayEmpVM() { Name="Raj",Salary=15000,DateOfHire="14-April-2017"};
            return View(vm);
        }

        public ActionResult DisplayEmps()
        {
            var Employees = new List<DisplayEmpVM>
            {
                new DisplayEmpVM { Name="Raj",Salary=20000,DateOfHire="14-April-2017" },
                new DisplayEmpVM { Name="Akshay",Salary=20000,DateOfHire="14-April-2017" },
                new DisplayEmpVM { Name="Omkar",Salary=15000,DateOfHire="12-Jan-2019" },
                new DisplayEmpVM { Name="Prathmesh",Salary=25000,DateOfHire="11-Mar-2016"}
            };
            return View(Employees);
        }

        public ActionResult DisplayEmpJson()
        {
            DisplayEmpVM emp = new DisplayEmpVM { Name = "Raj", Salary = 20000, DateOfHire = "14-April-2017" };
            return Json(emp,JsonRequestBehavior.AllowGet);

        }

        public ActionResult Swabhav()
        {
            return Redirect("http://swabhavtechlabs.com");
        }
    }
}