using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BaranofHoldings.Models;

namespace BaranofHoldings.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HomeModel homeModel = new HomeModel();

            return View(homeModel);
        }
        [HttpGet]
        [AllowAnonymous]
        public JsonResult getPortfolio(int id)
        {
            HomeModel HM = new HomeModel();
            var model =Json(HM.GetNewPortfolio(id));

            

            return new JsonResult() { Data = model, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }


        [HttpGet]
        [AllowAnonymous]
        public JsonResult getTeam(int id)
        {
            HomeModel HM = new HomeModel();
            var model = Json(HM.GetNewTeam(id));



            return new JsonResult() { Data = model, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }
    }
}
