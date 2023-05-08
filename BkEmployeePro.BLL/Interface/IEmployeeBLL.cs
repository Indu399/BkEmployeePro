using BkEmployeePro.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BkEmployeePro.BLL
{
   public interface IEmployeeBLL
    {
        List<Employee> GetEmployeeList();
        Employee GetEmployeeByID(int EID);
        int InsertUpdateEmployee(Employee EID);
        int DeleteEmployee(int EID);

    }
}
