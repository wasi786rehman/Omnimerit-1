using OmniMerit.Models.CustomModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OmniMerit.Controllers
{
    public class SignUpInfoController : Controller
    {
        SignUpModel model = new SignUpModel();

        // GET: SignUp
        public ActionResult SignUp()
        {
            
            return View();
        }
        [System.Web.Http.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUpInfo(StudentInfo studentInfo)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);

            if (ModelState.IsValid)
            {

                if (model.Signup(studentInfo))
                { return RedirectToAction("../default/profile"); }
                else
                {
                    return RedirectToAction("../default/Index");
                }
            }
            return RedirectToAction("SignUp",studentInfo);
        }


    }
}