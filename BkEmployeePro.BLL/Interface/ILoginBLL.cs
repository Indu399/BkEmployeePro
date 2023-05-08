using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BkEmployeePro.BLL
{
  public  interface ILoginBLL
    {
        int Login(string UserID, string Password);
    }
}
