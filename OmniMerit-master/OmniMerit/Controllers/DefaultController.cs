using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using System.IO;
using OmniMerit.Models;
using OmniMerit.Models.CustomModel;

namespace OmniMerit.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {

            TempData.Remove("number");
            return View();
        }
        public ActionResult invalidcredential()
        {

            ViewBag.Message = "Invalid Login Details";
            return View("Index");
        }
        public ActionResult Career()
        {
           
            return View();
        }
        public ActionResult Career1()
        {
            ViewBag.Message =null;
            return View();
        }
        public ActionResult Foundation(int? page)
        { 
            return View();
        }
        public ActionResult Engineering()
        {
            
            return View();
        }
        public ActionResult Profile()
        {
            TempData.Keep();
            return View();
        }


        public ActionResult Medical()
        {

            return View();
        }
        public ActionResult XIIChemistry()
        {
           

            return View();
        }

        private void Login()
        {
           
        }

        [HttpPost]
        public bool ResumeUpload(FormCollection fc, HttpPostedFileBase file)
        {
            string name=string.Empty;
            string email=string.Empty;
            string path="";
            if (fc[0].ToString()!=null && fc[1].ToString()!=null)
            {
                 name = fc["name"].ToString();
                 email = fc["email"].ToString();
            }

            if (file != null && file.ContentLength > 0)
                try
                {
                     path = Path.Combine(Server.MapPath("~/Scripts/Images/resume"),
                                               Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                   
                    TempData["Message"]= "File uploaded successfully";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                    return false;
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }



            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("wasi786rehman@gmail.com");
                mail.To.Add("talha.a90@gmail.com");
                mail.Subject = "Resume: " + name + "-Email: " + email;
                mail.Body = "mail with attachment";

                if (path != "")
                {
                    System.Net.Mail.Attachment attachment;
                    attachment = new System.Net.Mail.Attachment(path);
                    mail.Attachments.Add(attachment);
                }
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("wasi786rehman@gmail.com", "wasi.rehman9027413884");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);


            }
            catch(Exception e)
            {
                return false;
            }


            return true;
        }
    }
}