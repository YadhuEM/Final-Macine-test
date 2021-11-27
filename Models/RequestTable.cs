using System;
using System.Collections.Generic;

namespace TravellingApplicationNew.Models
{
    public partial class RequestTable
    {
        public int RequestId { get; set; }
        public string CauseTravel { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string Priority { get; set; }
        public string Mode { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public decimal? NoDays { get; set; }
        public int? ProjectId { get; set; }
        public int? EmpId { get; set; }
        public bool? IsActive { get; set; }

        public virtual EmployeeRegistration Emp { get; set; }
        public virtual ProjectTable Project { get; set; }
    }
}
