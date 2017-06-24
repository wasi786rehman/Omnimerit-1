using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Omnimerit.Data;
using Omnimerit.Data.BussinessLayer;
using Omnimerit.Data.Model.Database;
using Newtonsoft.Json;
using Omnimerit_Portal.Models;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI;

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
        public ActionResult FeeCategory()
        {
            return PartialView("FeeCategory");
        }
        public ActionResult TransportAllocation()
        {
            return PartialView("TransportAllocation");
        }

        public ActionResult FeeDetails()
        {
            TransportDetails tt = new TransportDetails();
            Business business = new Business();
            var fee = business.GetFeeDetails();
            tt.RouteCode= fee.RouteCode;
            tt.Source=fee.Source;
            tt.Destination=fee.Destination;

            return PartialView("FeeDetails", tt);
        }
        
        public ActionResult ManageTransportAllocation()
        {
            return PartialView("ManageTransportAllocation");
            

           
        }


        #region AccountGroup
        [HttpPost]
        public ActionResult AddAccountGroup(AccountGroup entity)
        {
            if (ModelState.IsValid)
            {
                entity.Status = "ACTIVE";
                Business bussiness = new Business();
               
                if (entity.Id == 0)
                {
                    bussiness.Add<AccountGroup>(entity);
                    ModelState.Clear();
                }
                else
                {
                    bussiness.Update<AccountGroup>(entity);
                    ModelState.Clear();
                }

                return PartialView("AccountGroup");
            }
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
            if (ModelState.IsValid)
            {
                Business bussiness = new Business();
                if (circular.Id == 0)
                {
                    bussiness.Add<Circular>(circular);
                    ModelState.Clear();
                }
                else
                {
                    bussiness.Update<Circular>(circular);
                    ModelState.Clear();
                }
                return PartialView("Circular");
            }
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

        [HttpPost]
        public JsonResult DeleteCircular(string Id)
        {
            Circular c = new Circular();
            c.Id = Convert.ToInt16(Id);
            Business bussiness = new Business();
            bussiness.Delete<Circular>(c);

            return Json("", JsonRequestBehavior.AllowGet);

        }
      
        #endregion Circular

        #region FeeCategory

        [HttpPost]
        public ActionResult AddFeeCategory(FeeCategory feecategory)
        {
            if (ModelState.IsValid)
            {
                Business business = new Business();

                feecategory.Status = "ACTIVE";
                if (feecategory.Id == 0)
                {
                    business.Add<FeeCategory>(feecategory);
                    ModelState.Clear();
                }
                else
                {
                    business.Update<FeeCategory>(feecategory);
                    ModelState.Clear();
                }
                return PartialView("FeeCategory");
            }
            return PartialView("FeeCategory");
        }
        [HttpGet]
        public JsonResult GetFeeCategory()
        {

            Business business = new Business();
            return Json(business.Retrieve<FeeCategory>(),JsonRequestBehavior.AllowGet);
        }
      










        public JsonResult DeleteFeeCategory(string Id)
        {

            FeeCategory fc = new FeeCategory();
            fc.Id = Convert.ToInt16(Id);
            Business business = new Business();
            business.Delete<FeeCategory>(fc);
            
            return Json("",JsonRequestBehavior.AllowGet);

        }
        #endregion FeeCategory

        #region LessonPlanning
         [HttpPost]
        public ActionResult AddLessonPlanning(LessonPlanning lessonplan)
        {
            if (ModelState.IsValid)
            {
                Business business = new Business();
                if (lessonplan.Id == 0)
                {
                    business.Add<LessonPlanning>(lessonplan);
                    ModelState.Clear();
                }
                else
                {
                    business.Update<LessonPlanning>(lessonplan);
                    ModelState.Clear();
                }


                return PartialView("LessonPlanning");
            }
            return PartialView("LessonPlanning");
        }
          [HttpGet]
        public JsonResult GetLessonPlanning()
          {
            Business business = new Business();
              return Json(business.Retrieve<LessonPlanning>(),JsonRequestBehavior.AllowGet);
          }

        [HttpPost]
        public JsonResult DeleteLessonPlanning(string Id)
        {
            Business business = new Business();
            LessonPlanning lp = new LessonPlanning();
            lp.Id = Convert.ToInt16(Id);

            business.Delete<LessonPlanning>(lp);
            return Json("",JsonRequestBehavior.AllowGet);
        
        }

        public JsonResult GetExcelData(string Cour,string batch,string subj)
        {

            LessonPlanning lp =new LessonPlanning();
            Business business =new Business();
            lp.Course = Cour;
            lp.Batch =batch;
            lp.Subject =subj;
           

        return Json(business.GetExcelData(lp), JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        //public ActionResult GetExcelLessonPlanningData( LessonPlanning details)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Business business = new Business();
        //        var exceldata = business.GetExcelData(details);

        //        var grid = new GridView();
        //        grid.DataSource = exceldata;

        //        grid.DataBind();
        //        for (int i = 0; i < grid.Rows.Count; i++)
        //        {
        //            grid.HeaderRow.Cells[0].Visible = false;
        //            grid.Rows[i].Cells[0].Visible = false;
        //        }
        //        Response.ClearContent();
        //        Response.Buffer = true;
        //        Response.AddHeader("content-disposition", "attachment; filename=LessonPlanning.xls");
        //        Response.ContentType = "application/ms-excel";

        //        Response.Charset = "";
        //        StringWriter sw = new StringWriter();
        //        HtmlTextWriter htw = new HtmlTextWriter(sw);

        //        grid.RenderControl(htw);

        //        Response.Output.Write(sw.ToString());
        //        Response.Flush();
        //        Response.End();

        //        return PartialView("LessonPlanning");
        //    }
        //    return PartialView("LessonPlanning");

        //}

        #endregion

        #region TransportAllocation
        [HttpPost]
        public ActionResult AddTransportAllocation(TransportAllocationDetail transportallocation)
        {
            if (ModelState.IsValid)
            {
                Business business = new Business();
                if (transportallocation.Id == 0)
                {
                    business.Add<TransportAllocationDetail>(transportallocation);
                    ModelState.Clear();
                }
                else
                {
                    business.Update<TransportAllocationDetail>(transportallocation);
                    ModelState.Clear();
                }
                return PartialView("TransportAllocation");
            }
            return PartialView("TransportAllocation");
        }
        [HttpGet]
        public JsonResult GetTransportAllocation()
        {

            Business business = new Business();
            var listt = JsonConvert.SerializeObject(business.Retrieve<TransportAllocationDetail>(), Formatting.None, new JsonSerializerSettings()
            {
                DateFormatString = "yyyy-MM-dd",
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });
            return Json(listt, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult DeleteTransportAllocation(string Id)
        {

            TransportAllocationDetail tad = new TransportAllocationDetail();
            tad.Id = Convert.ToInt16(Id);
            Business business = new Business();
            business.Delete<TransportAllocationDetail>(tad);

            return Json("", JsonRequestBehavior.AllowGet);

        }
        #endregion
        #region ManageTransportAllocation


        [HttpPost]
        public JsonResult GetUserNameList(string UserType)
        {
            //TransportAllocationDetail ta = new TransportAllocationDetail();
            var ta = UserType;

            Business business = new Business();
            var namedata = business.GetUserNameList(ta);
            return Json(namedata,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateMangeTransportAllocation(TransportAllocationDetail managetransport)
        {
            if (ModelState.IsValid)
            {

                Business business = new Business();
                if (Convert.ToInt16(managetransport.Id) != 0)
                {
                    business.UpdateManageTransportAllocation(managetransport);
                    ModelState.Clear();
                }
                return PartialView("ManageTransportAllocation");
            }
            return PartialView("ManageTransportAllocation");
        }
        #endregion



    }
   //public interface  Ient
   //{
   // int Id { get; set; }
   //}
}