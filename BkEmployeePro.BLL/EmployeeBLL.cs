using BkEmployeePro.DAL;
using BkEmployeePro.DAL.Factory;
using BkEmployeePro.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BkEmployeePro.BLL
{
   public class EmployeeBLL:IEmployeeBLL
    {
        #region GetEmployeeList
        public List<Employee> GetEmployeeList()
        {
            List<Employee> employess = null;
            try
            {
                IEmployeeDAL eDAL = BkEmployeeProFactory.CreateEmployeeDAL();
                employess = eDAL.GetEmployeeList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return employess;
        }
        #endregion

        #region   GetEmployeeByID
        public Employee GetEmployeeByID(int EID)
        {
            Employee emp = null;
            try
            {
                IEmployeeDAL eDAL = BkEmployeeProFactory.CreateEmployeeDAL();
                emp = eDAL.GetEmployeeByID(EID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return emp;
        }
        #endregion

        #region InsertUpdateEmployee
        public int InsertUpdateEmployee(Employee EID)
        {
            int retValue = -1;
            try
            {
                IEmployeeDAL sDAL = BkEmployeeProFactory.CreateEmployeeDAL();
                retValue = sDAL.InsertUpdateEmployee(EID);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retValue;
        }
        #endregion

        #region DeleteEmployee

        public int DeleteEmployee(int EID)
        {
            int retValue = -1;
            try
            {
                IEmployeeDAL sDAL = BkEmployeeProFactory.CreateEmployeeDAL();
                retValue = sDAL.DeleteEmployee(EID);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retValue;
        }
        #endregion

    }
}
