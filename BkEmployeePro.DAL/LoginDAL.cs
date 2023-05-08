using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace BkEmployeePro.DAL
{
   public class LoginDAL:ILoginDAL
    {
        public int Login(string UserName,string Password)
        {
            int y = -1;
            try
            {
                Database db = DatabaseFactory.CreateDatabase("bkConnection");
                DbCommand dbcmd = db.GetStoredProcCommand("Login_sp");
                db.AddInParameter(dbcmd, "@UserName", DbType.String,UserName);
                db.AddInParameter(dbcmd, "@Password", DbType.String, Password);
                db.AddParameter(dbcmd, "@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, "", DataRowVersion.Current, null);

                using (IDataReader reader = db.ExecuteReader(dbcmd))
                {
                    while (reader.Read())
                    {
                        y = 0;
                    }
                }

            }
            catch (Exception ex) { throw ex; }
            return y;

        }


    }
}
