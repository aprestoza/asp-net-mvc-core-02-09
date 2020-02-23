using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.ViewModels
{
    public class EmployeeViewModel
    {
        public Employee Employee { get; set; }
        public IEnumerable<Employee> EmployeeList { get; set; }
    }
}
