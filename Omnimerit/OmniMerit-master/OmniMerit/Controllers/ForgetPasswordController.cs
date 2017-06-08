using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OmniMerit.Models.CustomModel;

namespace OmniMerit.Controllers
{
    public class ForgetPasswordController : Controller
    {
        // GET: ForgetPassword
        public ActionResult Index()
        {
          
            return View();
        }

        public ActionResult ForgetPassword(ForgetPassword forget)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);

            if (ModelState.IsValid)
            {
                if (forget.ForgetModel())
                {
                    ViewBag.Success = "New Password Is sent to the Registered Email  ";
                }
                else { ViewBag.Error = "No Email is Associated with OmniMerit. Please Check Again "; }
            }
            
            return View("Index");
        }
    }
}