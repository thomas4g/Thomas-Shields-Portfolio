using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using O_O.Models;
using Stacky;
namespace O_O.Controllers
{ 
    public class BlogController : Controller
    {
        private PostContext db = new PostContext();

        //
        // GET: /Blog/
        public ActionResult Index(int page = 1)
        {
            int pageSize = 5;
            var _posts = (from p in db.posts
                          orderby p.date descending
                          select new { p.id, p.title, p.content, p.date, p.tag, comments = (from c in db.comments where c.post == p.id select c) });
            int numPosts = _posts.Count();
            if (pageSize * (page - 1) >= numPosts) return RedirectToAction("Index", new { page = 1 });
            _posts = _posts.Skip((page - 1) * pageSize).Take(pageSize);
            var posts = new List<post>();
            foreach (var item in _posts)
            {
                posts.Add(new post(item.id, item.title, item.content, item.date, item.tag, item.comments.ToList()));
            }
            ViewBag.pageNum = page;
            ViewBag.numPosts = numPosts;
            ViewBag.pageSize = pageSize;
            return View(posts);
        }
        public ActionResult StackOverflow()
        {
            StackyClient c = new StackyClient("1.1", "Lu0luEh2cUu9UoasZwXdhw", Stacky.Sites.StackOverflow, new UrlClient(), new JsonProtocol());
            Stacky.User u = c.GetUser(719312);
            List<UserEvent> stuff = c.GetUserTimeline(u.Id, 1, 15).ToList();
            return PartialView(stuff);
        }
        public ActionResult Tag(string tag, int page = 1) //id = tag 
        {

            if (tag == "" | tag== null)
            {
               return RedirectToAction("Index");
            }
            int pageSize = 5;
            var _posts = (from p in db.posts
                          where p.tag.ToLower() == tag.ToLower()
                          orderby p.date descending
                          select new { p.id, p.title, p.content, p.date, p.tag, comments = (from c in db.comments where c.post == p.id select c) });
            if (_posts == null) return RedirectToAction("Index", new { page = 1 });
            int numPosts = _posts.Count();
            if (pageSize * (page - 1) >= numPosts) return RedirectToAction("Index", new { page = 1 });
            _posts = _posts.Skip((page - 1) * pageSize).Take(pageSize);
            var posts = new List<post>();
            foreach (var item in _posts)
            {
                posts.Add(new post(item.id, item.title, item.content, item.date, item.tag, item.comments.ToList()));
            } 
            ViewBag.pageNum = page;
            ViewBag.numPosts = numPosts;
            ViewBag.pageSize = pageSize;

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
        public ActionResult Post(int id)
        {
            var post = (from p in db.posts
                         where p.id == id
                         select new { p.id, p.title, p.content, p.date, p.tag, comments = (from c in db.comments where c.post == id select c) }).SingleOrDefault();

            if (post == null)
            {
                return View("404");
            }
            post p2 = new post(post.id, post.title, post.content, post.date,post.tag, post.comments.ToList());
            return View("Details",p2);
        }
        //
        // GET: /Blog/Create
        [Authorize]
        public ActionResult Create()
        {
            return View(new post());
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