using BkEmployeePro.BLL;
using BkEmployeePro.Domain;
using BkEmployeePro.Models;
using Kendo.Mvc.UI;
using PagedList;
using PagedList.Mvc;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI;

namespace BkEmployeePro.Controllers
{
    public class EmployeeController : Controller
    {
        #region  GetEmployeeList
        private readonly IEmployeeBLL _employee = null;
        public EmployeeController(IEmployeeBLL employeeBLL)
        {
            _employee = employeeBLL;
        }
        // GET: Employee
      
        public ActionResult Index(string searchemployeestring ,string SortBy, int? Page, int? itemPerPage)
        {

            if (itemPerPage != null)  //for pagination
            {
                ViewBag.ItemPerPage = itemPerPage;
            }
            ViewBag.currentfilter = searchemployeestring;

            var employees = _employee.GetEmployeeList().Select(u => new UserInput
            {
                EID = u.EID,
                Name = u.Name,
                Age = u.Age,
                Qualification = u.Qualification,
                Position = u.Position,
                JoiningDate = u.JoiningDate,
                salary = u.salary,

            }).ToList();
            if (!string.IsNullOrEmpty(searchemployeestring)) // for searching the data based on Name and qualification
            {
                employees = employees.Where(l => l.Name.ToLower().Contains(searchemployeestring.ToLower()) || l.Qualification.ToLower().Contains(searchemployeestring.ToLower())).ToList();
            }

            //for pagination
            int pageSize = itemPerPage ?? 3;
            int pageNumber = (Page ?? 1);
            return View("_Registration", employees.ToPagedList(pageNumber, pageSize));
        }

        ////partialview
        //public ActionResult GetEmployeeList(string searchemployeestring)
        //{
        
        //    return View("_Employee", employees);
        //}
        #endregion

        #region Insert

        [HttpGet]

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Create(UserInput Input)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Employee e = new Employee();
                    e.EID = Input.EID;
                    e.Name = Input.Name;
                    e.Age = Input.Age;
                    e.Qualification = Input.Qualification;
                    e.Position = Input.Position;
                    e.JoiningDate = Input.JoiningDate;
                    e.salary = Input.salary;

                    int retVal = _employee.InsertUpdateEmployee(e);
                    //return View(retVal);
                    if (retVal == 0)
                    {
                        string msg = "Successfully added data";
                        return Json(new { status = 0 ,Message=msg}, JsonRequestBehavior.AllowGet);
                    }
                    
                }
                
            }
            catch (Exception ex)
            {


                string msg = "Error occured while Inserting the data";

                    return Json(new {ex, status = 1 ,Message=msg}, JsonRequestBehavior.AllowGet);
                
            }
            return Json(new { status = 0 }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Update

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            try
            {
                var emp = _employee.GetEmployeeByID(Id);
                UserInput data = new UserInput();
                data.EID = emp.EID;
                data.Name = emp.Name;
                data.Age = emp.Age;
                data.Qualification = emp.Qualification;
                data.Position = emp.Position;
                data.JoiningDate = emp.JoiningDate;
                data.salary = emp.salary;

              
                return View(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult Edit(UserInput input)
        {
            try
            {
                Employee employee = new Employee();
                employee.EID = input.EID;
                employee.Name = input.Name;
                employee.Age = input.Age;
                employee.Qualification = input.Qualification;
                employee.Position = input.Position;
                employee.JoiningDate = input.JoiningDate;
                employee.salary = input.salary;
                int returnVal = _employee.InsertUpdateEmployee(employee);
                // return RedirectToAction("Index");
                // return View(returnVal);
                if(returnVal==0)
                {
                    string msg = "Updated Successfully";
                    return Json(new { status = 0,Message=msg }, JsonRequestBehavior.AllowGet);
                }
            }
            catch(Exception ex)
            {
                string msg = "Error occured during updating the Employees";
               // MasterLog.Write(ex, 1, SeverityLevel.Critical, typeof(EmployeeController), System.Reflection.MethodBase.GetCurrentMethod(), System.Reflection.MethodBase.GetCurrentMethod().GetParameters(), msg);
                return Json(new { ex,status = 0, Message = msg }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { status = 0 }, JsonRequestBehavior.AllowGet);
            }
        #endregion

        #region DeleteEmployee

        public ActionResult DeleteEmployee(int id)
        {
            try
            {
                
                int retValue = _employee.DeleteEmployee(id);
               // return RedirectToAction("Index", "Employee");
               if(retValue==0)
                {
                    string msg = "Deleted Successfully";
                    return Json(new { status = 0 ,Message=msg}, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                string msg = "Error";
                return Json(new { status = 1, Message = msg,ex }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { status = 0 }, JsonRequestBehavior.AllowGet);
        }
        #endregion


        #region Details

        [HttpGet]
        public ActionResult Details(int Id)
        {
            try
            {
                var emp = _employee.GetEmployeeByID(Id);
                UserInput data = new UserInput();
                data.EID = emp.EID;
                data.Name = emp.Name;
                data.Age = emp.Age;
                data.Qualification = emp.Qualification;
                data.Position = emp.Position;
                data.JoiningDate = emp.JoiningDate;
                data.salary = emp.salary;


                return View(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult Details(UserInput input)
        {
            Employee employee = new Employee();
            employee.EID = input.EID;
            employee.Name = input.Name;
            employee.Age = input.Age;
            employee.Qualification = input.Qualification;
            employee.Position = input.Position;
            employee.JoiningDate = input.JoiningDate;
            employee.salary = input.salary;


            int returnVal = _employee.InsertUpdateEmployee(employee);
            return RedirectToAction("Index");
            // return View(returnVal);
        }
        #endregion

         }
}

