using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OmniMerit.Models.CustomModel;
namespace OmniMerit.Controllers
{
    public class ResultController : Controller
    {
       
        [HttpPost]
        public JsonResult ShowResult()
        { 
            double number = 0;
            if (TempData["number"]!=null)
                number = Convert.ToDouble(TempData["number"].ToString());
           
            ResultModel result = new ResultModel();
            TempData.Keep();
            return Json(result.ShowResultModel(number).ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}