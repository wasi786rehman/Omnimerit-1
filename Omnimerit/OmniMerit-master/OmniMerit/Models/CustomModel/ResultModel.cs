using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OmniMerit.Models.DataBase;
namespace OmniMerit.Models.CustomModel
{
    public class ResultModel
    {
        public List<AirResult> ShowResultModel(double number)
        {
            try
            {
                using (OmnimeritEntities modelentity = new OmnimeritEntities())
                {
                    var v = modelentity.AirResults.Where(model => model.Mobile_No==number).FirstOrDefault();
                    List<AirResult> list = new List<AirResult>();
                    list.Add(v);
                    return list;
                    

                    
                }
            }
            catch (Exception e) {
            return new List<AirResult>();}

        }
    }
}