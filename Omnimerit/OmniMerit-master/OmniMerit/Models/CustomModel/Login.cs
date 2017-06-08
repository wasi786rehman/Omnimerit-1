using OmniMerit.Models.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OmniMerit.Models.CustomModel
{
    public class Login
    {
        [Required(ErrorMessage = "Please provide username.", AllowEmptyStrings = false)]
        public string ID { get; set; }
        [Required(ErrorMessage = "Please provide Password", AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string Password { get; set; }

        public bool LoginModel(Login login)
        {
            try
            {
                double number = Convert.ToDouble(login.ID);
                double password = Convert.ToDouble(login.Password);
                using (OmnimeritEntities modelentity = new OmnimeritEntities())
                {
                    var v = modelentity.AirResults.Where(model => model.Mobile_No == number && model.Mobile_No == password).Count();

                    if (v == 1)
                        return true;
                    else
                        return false;
                }
            }catch(Exception e) { return false; }
        }
        //public bool LoginModelNumber(Login login)
        //{
        //    try
        //    {
        //        double number = Convert.ToDouble(login.ID);
        //        double password = Convert.ToDouble(login.Password);
        //        using (omnimeritLocalEntities modelentity = new omnimeritLocalEntities())
        //        {
        //            var v = modelentity.results.Where(model => model.Mobile_No==number && model.Mobile_No== password).Count();

        //            if (v == 1)
        //                return true;
        //            else
        //                return false;
        //        }
        //    }
        //    catch (Exception e) { return false; }
        //}
    }
   
}