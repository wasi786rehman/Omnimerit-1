using Omnimerit.Data.Model.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Omnimerit.Data.BussinessLayer
{
    public class Business
    {
        OmnimeritEntities1 db = new OmnimeritEntities1();
        #region Generic
        public void Add<T>(T newItem) where T : class
        {
            try
            {
                db.Set<T>().Add(newItem);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void Delete<T>(T newItem) where T : class
        {
            try
            {
                db.Entry(newItem).State = EntityState.Deleted;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<T> Retrieve<T>() where T : class
        {
            try
            {

                return db.Set<T>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public void Update<T>(T entity) where T : class,Ient
        {



            bool ifExist = db.Set<T>().Any(t => t.Id == entity.Id);
            if (ifExist)
            {
                var entry = db.Entry(entity);
                if (entry.State == EntityState.Detached)
                {
                    db.Set<T>().Attach(entity);
                    entry = db.Entry(entity);
                }
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        #endregion Generic
       

        #region AccountGroup

        //public bool AddAccountGroup(AccountGroup entity, int id)
        //{
        //    try
        //    {
        //        using (OmnimeritEntities1 db = new OmnimeritEntities1())
        //        {
        //            //int val = int.Parse(id);
        //            if (id > 0)
        //            {
        //                AccountGroup Acc = (from c in db.AccountGroups
        //                                    where c.Id == id
        //                                    select c).FirstOrDefault();
        //                Acc.AccountName = entity.AccountName;
        //                Acc.GroupUnder = entity.GroupUnder;
        //                db.SaveChanges();
        //            }
        //            else
        //            {
        //                db.AccountGroups.Add(entity);
        //                db.SaveChanges();
        //            }

        //        }
        //        return true;
        //    }
        //    catch (Exception ex) { throw ex; }
        //}

        
        //public  List<AccountGroup> GetAccountGroup()
        //{
        //    try
        //    {
        //        using (OmnimeritEntities1 db = new OmnimeritEntities1())
        //        {
        //            List<AccountGroup> list = new List<AccountGroup>();
        //            list = db.AccountGroups.ToList();

        //            return list;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        return new List<AccountGroup>();
        //    }
        //}

        //public bool DeleteAccountGroup(int idlabel)
        //{
        //    try
        //    {
        //        using (OmnimeritEntities1 db = new OmnimeritEntities1())
        //        {
        //            if (idlabel > 0)
        //            {
        //                AccountGroup Acc = (from c in db.AccountGroups
        //                                            where c.Id == idlabel
        //                                            select c).FirstOrDefault();
        //                db.AccountGroups.Remove(Acc);
        //                db.SaveChanges();
        //            }


        //        }
        //        return true;
        //    }
        //        catch(Exception ex)
        //    {
        //            throw ex;

        //    }

        //}

        #endregion AccountGroup
        #region Circular
        //public bool AddCircular(Circular entity)
        //{
        //    try
        //    {

        //        using (OmnimeritEntities1 modelEntity = new OmnimeritEntities1())
        //        {

        //            modelEntity.Circulars.Add(entity);
        //            modelEntity.SaveChanges();
        //            return true;

        //        }
        //    }
        //    catch (Exception ex) { throw ex; }


        //}

        //public List<Circular> GetCircular()
        //{
        //    try
        //    {
        //        OmnimeritEntities1 db = new OmnimeritEntities1();
        //        List<Circular> list = new List<Circular>();
        //         list = db.Circulars.ToList();

        //        return list;
        //    }
        //    catch (Exception e)
        //    {
        //        return new List<Circular>();
        //    }
        //}

        #endregion Circular

        #region FeeDetails

        public TransportAllocationDetail GetFeeDetails()
        {
            TransportAllocationDetail tad = new TransportAllocationDetail();
             tad = (from c in db.TransportAllocationDetails where c.UserType == "Employee" && c.UserName == "Gunjan" select c).FirstOrDefault();

             return tad;
        
        }
        public List<TransportAllocationDetail> GetUserNameList(string UserType)
        {
            List<TransportAllocationDetail> tad = new List<TransportAllocationDetail>();
            tad = (from d in db.TransportAllocationDetails where d.UserType == UserType select d).ToList();

            return tad;
        }

        #endregion
        #region LessonPlanning

        public List<LessonPlanning> GetExcelData(LessonPlanning data)
        {

            try
            {
                List<LessonPlanning> lp = new List<LessonPlanning>();
                
                
              if((data.Course !=null)&&(data.Batch !=null)&& (data.Subject!=null))
              {

                  lp = (from e in db.LessonPlannings where e.Course == data.Course && e.Batch == data.Batch && e.Subject == data.Subject select e).ToList();

                 

              }

              return lp;
            }
            catch (Exception ex) { throw ex; }

        }
        #endregion
        #region ManageTransportAllocation

        public bool UpdateManageTransportAllocation(TransportAllocationDetail tad)
        {
            try
            {
                if (Convert.ToInt16(tad.Id) > 0)
                {
                    TransportAllocationDetail tt = (from c in db.TransportAllocationDetails where c.Id == tad.Id select c).FirstOrDefault();
                    tt.RouteCode = tad.RouteCode;
                    tt.Source = tad.Source;
                    tt.Destination = tad.Destination;
                    db.SaveChanges();


                }
                return true;
            }
            catch (Exception ex) { throw ex; }



        }
        #endregion

    }
    public interface Ient
    {
        int Id { get; set; }
    }
}
