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
            var _posts = (from p in db.posts
                          orderby p.date descending
                          select new { p.id, p.title, p.content, p.date, p.tag, comments = (from c in db.comments where c.post == p.id select c) });
            int numPosts = _posts.Count();
            _posts = _posts.Take(4);
            var posts = new List<post>();
            foreach (var item in _posts)
            {
                posts.Add(new post(item.id, item.title, item.content, item.date, item.tag, item.comments.ToList()));
            }

            ViewBag.latest = posts;
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
