using Omnimerit.Data.Model.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omnimerit.Data.BussinessLayer
{
    public class Business
    {

        #region AccountGroup
        public  List<AccountGroup> ShowResult()
        {
            try
            {
                OmnimeritEntities1 db = new OmnimeritEntities1();
                List<AccountGroup> list = new List<AccountGroup>();
                list = db.AccountGroups.ToList();

                return list;
            }
            catch (Exception e)
            {
                return new List<AccountGroup>();
            }
        }

        #endregion AccountGroup
        #region Circular
        public bool AddCircular(Circular entity)
        {
            try
            {

                using (OmnimeritEntities1 modelEntity = new OmnimeritEntities1())
                {

                    modelEntity.Circulars.Add(entity);
                    modelEntity.SaveChanges();
                    return true;

                }
            }
            catch (Exception ex) { throw ex; }


        }

        public List<Circular> GetCircular()
        {
            try
            {
                OmnimeritEntities1 db = new OmnimeritEntities1();
                List<Circular> list = new List<Circular>();
                 list = db.Circulars.ToList();

                return list;
            }
            catch (Exception e)
            {
                return new List<Circular>();
            }
        }

        #endregion Circular

    }
}
