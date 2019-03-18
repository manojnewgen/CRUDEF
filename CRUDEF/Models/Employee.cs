using System;
using System.Collections.Generic;

namespace CRUDEF.Models
{
    public partial class Employee
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }

        public Department Department { get; set; }
    }
}
