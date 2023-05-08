using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BkEmployeePro.Domain
{
  public  class Employee
    {
        public int EID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Qualification { get; set; }
        public string Position { get; set; }
        public DateTime JoiningDate { get; set; }
        public int salary { get; set; }

    }
}
