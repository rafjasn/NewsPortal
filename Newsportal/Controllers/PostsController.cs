using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using Newsportal.Models;
using System.Data.Entity;
using System.IO;

namespace Newsportal.Controllers
{
    public class PostsController : Controller
    {
        private ApplicationDbContext _context;
        

        public PostsController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var categories = _context.Categories.ToList();
            var images = _context.Images.ToList();
            var viewModel = new Post
            {
               
                Categories = categories,
            };
            return View("PostForm",viewModel);
        }


    


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Post post)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new Post
                {
                    Categories = _context.Categories.ToList(),
                 
                };

                return View("PostForm", viewModel);
            }



            //Image

            string fileName = Path.GetFileNameWithoutExtension(post.PostTitle);
            string extension = Path.GetExtension(post.ImageFile.FileName);
            fileName = fileName + "-" + DateTime.Now.ToString("yymmssfff") + extension;
            post.Image = "~/Images/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);

            post.ImageFile.SaveAs(fileName);


            //-------------------------





            if (post.Id == 0)
            {




                _context.Posts.Add(post);
                post.AddDate = DateTime.Now;
                post.LastUpdate = DateTime.Now;

             





            }
            else
            {
                var postInDb = _context.Posts.Single(p => p.Id == post.Id);
                postInDb.LastUpdate = DateTime.Now;
                //postInDb.AddDate = DateTime.Now;
                postInDb.PostTitle = post.PostTitle;
                postInDb.PostDescription = post.PostDescription;
                postInDb.Image = post.Image;
                postInDb.CategoryId = post.CategoryId;


            }



            _context.SaveChanges();
            return RedirectToAction("Index", "Posts");
        }




        // GET: Posts
        public ActionResult Index()
        {
            var posts = _context.Posts.Include(p =>p.Category).ToList();

            return View(posts);

        
        }


        //public ActionResult Details(int id)
        //{
        //    var post = _context.Posts.Include(c=>c.Category).SingleOrDefault(p => p.Id == id);
        //    if (post == null)
        //        return HttpNotFound();
        //    return View(post);
        //}

        public ActionResult Edit(int id)
        {
            var post = _context.Posts.SingleOrDefault(p => p.Id == id);
            if (post == null)
                return HttpNotFound();

            var viewModel = new Post
            {
                
                Categories = _context.Categories.ToList(),
             
                
            };
            return View("PostForm", viewModel);
        }


        //Temporary code ----------------------------------






        public ActionResult Add(Post imageModel)
        {

            string fileName = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);
            string extension = Path.GetExtension(imageModel.ImageFile.FileName);
            fileName = fileName + "-" + DateTime.Now.ToString("yymmssfff") + extension;
            imageModel.Image = "~/Images/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
            imageModel.ImageFile.SaveAs(fileName);

            _context.Posts.Add(imageModel);
            _context.SaveChanges();

            ModelState.Clear();
            return View();
        }






        //----------------------------------------------------














    }
}