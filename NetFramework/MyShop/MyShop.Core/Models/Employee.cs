
namespace MyShop.Core.Models
{
   public class Employee : BaseEntity
    {
        public int FirstName { get; set; }
        public int LastName { get; set; }
        public int EmailAddress { get; set; }
        public int ContactNumber { get; set; }
        public int Department { get; set; }
    }
}
