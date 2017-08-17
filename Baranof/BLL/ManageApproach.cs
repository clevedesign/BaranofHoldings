using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Models;
using DAL.Repositories;
using System.ComponentModel;




namespace BLL
{
    public class ManageApproach
    {
        #region Select Methods -- GetAllApproach, GetById
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static IList<Approach> GetAllApproach()
        {
            return Manage<Approach, ApproachRepository>.GetAll().Where(n => n.isDeleted == false).OrderByDescending(n => n.Created).ToList();
        }
        public static Approach GetById(int id)
        {
            return Manage<Approach, ApproachRepository>.GetById(id);
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Approach GetById(string id)
        {
            return Manage<Approach, ApproachRepository>.GetById(id);
        }
        #endregion

        #region Insert Methods -- AddApproach
        public static bool AddApproach(Approach n)
        {
            n.Created = DateTime.Now.Date;
            n.Modified = DateTime.Now.Date;

            return Manage<Approach, ApproachRepository>.Add(n);
        }
        #endregion

        #region Update Methods -- UpdateApproach
        public static bool UpdateApproach(Approach n)
        {

            n.Modified = DateTime.Now.Date;

            return Manage<Approach, ApproachRepository>.Update(n);
        }
        #endregion

        #region Delete Methods -- DeleteApproach
        public static bool DeleteApproach(Approach n)
        {
            n.isDeleted = true;

            return UpdateApproach(n);
        }
        #endregion
    }
}
