using OmniMerit.Models.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace OmniMerit.Models.CustomModel
{
    public class ForgetPassword
    {
        [Required(ErrorMessage = "Please provide username.", AllowEmptyStrings = false)]
        public string Email { get; set; }
       
        public Boolean ForgetModel()
        {
            int ui = Convert.ToInt32(DateTime.Now.ToString("MdHms"));
            int uid = Convert.ToInt32(ui);

            try
            {
                using (OmnimeritEntities modelentity = new OmnimeritEntities())
                {

                    var v = from f in modelentity.StudentInfoes
                            where f.Email == Email 
                             select f;
                    if(v.Count()>=0)
                    {
                        v.FirstOrDefault().Password = uid.ToString();
                        modelentity.SaveChanges();
                        SendingMail(uid);
                        return true;
                    }
                    return false;
                    
                }
                
            }
            catch(Exception e)
            {
                return false;
            }
            
        }

        private void SendingMail(int uid)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtpout.secureserver.net");
            mail.From = new MailAddress("forget@omnimerit.com");
            mail.To.Add(Email);
            mail.Subject = "Reset Password ";
            mail.Body = "Your OmniMerit Password is Reset. \n Your Password is " + uid;
            
            SmtpServer.Credentials = new System.Net.NetworkCredential("forget@omnimerit.com", "omnimerit");
            //s SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
        }
    }
}