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
            IEnumerable<Employee> employees = context.Collection().ToList();
            //Employee model = new Employee();
            return View(employees);
        }

        public ActionResult Create()
        {
            EmployeeViewModel viewModel = new EmployeeViewModel();
            viewModel.Employee = new Employee();
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Create(Employee employee) {

            if (!ModelState.IsValid)
            {
                return View(employee);
            }
            else
            {
                context.Insert(employee);
                context.Commit();
            }
            return RedirectToAction("Index");

        }
      public ActionResult Edit(string Id)
        {
            Employee employee = context.Find(Id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            else
            {
                EmployeeViewModel viewModel = new EmployeeViewModel();

                viewModel.Employee = employee;
                
                return View(viewModel);
            }
        }

        [HttpPost]
        public ActionResult Edit(Employee employee, string Id)
        {
            var employeeEdit = context.Find(Id);
            
            if (employeeEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(employee);
                }
                employeeEdit.FirstName = employee.FirstName;
                employeeEdit.LastName = employee.LastName;
                employeeEdit.EmailAddress = employee.EmailAddress;
                employeeEdit.ContactNumber = employee.ContactNumber;
                employeeEdit.Department = employee.Department;
                context.Commit();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string Id)
        {
            Employee employee = context.Find(Id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(employee);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Employee employee = context.Find(Id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                context.Commit();
                return RedirectToAction("Index");
            }

        }

    }
}