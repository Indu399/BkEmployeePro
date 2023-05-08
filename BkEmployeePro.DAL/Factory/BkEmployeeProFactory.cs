
using BkEmployeePro.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BkEmployeePro.DAL.Factory
{
  public class BkEmployeeProFactory
    {
        private BkEmployeeProFactory() { }

        public static IEmployeeDAL CreateEmployeeDAL()
        {
            IEmployeeDAL employeeDAL = new EmployeeDAL();
            return employeeDAL;
        }
        public static ILoginDAL CreateLoginDAL()
        {
            ILoginDAL lDAL = new LoginDAL();
            return lDAL;
        }
    }
}
