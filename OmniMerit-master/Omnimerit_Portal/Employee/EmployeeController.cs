using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Omnimerit.Data;
using Omnimerit.Data.BussinessLayer;
using Omnimerit.Data.Model.Database;
using Newtonsoft.Json;

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
        [HttpPost]
        public ActionResult AddAccountGroup(AccountGroup entity)
        { 
            Business bussiness = new Business();
            entity.Status = "ACTIVE";
            if (entity.Id == 0)
                bussiness.Add<AccountGroup>(entity);
            else
                bussiness.Update<AccountGroup>(entity);
           
            return PartialView("AccountGroup");
        }

        [HttpPost]
        public JsonResult DeleteAccountGrp(string Id)
        {
            AccountGroup c = new AccountGroup();
            c.Id = Convert.ToInt16(Id);
            Business bussiness = new Business();
            bussiness.Delete<AccountGroup>(c);

            return Json("", JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public JsonResult GetAccountGroup()
        {

            Business result = new Business();

            return Json(result.Retrieve<AccountGroup>(), JsonRequestBehavior.AllowGet);

        }
        #endregion AccountGroup


        #region Circular
        [HttpPost]
        public ActionResult AddCircular(Circular circular)
        {

            Business bussiness = new Business();
            bussiness.Add<Circular>(circular);
            return PartialView("Circular");
        }
        [HttpGet]
        public JsonResult GetCircular()
        {

            Business business = new Business();
            var list = JsonConvert.SerializeObject(business.Retrieve<Circular>(), Formatting.None, new JsonSerializerSettings()
            {
                DateFormatString = "yyyy-MM-dd",
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });
            return Json(list, JsonRequestBehavior.AllowGet);

        }
        public ActionResult EditCircular(string id)
       {
           return PartialView("Circular");
       }
        #endregion Circular

    }
}