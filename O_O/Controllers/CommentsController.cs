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
    public class CommentsController : Controller
    {
        private PostContext db = new PostContext();
        
        //
        // GET: /Comments/
        [Authorize]
        public ActionResult Index()
        {
            return View(db.comments.ToList());
        }

        //
        // GET: /Comments/Create/1

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Comments/Create/1

        [HttpPost]
        public ActionResult Create(comment comment)
        {
            comment.date = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Post", "Blog", new  { id = comment.post });
            }

            return PartialView(comment);
        }
        
        //
        // GET: /Comments/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            comment comment = db.comments.Find(id);
            return View(comment);
        }

        //
        // POST: /Comments/Edit/5
        [Authorize]
        [HttpPost]
        public ActionResult Edit(comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return PartialView(comment);
        }

        //
        // GET: /Comments/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            comment comment = db.comments.Find(id);
            return PartialView(comment);
        }

        //
        // POST: /Comments/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            comment comment = db.comments.Find(id);
            db.comments.Remove(comment);
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