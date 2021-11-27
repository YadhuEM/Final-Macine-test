using System;
using System.Collections.Generic;

namespace TravellingApplicationNew.Models
{
    public partial class EmployeeRegistration
    {
        public EmployeeRegistration()
        {
            RequestTable = new HashSet<RequestTable>();
        }

        public int EmpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public decimal? PhoneNumber { get; set; }
        public int? UserId { get; set; }
        public bool? IsActive { get; set; }

        public virtual Login User { get; set; }
        public virtual ICollection<RequestTable> RequestTable { get; set; }
    }
}
