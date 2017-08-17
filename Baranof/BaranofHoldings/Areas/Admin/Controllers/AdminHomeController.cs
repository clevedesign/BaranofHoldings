using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaranofHoldings.Areas.Admin.Models;
using DAL.Models;
using BLL;
using System.IO;

namespace BaranofHoldings.Areas.Admin.Controllers
{
    [Authorize]
    public class AdminHomeController : Controller
    {
        public ActionResult Index()
        {
            HomeModelAdmin homeModel = new HomeModelAdmin();

            return View(homeModel);
        }
        [HttpGet]
        [AllowAnonymous]
        public JsonResult getPortfolio(int id)
        {
            HomeModelAdmin HM = new HomeModelAdmin();
            var model = Json(HM.GetNewPortfolio(id));



            return new JsonResult() { Data = model, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }


        [HttpGet]
        [AllowAnonymous]
        public JsonResult getTeam(int id)
        {
            HomeModelAdmin HM = new HomeModelAdmin();
            var model = Json(HM.GetNewTeam(id));



            return new JsonResult() { Data = model, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }

        //Update
        //Check 
        [ValidateInput(false)]
        public ActionResult UpdateMainContent(HomeModelAdmin model)
        {
            //handle 1. Overview 2. Approach 3. Strategy
            model.UpdatOAS(model);
            return RedirectToAction("Index");
        }

       
        
        public ActionResult UpdatePortfolio(int id)
        {
            //handle 1. Overview 2. Approach 3. Portfolio
            List<SelectListItem> l = new List<SelectListItem>();
            l.Add(new SelectListItem { Text = "Under Construction", Value = "Under Construction" });
            l.Add(new SelectListItem { Text = "Pre-Development", Value = "Pre-Development" });

            ViewBag.type = l;

            HomeModelAdmin AM = new HomeModelAdmin();
            AM.GetNewPortfolio(id);
            return View(AM);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UpdatePortfolio(HomeModelAdmin model)
        {
            if (model.ImageUpload != null)
            {
               model.onePortfolio.PortfolioLogo =  ImageUload(model, "~/Images");
            };

            model.UpdatePorfolio(model);
           
            return RedirectToAction("Index");
        }





        public ActionResult UpdateTeam(int id)
        {
            //handle 1. Overview 2. Approach 3. Portfolio
            //List<SelectListItem> l = new List<SelectListItem>();
            //l.Add(new SelectListItem { Text = "Owned", Value = "Owned" });
            //l.Add(new SelectListItem { Text = "Under Contract", Value = "Under Contract" });

            //ViewBag.type = l;

            HomeModelAdmin AM = new HomeModelAdmin();
            AM.GetNewTeam(id);
            return View(AM);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UpdateTeam(HomeModelAdmin model)
        {
            if (model.ImageUpload != null)
            {
                model.Team.MemberPicture = ImageUload(model, "~/Images");
            };

            model.UpdateTeam(model);

            return RedirectToAction("Index");
        }





        public ActionResult DeletePortfolio(int id)
        {
            //handle 1. Overview 2. Approach 3. Portfolio
            var MPC = ManagePortfolioContent.GetById(id);
            ManagePortfolioContent.DeletePortfolio(MPC);
            return RedirectToAction("index");
        }

        public ActionResult DeleteTeam(int id)
        {
            //handle 1. Overview 2. Approach 3. Portfolio
            var MPC = ManageTeamMember.GetById(id);
            ManageTeamMember.DeleteTeamMember(MPC);
            return RedirectToAction("index");
        }
        public ActionResult AddPortfolio()
        {
            //handle 1. Overview 2. Approach 3. Portfolio
            List<SelectListItem> l = new List<SelectListItem>();
            l.Add(new SelectListItem { Text = "Owned", Value = "Owned" });
            l.Add(new SelectListItem { Text = "Under Contract", Value = "Under Contract" });

            ViewBag.type = l;

            HomeModelAdmin AM = new HomeModelAdmin();
          
            return View(AM);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddPortfolio(HomeModelAdmin model)
        {
            //handle 1. Overview 2. Approach 3. Portfolio
            if (model.ImageUpload != null)
            {
                model.onePortfolio.PortfolioLogo = ImageUload(model, "~/Images");
            }
            else {
                model.onePortfolio.PortfolioLogo = "noimg.jpg";
            };

            model.AddtePorfolio(model);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult AddTeam()
        {
            //handle 1. Overview 2. Approach 3. Portfolio

            HomeModelAdmin AM = new HomeModelAdmin();

            return View(AM);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddTeam(HomeModelAdmin model)
        {
            //handle 1. Overview 2. Approach 3. Portfolio
            if (model.ImageUpload != null)
            {
                model.Team.MemberPicture = ImageUload(model, "~/Images");
            }
            else {
                model.Team.MemberPicture = "noimg.jpg";
            };

            model.AddTeam(model);

            return RedirectToAction("Index");
        }

        public ActionResult UpdateContact(HomeModelAdmin model)
        {
            model.UpdateContact(model);
            return RedirectToAction("index");
        }

        //upload image
        public string ImageUload(HomeModelAdmin model, string url)
        {
            var validImageTypes = new string[]
            {
                "image/gif",
                "image/jpeg",
                "image/jpg",
                "image/pjpeg",
                "image/png"
            };

            if (model.ImageUpload == null || model.ImageUpload.ContentLength == 0)
            {
                ModelState.AddModelError("ImageUpload", "This field is required");
            }
            else if (!validImageTypes.Contains(model.ImageUpload.ContentType))
            {
                ModelState.AddModelError("ImageUpload", "Please choose either a GIF, JPG or PNG image.");
            }

            if (ModelState.IsValid)
            {
                if (model.ImageUpload != null && model.ImageUpload.ContentLength > 0)
                {
                    var uploadDir = url;
                    var imagePath = Path.Combine(Server.MapPath(uploadDir), model.ImageUpload.FileName);
                    var imageUrl = Path.Combine(uploadDir, model.ImageUpload.FileName);
                    model.ImageUpload.SaveAs(imagePath);
                    return model.ImageUpload.FileName;
                }
            }
            return "noimg.jpg";
        }
    }
}