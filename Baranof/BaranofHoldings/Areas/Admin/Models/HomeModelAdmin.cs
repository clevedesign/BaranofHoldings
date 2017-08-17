using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Models;
using BLL;
using System.Web.Mvc;

namespace BaranofHoldings.Areas.Admin.Models
{
    [Authorize]
    public class HomeModelAdmin
    {
        public Home home { get; set; }
        public Overview overview { get; set; }
        public List<Approach> approach { get; set; }
        public List<Strategy> strategy { get; set; }
        public IList<PortfolioContent> PortfoliosCurrent { get; set; }
        public IList<PortfolioContent> PortfoliosExited { get; set; }
        public IList<PortfolioContent> PortfoliosDiligence { get; set; }
        public IList<PortfolioContent> PortfoliosAll { get; set; }
        public PortfolioContent onePortfolio { get; set; }
        public TeamMember Team { get; set; }
        public IList<TeamMember> TeamList { get; set; }
        public Contact contact { get; set; }
        public bool isNewPicture { get; set; }      
        public HttpPostedFileBase ImageUpload { get; set; }
        public HomeModelAdmin()
        {           
            home = ManageHome.GetAllHome().FirstOrDefault();
            overview = ManageOverview.GetAllOverview().FirstOrDefault();
            approach = ManageApproach.GetAllApproach().OrderBy(appr => appr.Order).ToList();
            strategy = ManageStrategy.GetAllStrategy().OrderBy(appr => appr.Order).ToList();
            PortfoliosCurrent = ManagePortfolioContent.GetAllPortfolios().Where(c => c.PortfolioType == "Under Construction").ToList();
            PortfoliosExited = ManagePortfolioContent.GetAllPortfolios().Where(c => c.PortfolioType == "Pre-Development").ToList();
            PortfoliosDiligence = ManagePortfolioContent.GetAllPortfolios().Where(c => c.PortfolioType == "Diligence").ToList();
            PortfoliosAll  = ManagePortfolioContent.GetAllPortfolios().OrderBy(appr => appr.PortfolioOrder).ToList();
            TeamList = ManageTeamMember.GetAllTeamMembers().OrderBy(appr => appr.MemberOrder).Where(c=>c.isDeleted==false).ToList();
            contact = ManageContact.GetAllContact().FirstOrDefault();
        }

        internal TeamMember GetNewTeam(int id)
        {
            return Team = ManageTeamMember.GetById(id);
        }

        internal void UpdatOAS(HomeModelAdmin model)
        {
            foreach (var item in model.approach)
            {
                ManageApproach.UpdateApproach(item);
            }

            foreach (var item1 in model.strategy)
            {
                ManageStrategy.UpdateStrategy(item1);
            }
            ManageOverview.UpdateOverview(model.overview);
        }

        internal void AddtePorfolio(HomeModelAdmin model)
        {
            ManagePortfolioContent.AddPortfolio(model.onePortfolio);
        }

        internal void UpdatePorfolio(HomeModelAdmin model)
        {
            ManagePortfolioContent.UpdatePortfolio(model.onePortfolio);
        }

        internal PortfolioContent GetNewPortfolio(int id)
        {
            return onePortfolio = ManagePortfolioContent.GetById(id);
        }

        internal void AddTeam(HomeModelAdmin model)
        {
            model.Team.MemberType = "Team";
            ManageTeamMember.AddTeamMember(model.Team);
        }

        internal void UpdateTeam(HomeModelAdmin model)
        {
            model.Team.MemberType = "Team";
            ManageTeamMember.UpdateTeamMember(model.Team);
        }

        internal void UpdateContact(HomeModelAdmin model)
        {
            ManageContact.UpdateContact(model.contact);
        }
    }
}