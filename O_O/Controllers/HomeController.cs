using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace O_O.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to O_O";

            return View();
        }

        public ActionResult About()
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes("thomas@mpdteam.net");
            bytes = md5.ComputeHash(bytes);
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            foreach (byte b in bytes)
            {
                s.Append(b.ToString("x2").ToLower());
            }
            ViewBag.EmailHash = s;
            return View();
        }
        public ViewResult NotFound()
        {
            return View("404");
        }
    }
}
