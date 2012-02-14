using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Thomas_Shields_Portfolio.Models;

namespace Thomas_Shields_Portfolio.Controllers
{ 
	public class ArticlesController : Controller
	{
		private ArticleContext db = new ArticleContext();

		//
		// GET: /Articles/

		public ViewResult Index()
		{
			return View(db.articles.ToList());
		}

		//
		// GET: /Articles/Details/5

		public ViewResult Details(int id)
		{
			article article = db.articles.Find(id);
			return View(article);
		}

		//
		// GET: /Articles/Create
		[Authorize]
		public ActionResult Create()
		{
			return View();
		} 

		//
		// POST: /Articles/Create
		[Authorize]
		[HttpPost]
		public ActionResult Create(article article)
		{
			if (ModelState.IsValid)
			{
				db.articles.Add(article);
				db.SaveChanges();
				return RedirectToAction("Index");  
			}

			return View(article);
		}
		
		//
		// GET: /Articles/Edit/5
		[Authorize]
		public ActionResult Edit(int id)
		{
			article article = db.articles.Find(id);
			return View(article);
		}

		//
		// POST: /Articles/Edit/5
		[Authorize]
		[HttpPost]
		public ActionResult Edit(article article)
		{
			if (ModelState.IsValid)
			{
				db.Entry(article).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("article", "home", new { id=article.id});
			}
			return View(article);
		}

		//
		// GET: /Articles/Delete/5
		[Authorize]
		public ActionResult Delete(int id)
		{
			article article = db.articles.Find(id);
			return View(article);
		}

		//
		// POST: /Articles/Delete/5
		[Authorize]
		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirmed(int id)
		{            
			article article = db.articles.Find(id);
			db.articles.Remove(article);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
		{
			db.Dispose();
			base.Dispose(disposing);
		}
	}
}