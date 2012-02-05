using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
namespace Thomas_Shields_Portfolio.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";
            List<string> docs = new List<string>();
            
            foreach (var item in Directory.GetFiles(Request.ApplicationPath + "/articles"))
            {
                docs.Add(item.Replace('\\','/').Split('/').Last());
            }
            ViewBag.docs=docs;
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
