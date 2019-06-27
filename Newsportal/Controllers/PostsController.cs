using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newsportal.Models;

namespace Newsportal.Controllers
{
    public class PostsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();



        public ActionResult Index()
        {
            return View();
        }



        // GET: Posts1
        public ActionResult List()
        {
            var posts = db.Posts.Include(p => p.Category);
            return View(posts.ToList());
        }

        // GET: Posts1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Posts1/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        // POST: Posts1/Create
 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Post post)
        {
            if (ModelState.IsValid)
            {

                //Image -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

                string fileName = Path.GetFileNameWithoutExtension(post.PostTitle);
                string extension = Path.GetExtension(post.ImageFile.FileName);
                fileName = fileName + "-" + DateTime.Now.ToString("yymmssfff") + extension;
                post.Image = "~/Images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);

                post.ImageFile.SaveAs(fileName);


                //-------------------------
                db.Posts.Add(post);
                post.AddDate = DateTime.Now;
                post.LastUpdate = DateTime.Now;
         


                db.SaveChanges();
                return RedirectToAction("List");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", post.CategoryId);
            return View(post);
        }

        // GET: Posts1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", post.CategoryId);
            return View(post);
        }

        // POST: Posts1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Post post)
        {
            if (ModelState.IsValid)
            {

                //Image

                string fileName = Path.GetFileNameWithoutExtension(post.PostTitle);
                string extension = Path.GetExtension(post.ImageFile.FileName);
                fileName = fileName + "-" + DateTime.Now.ToString("yymmssfff") + extension;
                post.Image = "~/Images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);

                post.ImageFile.SaveAs(fileName);


                //-------------------------

                db.Entry(post).State = EntityState.Modified;
                var date = post.AddDate;
                post.LastUpdate = DateTime.Now;


                db.SaveChanges();
                return RedirectToAction("List");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", post.CategoryId);
            return View(post);
        }

        // GET: Posts1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
