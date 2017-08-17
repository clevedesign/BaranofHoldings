using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Models;
using DAL.Repositories;
using System.ComponentModel;

namespace BLL
{
    public class ManagePortfolioContent
    {
        #region Select Methods -- GetAllPortfolios, GetAllPortfoliosOf, GetById
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static IList<PortfolioContent> GetAllPortfolios()
        {
            return Manage<PortfolioContent, PortfolioContentRepository>.GetAll().Where(i => i.isDeleted == false).OrderBy(i => i.PortfolioType).ThenByDescending(i => i.PortfolioDate).ToList();
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static IList<PortfolioContent> GetAllPortfoliosOf(string type)
        {
            return Manage<PortfolioContent, PortfolioContentRepository>.GetAll().Where(i => i.isDeleted == false && i.PortfolioType.ToLower().Equals(type.ToLower())).OrderByDescending(i => i.PortfolioDate).ToList();
        }
        public static PortfolioContent GetById(int id)
        {
            return Manage<PortfolioContent, PortfolioContentRepository>.GetById(id);
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static PortfolioContent GetById(string id)
        {
            return Manage<PortfolioContent, PortfolioContentRepository>.GetById(id);
        }
        #endregion

        #region Insert Methods -- AddPortfolio
        public static bool AddPortfolio(PortfolioContent i)
        {
            i.Created = DateTime.Now.Date;
            i.Modified = DateTime.Now.Date;

            return Manage<PortfolioContent, PortfolioContentRepository>.Add(i);
        }
        #endregion

        #region Update Methods -- UpdatePortfolio
        public static bool UpdatePortfolio(PortfolioContent n)
        {


            n.Modified = DateTime.Now.Date;

            return Manage<PortfolioContent, PortfolioContentRepository>.Update(n);

            //Log l = new Log();
            //PortfolioContent old_i = GetById(i.PortfolioId);

            //i.Modified = DateTime.Now.Date;
            //l.LogType = "Update";
            //l.ContentName = "PortfolioContent";
            //l.OldValues = old_i.PortfolioId + "[lewis]" + old_i.PortfolioType + "[lewis]" + old_i.PortfolioName + "[lewis]" + old_i.PortfolioLogo + "[lewis]" + old_i.PortfolioLocation + "[lewis]" + old_i.PortfolioServices + "[lewis]" + old_i.PortfolioDate + "[lewis]" + old_i.PortfolioSite + "[lewis]" + old_i.PortfolioDetails + "[lewis]" + old_i.PortfolioOrder;
            //l.NewValues = i.PortfolioId + "[lewis]" + i.PortfolioType + "[lewis]" + i.PortfolioName + "[lewis]" + i.PortfolioLogo + "[lewis]" + i.PortfolioLocation + "[lewis]" + i.PortfolioServices + "[lewis]" + i.PortfolioDate + "[lewis]" + i.PortfolioSite + "[lewis]" + i.PortfolioDetails + "[lewis]" + i.PortfolioOrder;

            //return Manage<PortfolioContent, PortfolioContentRepository>.Backup(l, i, "Update");
        }
        #endregion

        #region Delete Methods -- DeletePortfolio
        public static bool DeletePortfolio(PortfolioContent i)
        {
            i.Modified = DateTime.Now.Date;
            i.isDeleted = true;
           return UpdatePortfolio(i);

            //Log l = new Log();

            //i.Modified = DateTime.Now.Date;
            //i.isDeleted = true;
            //l.LogType = "Delete";
            //l.ContentName = "PortfolioContent";
            //l.OldValues = i.PortfolioId + "[lewis]" + i.PortfolioType + "[lewis]" + i.PortfolioName + "[lewis]" + i.PortfolioLogo + "[lewis]" + i.PortfolioLocation + "[lewis]" + i.PortfolioServices + "[lewis]" + i.PortfolioDate + "[lewis]" + i.PortfolioSite + "[lewis]" + i.PortfolioDetails + "[lewis]" + i.PortfolioOrder;

            //return Manage<PortfolioContent, PortfolioContentRepository>.Backup(l, i, "Delete");
        }
        #endregion

    }
}
