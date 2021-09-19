using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProgramskoInzenjerstvo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Ukratko o nama.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Studenti računarstva na FSRE.";

            return View();
        }
        public ActionResult Andrej()
        {
            return View();
        }
        public ActionResult Matej()
        {
            return View();
        }
        public ActionResult Filip()
        {
            return View();
        }
        public ActionResult Antun()
        {
            return View();
        }
        public ActionResult Klara()
        {
            return View();
        }

    }
}