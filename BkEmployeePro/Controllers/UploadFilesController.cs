using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BkEmployeePro.Controllers
{
    public class UploadFilesController : Controller
    {

        [HttpGet]
        public ActionResult UploadFile()
        {


            return View();
        }
        [HttpPost]
        public ActionResult UploadFile(List<HttpPostedFileBase> FileData)
        {
            string path = Server.MapPath("~/UploadFiles/");
            foreach (HttpPostedFileBase uploadfile in FileData)
            {
                if (uploadfile != null)
                {
                    string fileName = Path.GetFileName(uploadfile.FileName);
                    uploadfile.SaveAs(path + fileName);
                }
            }
            return View();
        }
    }
}

       
        
