using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Omnimerit.Data;
using Omnimerit.Data.BussinessLayer;
using Omnimerit.Data.Model.Database;



namespace Omnimerit_Portal.Employee
{
    public class EmployeeController : Controller
    {
        // GET: Employee
    
        public ActionResult Index()
        {

            ViewBag.user = "Employee";
            return View();
        }
        public ActionResult Employee()
        {

            ViewBag.user = "Employee";
            return View();
        }
        public ActionResult LessonPlanning()
        {

            return PartialView("LessonPlanning");
        }
       
        public ActionResult Circular()
        {
            return PartialView("Circular");
        }


        public ActionResult AccountGroup()
        {
            return PartialView("AccountGroup");
        }
       
      
        public ActionResult VoucherHead()
        {
            return PartialView("VoucherHead");
        }
        public ActionResult ActiveTimeTable()
        {

            return PartialView("ActiveTimeTable");
        }
        public ActionResult SetTimeTable()
        {
            return PartialView("SetTimeTable");
        }


        #region AccountGroup
        [HttpGet]
        public JsonResult ShowResult()
        {

            Business result = new Business();

            return Json(result.ShowResult(), JsonRequestBehavior.AllowGet);

        }
        #endregion AccountGroup


        #region Circular
        [HttpPost]
        public ActionResult AddCircular(Circular circular)
        {

            Business bussiness = new Business();
            bussiness.AddCircular(circular);
            return PartialView("Circular");
        }

        public JsonResult GetCircular()
        {

            Business result = new Business();

            return Json(result.GetCircular(), JsonRequestBehavior.AllowGet);

        }
        #endregion Circular

    }
}