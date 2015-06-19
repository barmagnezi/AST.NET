using MvcApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class BlogController : Controller
    {
        private PostDBContext db = new PostDBContext();

        public ActionResult Index()
        {
            return View(db.Posts);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                post.comments = "comments-";
                
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
        }
    }
}
