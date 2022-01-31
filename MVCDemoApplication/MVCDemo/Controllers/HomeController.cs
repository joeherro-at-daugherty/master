using MVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary;
using DataLibrary.BusinessLogic;

namespace MVCDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ViewEmployees()
        {
            ViewBag.Message = "Employees List";

            var data = EmployeeProcessor.LoadEmployees();
            List<EmployeeModel> employees = new List<EmployeeModel>();

            foreach (var row in data)
            {
                employees.Add(new EmployeeModel
                {
                    EmployeeId = row.EmployeeId,
                    FirstName = row.FirstName,
                    LastName = row.LastName,
                    EmailAddress = row.EmailAddress,
                    ConfirmEmail = row.EmailAddress
                });
            }

            return View(employees);
        }

        public ActionResult SignUp()
        {
            ViewBag.Message = "Employee Sign Up.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(EmployeeModel employee)
        {
            //does the model comply with all of the rules?
            if (ModelState.IsValid)
            {
                int recordsAffected = EmployeeProcessor.CreateEmployee(employee.EmployeeId, employee.FirstName, employee.LastName, employee.EmailAddress);
                RedirectToAction("Index");
            }

            return View();
        }
    }
}