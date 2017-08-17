using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Models;
using DAL.Repositories;
using System.ComponentModel;




namespace BLL
{
    public class ManageOverview
    {
        #region Select Methods -- GetAllOverview, GetById
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static IList<Overview> GetAllOverview()
        {
            return Manage<Overview, OverviewRepository>.GetAll().Where(n => n.isDeleted == false).OrderByDescending(n => n.Created).ToList();
        }
        public static Overview GetById(int id)
        {
            return Manage<Overview, OverviewRepository>.GetById(id);
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Overview GetById(string id)
        {
            return Manage<Overview, OverviewRepository>.GetById(id);
        }
        #endregion

        #region Insert Methods -- AddOverview
        public static bool AddOverview(Overview n)
        {
            n.Created = DateTime.Now.Date;
            n.Modified = DateTime.Now.Date;

            return Manage<Overview, OverviewRepository>.Add(n);
        }
        #endregion

        #region Update Methods -- UpdateOverview
        public static bool UpdateOverview(Overview n)
        {

            n.Modified = DateTime.Now.Date;

            return Manage<Overview, OverviewRepository>.Update(n);
        }
        #endregion

        #region Delete Methods -- DeleteOverview
        public static bool DeleteOverview(Overview n)
        {
            n.isDeleted = true;

            return UpdateOverview(n);
        }
        #endregion
    }
}
