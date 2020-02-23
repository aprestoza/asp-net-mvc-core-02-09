
using System.ComponentModel;

namespace MyShop.Core.Models
{
   public class Employee : BaseEntity
    {
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Email")]
        public string EmailAddress { get; set; }
        [DisplayName("Contact Number")]
        public string ContactNumber { get; set; }
        public string Department { get; set; }
    }
}
