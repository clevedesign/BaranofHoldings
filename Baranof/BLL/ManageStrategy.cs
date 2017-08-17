using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Models;
using DAL.Repositories;
using System.ComponentModel;




namespace BLL
{
    public class ManageStrategy
    {
        #region Select Methods -- GetAllStrategy, GetById
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static IList<Strategy> GetAllStrategy()
        {
            return Manage<Strategy, StrategyRepository>.GetAll().Where(n => n.isDeleted == false).OrderByDescending(n => n.Created).ToList();
        }
        public static Strategy GetById(int id)
        {
            return Manage<Strategy, StrategyRepository>.GetById(id);
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Strategy GetById(string id)
        {
            return Manage<Strategy, StrategyRepository>.GetById(id);
        }
        #endregion

        #region Insert Methods -- AddStrategy
        public static bool AddStrategy(Strategy n)
        {
            n.Created = DateTime.Now.Date;
            n.Modified = DateTime.Now.Date;

            return Manage<Strategy, StrategyRepository>.Add(n);
        }
        #endregion

        #region Update Methods -- UpdateStrategy
        public static bool UpdateStrategy(Strategy n)
        {

            n.Modified = DateTime.Now.Date;

            return Manage<Strategy, StrategyRepository>.Update(n);
        }
        #endregion

        #region Delete Methods -- DeleteStrategy
        public static bool DeleteStrategy(Strategy n)
        {
            n.isDeleted = true;

            return UpdateStrategy(n);
        }
        #endregion
    }
}
