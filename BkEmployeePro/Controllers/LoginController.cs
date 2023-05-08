using BkEmployeePro.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BkEmployeePro.Controllers
{
    public class LoginController : Controller
    {



        private readonly ILoginBLL _l = null;
        public LoginController(ILoginBLL loginBLL)
        {
            _l = loginBLL;
        }
       
        [HttpGet]
        public ActionResult Login()
        {
            //LoginViewModel si = new LoginViewModel();
            //si.ReturnUrl = ReturnUrl;

            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(string UserName, string Password)
        {
            int y = _l.Login(UserName, Password);
            if (y == 0)
            {
                return Json(new { Status = 0, message = "You Logged Successfully" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { Status = 1, message = "Invalid Email and Password" }, JsonRequestBehavior.AllowGet);
            }
           
        }

    }
}