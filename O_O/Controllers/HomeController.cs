using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using O_O.Models;

namespace O_O.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to O_O";
            PostContext db = new PostContext();
            ViewBag.latest = (from p in db.posts orderby p.date descending select p).Take(4).ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.EmailHash = O_O.Content.MD5HashToString.StringToHashToString("thomas@mpdteam.net");
            return View();
        }
        public ViewResult NotFound()
        {
            return View("404");
        }
    }
}
