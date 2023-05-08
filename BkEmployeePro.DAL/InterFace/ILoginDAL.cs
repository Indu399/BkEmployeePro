using BkEmployeePro.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BkEmployeePro.DAL
{
  public  interface ILoginDAL
    {

        int Login(string UserID, string Password); 
    }
}
