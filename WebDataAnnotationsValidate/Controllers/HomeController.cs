using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDataAnnotationsValidate.Models.ViewModels;

namespace WebDataAnnotationsValidate.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(PeopleViewModel model)
        {
            if (model == null)
                model = new PeopleViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Save(PeopleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", model);
            }
            return RedirectToAction("Success");
        }

        public ActionResult Success()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}