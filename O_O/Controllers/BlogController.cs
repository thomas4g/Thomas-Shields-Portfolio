using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using O_O.Models;

namespace O_O.Controllers
{ 
    public class BlogController : Controller
    {
        private PostContext db = new PostContext();

        //
        // GET: /Blog/
        public ViewResult Index()
        {
            Database.SetInitializer<PostContext>(null);
            var _posts = (from p in db.posts
                          orderby p.date descending
                        select new { p.id, p.title, p.content, p.date, p.tag, comments = (from c in db.comments where c.post == p.id select c) });
            var posts = new List<post>();
            foreach (var item in _posts)
            {
                posts.Add(new post(item.id, item.title, item.content, item.date, item.tag, item.comments.ToList()));
            }
            return View(posts);
        }
        public ActionResult Tag(string id) //id = tag 
        {
            if (id == "" | id== null)
            {
               return RedirectToAction("Index");
            }

            var _posts = (from p in db.posts
                          where p.tag.ToLower() == id.ToLower()
                          orderby p.date descending
                          select new { p.id, p.title, p.content, p.date, p.tag, comments = (from c in db.comments where c.post == p.id select c) });
            if (_posts == null) return RedirectToAction("Index");
            var posts = new List<post>();
            foreach (var item in _posts)
            {
                posts.Add(new post(item.id, item.title, item.content, item.date, item.tag, item.comments.ToList()));
            }
            return View("Index", posts);
        }
        public ViewResult Rss()
        {
            var _posts = (from p in db.posts
                          orderby p.date descending
                          select new { p.id, p.title, p.content, p.date, p.tag, comments = (from c in db.comments where c.post == p.id select c) });
            var posts = new List<post>();
            foreach (var item in _posts)
            {
                posts.Add(new post(item.id, item.title, item.content, item.date, item.tag, item.comments.ToList()));
            }
            return View(posts);

        }
        //
        // GET: /Blog/Details/5

        public ActionResult Details(int id)
        {
            var post = (from p in db.posts
                         where p.id == id
                         select new { p.id, p.title, p.content, p.date, p.tag, comments = (from c in db.comments where c.post == id select c) }).SingleOrDefault();

            if (post == null)
            {
                return View("404");
            }
            post p2 = new post(post.id, post.title, post.content, post.date,post.tag, post.comments.ToList());
            return View(p2);
        }

        //
        // GET: /Blog/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Blog/Create
        [ValidateInput(false)]
        [Authorize]
        [HttpPost]
        public ActionResult Create(post post)
        {
            if (ModelState.IsValid)
            {
                db.posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(post);
        }
        
        //
        // GET: /Blog/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            post post = db.posts.Find(id);
            return View(post);
        }

        //
        // POST: /Blog/Edit/5
        [Authorize]
        [HttpPost]
        public ActionResult Edit(post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        //
        // GET: /Blog/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            post post = db.posts.Find(id);
            return View(post);
        }

        //
        // POST: /Blog/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            post post = db.posts.Find(id);
            db.posts.Remove(post);
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