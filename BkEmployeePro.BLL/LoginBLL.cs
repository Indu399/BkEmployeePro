using BkEmployeePro.DAL;
using BkEmployeePro.DAL.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BkEmployeePro.BLL
{
  public class LoginBLL:ILoginBLL
    {

        #region UserLogin

        public int Login(string UserName,string Password)
        {
            int y = -1;

            try
            {
                ILoginDAL lDAL = BkEmployeeProFactory.CreateLoginDAL();
                y = lDAL.Login(UserName, Password);  
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return y;

        }
        #endregion

    }
}
