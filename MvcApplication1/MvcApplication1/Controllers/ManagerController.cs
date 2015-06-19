using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class ManagerController : Controller
    {
        private PostDBContext db = new PostDBContext();
        private CommentDBContext db2 = new CommentDBContext();
        //
        // GET: /Manager/

        public ActionResult Index()
        {
            return View(db.Posts.ToList());
        }

        //
        // GET: /Manager/Details/5

        public ActionResult Details(long id = 0)
        {
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        //
        // GET: /Manager/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Manager/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(post);
        }

        //
        // GET: /Manager/Edit/5

        public ActionResult Edit(long id = 0)
        {
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        //
        // POST: /Manager/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }
        //comments
        public ActionResult Comments(long id = 0)
        {
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post.comments);
        }

        public ActionResult DeleteComment(long PostId = 0, long CommentId = 0)
        {
            Post post = db.Posts.Find(PostId);

            if (post == null)
            {
                return HttpNotFound();
            }
            Comment com = db2.Comments.Find(CommentId);
            if (com == null)
            {
                return HttpNotFound();
            }
            post.comments.Remove(com);
            db2.Comments.Remove(com);
            db.SaveChanges();
            db2.SaveChanges();
            return View(post.comments);
        }
        
        //
        // GET: /Manager/Delete/5

        public ActionResult Delete(long id = 0)
        {
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        //
        // POST: /Manager/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
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