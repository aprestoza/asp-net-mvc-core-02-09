using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyShop.Core.Contracts;
using MyShop.Core.Models;
using MyShop.Core.ViewModels;

namespace MyShop.WebUI.Controllers
{
    public class EmployeeController : Controller
    {
        IRepository<Employee> context;
        public EmployeeController(IRepository<Employee> employeeContext)
        {
            this.context = employeeContext;
        }
        // GET: Employee
        public ActionResult Index()
        {
            //List<Employee> employees = context.Collection().ToList();
            List<Employee> employees = context.Collection().ToList();
            //Employee model = new Employee();
            return View(employees);
        }

        public ActionResult Create()
        {
            var model = new Employee();
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(Employee employee) {
            var model = new Employee();
            return View(model);

        }
        
    }
}