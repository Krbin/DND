using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Models.Employee
{
    internal abstract class Employee
    {
        public int EmployeeId { get; set; }
        public string Filename { get; set; }
        public string Name { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
