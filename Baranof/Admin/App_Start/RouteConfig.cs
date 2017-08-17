using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace Admin
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);
            routes.MapPageRoute("Home_Action", "home/{mode}", "~/Home/Action.aspx", false);
            routes.MapPageRoute("Approach_Action", "approach/{mode}/{id}", "~/Approach/Action.aspx", false);
            routes.MapPageRoute("Criteria_Action", "criteria/{mode}/{id}", "~/Criteria/Action.aspx", false);
            routes.MapPageRoute("Team_Action", "team/{mode}/{id}", "~/Team/Action.aspx", false, new RouteValueDictionary { { "mode", "add" }, { "id", "0" } });
            routes.MapPageRoute("Portfolio_Action", "portfolio/{mode}/{id}", "~/Portfolio/Action.aspx", false, new RouteValueDictionary { { "mode", "add" }, { "id", "0" } });
            routes.MapPageRoute("Contact_Action", "contact/{mode}/{id}", "~/Contact/Action.aspx", false);
        }
    }
}
