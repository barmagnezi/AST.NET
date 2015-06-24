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
                post.comments = "comments-";
                post.date = DateTime.Today.ToString();
                db.Posts.Add(post);
                db2.SaveChanges();
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
            
            Console.WriteLine("id:" + id);
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            var allComments = from m in db2.Comments
                              select m;

           allComments = allComments.Where(s => s.postId == id);
            if (allComments==null)
                return HttpNotFound();
            return View(allComments); 
            /*
            List<Comment> comments = new List<Comment>();
            string[] commentsArg=post.comments.Split('-');
            if (commentsArg[0].Equals("comments"))
            {
                string[] idComments=commentsArg[1].Split(',');
                foreach (var idcom in idComments)
                {
                    
                }
                return View(comments);
            }
            return HttpNotFound();*/
        }

        public ActionResult DeleteComment(long PostId = 0, long CommentId = 0)
        {
            Comment com = db2.Comments.Find(CommentId);
            if (com == null)
            {
                return HttpNotFound();
            }
            db2.Comments.Remove(com);
            db2.SaveChanges();
            return RedirectToAction("Index");
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