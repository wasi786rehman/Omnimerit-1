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
          public interface Ient
        {
        int Id { get; set; }
    }

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

    }
}
