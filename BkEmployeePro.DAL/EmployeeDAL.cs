using System;
using System.Collections.Generic;
using BkEmployeePro.Domain;
using System.Data.Common;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;


namespace BkEmployeePro.DAL
{
    public class EmployeeDAL : IEmployeeDAL
    {

        #region GetEmployeeList
        public List<Employee> GetEmployeeList()
        {
            List<Employee> emp = new List<Employee>();

            try
            {
                Database db = DatabaseFactory.CreateDatabase("bkConnection");
                DbCommand dbcmd = db.GetStoredProcCommand("[dbo].[GetEmployee_sp]");
                using (IDataReader reader = db.ExecuteReader(dbcmd))
                {
                    while (reader.Read())
                    {
                        Employee empl = new Employee();
                        empl.EID = (reader.IsDBNull(reader.GetOrdinal("EID"))) ? 0 : reader.GetInt32(reader.GetOrdinal("EID"));
                        empl.Name = (reader.IsDBNull(reader.GetOrdinal("Name"))) ? string.Empty : reader.GetString(reader.GetOrdinal("Name"));
                        empl.Age = (reader.IsDBNull(reader.GetOrdinal("Age"))) ? 0 : reader.GetInt32(reader.GetOrdinal("Age"));
                        empl.Qualification = (reader.IsDBNull(reader.GetOrdinal("Qualification"))) ? string.Empty : reader.GetString(reader.GetOrdinal("Qualification"));
                        empl.Position = (reader.IsDBNull(reader.GetOrdinal("Position"))) ? string.Empty : reader.GetString(reader.GetOrdinal("Position"));
                        empl.JoiningDate = (reader.IsDBNull(reader.GetOrdinal("JoiningDate"))) ? DateTime.Now : reader.GetDateTime(reader.GetOrdinal("JoiningDate"));
                        empl.salary = (reader.IsDBNull(reader.GetOrdinal("Salary"))) ? 0 : reader.GetInt32(reader.GetOrdinal("Salary"));
                        
                        emp.Add(empl);
                    }
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return emp;
        }

        #endregion


        #region GetEmployeeByEID


        public Employee GetEmployeeByID(int EID)
        {
            Employee usr = null;
            try
            {
                Database db = DatabaseFactory.CreateDatabase("bkConnection");
                DbCommand dbcmd = db.GetStoredProcCommand("[dbo].[GetEmployeeByID_sp]");
                db.AddInParameter(dbcmd, "@EID", DbType.Int32, EID);

                using (IDataReader reader = db.ExecuteReader(dbcmd))
                {
                    if (reader.Read())
                    {
                        usr = new Employee();
                        usr.EID = (reader.IsDBNull(reader.GetOrdinal("EID"))) ? 0 : reader.GetInt32(reader.GetOrdinal("EID"));

                        usr.Name = reader.IsDBNull(reader.GetOrdinal("Name")) ? string.Empty : reader.GetString(reader.GetOrdinal("Name"));
                        usr.Age = reader.IsDBNull(reader.GetOrdinal("Age")) ? 0 : reader.GetInt32(reader.GetOrdinal("Age"));
                        usr.Qualification = (reader.IsDBNull(reader.GetOrdinal("Qualification"))) ? string.Empty : reader.GetString(reader.GetOrdinal("Qualification"));
                        usr.Position = (reader.IsDBNull(reader.GetOrdinal("Position"))) ? string.Empty : reader.GetString(reader.GetOrdinal("Position"));
                        usr.JoiningDate = (reader.IsDBNull(reader.GetOrdinal("JoiningDate"))) ? DateTime.Now : reader.GetDateTime(reader.GetOrdinal("JoiningDate"));
                        usr.salary = (reader.IsDBNull(reader.GetOrdinal("Salary"))) ? 0 : reader.GetInt32(reader.GetOrdinal("Salary"));


                    }
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return usr;
        }



        #endregion

        #region InsertUpdate
        public int InsertUpdateEmployee(Employee e)
        {
            int returnvalue = -1;

            Database db = DatabaseFactory.CreateDatabase("bkConnection");
            DbCommand dbcmd = db.GetStoredProcCommand("[dbo].[InsertUpEmployee]");

            try
            {

                if (e.EID > 0)
                {
                    db.AddInParameter(dbcmd, "@EID ", DbType.Int32, e.EID);
                }

                db.AddInParameter(dbcmd, "@Name", DbType.String, e.Name);
                db.AddInParameter(dbcmd, "@Age", DbType.Int32, e.Age);
                db.AddInParameter(dbcmd, "@Qualification", DbType.String, e.Qualification);
                db.AddInParameter(dbcmd, "@Position", DbType.String, e.Position);
                db.AddInParameter(dbcmd, "@JoiningDate", DbType.DateTime, e.JoiningDate);
                db.AddInParameter(dbcmd, "@Salary", DbType.Int32, e.salary);

                db.AddParameter(dbcmd, "@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, "", DataRowVersion.Default, null);

                db.ExecuteNonQuery(dbcmd);

                returnvalue = Convert.ToInt32(db.GetParameterValue(dbcmd, "ReturnValue"));

            }

            catch (Exception ex)
            {

                throw ex;
            }
            return returnvalue;
        }


        #endregion
 
        #region DeleteEmployee
        public int DeleteEmployee(int EID)
        {
            int x = -1;
            try
            {
                Database db = DatabaseFactory.CreateDatabase("bkConnection");
                DbCommand dbcmd = db.GetStoredProcCommand("[dbo].[DeleteEmployee]");

                db.AddInParameter(dbcmd, "@EID", DbType.Int32, EID);
                db.AddParameter(dbcmd, "@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, "", DataRowVersion.Default, null);
                x = db.ExecuteNonQuery(dbcmd);
                x = Convert.ToInt32(db.GetParameterValue(dbcmd, "@ReturnValue"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }
            return x;
        }





        #endregion
    }
}

