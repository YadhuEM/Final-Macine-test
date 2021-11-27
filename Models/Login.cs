using System;
using System.Collections.Generic;

namespace TravellingApplicationNew.Models
{
    public partial class Login
    {
        public Login()
        {
            EmployeeRegistration = new HashSet<EmployeeRegistration>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public int? RoleId { get; set; }
        public bool? IsActive { get; set; }

        public virtual Roles Role { get; set; }
        public virtual ICollection<EmployeeRegistration> EmployeeRegistration { get; set; }
    }
}
