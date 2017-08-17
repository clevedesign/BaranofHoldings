using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Models;
using BLL;

namespace BaranofHoldings.Models
{
    public class HomeModel
    {
        //public PageContent HomeContent { get; private set; }
        //public PageContent HeadingContent { get; private set; }
        //public IList<PageContent> ApproachList { get; private set; }
        //public IList<PageContent> CriteriaList { get; private set; }
        //public IList<PortfolioContent> Portfolios { get; private set; }
        //public Contact ContactInfo { get; private set; }


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



        internal TeamMember GetNewTeam(int id)
        {
            return Team = ManageTeamMember.GetById(id);
        }

        public HomeModel()
        {
            //HomeContent = ManagePageContent.GetHeadingContent("Home", "Home");
            //HeadingContent = ManagePageContent.GetHeadingContent("Home", "Heading");
            //ApproachList = ManagePageContent.GetAllPageContentOf("Approach");
            //CriteriaList = ManagePageContent.GetAllPageContentOf("Criteria");
            //Portfolios = ManagePortfolioContent.GetAllPortfolios();
            //ContactInfo = ManageContact.GetAllContact().First();


            home = ManageHome.GetAllHome().FirstOrDefault();
            overview = ManageOverview.GetAllOverview().FirstOrDefault();
            approach = ManageApproach.GetAllApproach().OrderBy(appr => appr.Order).ToList();
            strategy = ManageStrategy.GetAllStrategy().OrderBy(appr => appr.Order).ToList();
            PortfoliosCurrent = ManagePortfolioContent.GetAllPortfolios().Where(c => c.PortfolioType == "Under Construction").ToList();
            PortfoliosExited = ManagePortfolioContent.GetAllPortfolios().Where(c => c.PortfolioType == "Pre-Development").ToList();
            PortfoliosDiligence = ManagePortfolioContent.GetAllPortfolios().Where(c => c.PortfolioType == "Diligence").ToList();
            PortfoliosAll  = ManagePortfolioContent.GetAllPortfolios().OrderBy(appr => appr.PortfolioOrder).ToList();
            TeamList = ManageTeamMember.GetAllTeamMembers().OrderBy(appr => appr.MemberOrder).ToList();
            contact = ManageContact.GetAllContact().FirstOrDefault();
        }

        internal PortfolioContent GetNewPortfolio(int id)
        {
            return onePortfolio = ManagePortfolioContent.GetById(id);
        }
    }
}