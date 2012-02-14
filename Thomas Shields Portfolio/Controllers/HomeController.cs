using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Thomas_Shields_Portfolio.Models;
namespace Thomas_Shields_Portfolio.Controllers
{
	public class HomeController : Controller
	{
		private ArticleContext db = new ArticleContext();
		public ActionResult Index()
		{
			ViewBag.current = "writing";
			return View(db.articles.ToList().OrderByDescending(p => p.date));
		}
		public ActionResult Article(int id)
		{
			ViewBag.current = "writing";
			article article = db.articles.Find(id);
			ViewBag.title = article.title + " | ";
			return View(article);
		}
		public ActionResult About()
		{
			ViewBag.current = "about";
			return View();
		}
		public ActionResult Web()
		{
			ViewBag.current = "web";
			return View();
		}
	}
}
