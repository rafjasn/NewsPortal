using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newsportal.Models;
using Newsportal.ViewModels;

namespace Newsportal.Controllers
{
    public class HomeController : Controller
    {

        private ApplicationDbContext _context;


        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

     
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Index(int page = 1)
        {

            PostsViewModel postView = new PostsViewModel();
            postView.PostsPerPage = 3;
            postView.Posts = _context.Posts.Include(p => p.Category);
            postView.CurrentPage = page;

            return View(postView);


        }
        

        public ActionResult Categories()
        {
            var posts = _context.Categories.ToList();
            return View("Categories",posts);
        }


        public ActionResult Category(int id, int page = 1)
        {


            //var post = _context.Posts.Include(p => p.Category).Where(p => p.CategoryId == id).ToList();
            PostsViewModel postView = new PostsViewModel();
            postView.PostsPerPage = 3;
            postView.Posts = _context.Posts.Include(p => p.Category).Where(p => p.CategoryId == id);
            postView.CurrentPage = page;

            return View(postView);
        }

        public ActionResult Details(int id)
        {
            var post = _context.Posts.Include(c => c.Category).SingleOrDefault(p => p.Id == id);
            if (post == null)
                return HttpNotFound();
            return View(post);
        }


        [ChildActionOnly]
        public ActionResult Sidebar()
        {
           
            var partialViewModel = _context.Posts.Include(p => p.Category).ToList();
            return PartialView(partialViewModel);
        }


        public ActionResult Search(string search, int page = 1)
        {
        

            PostsViewModel postView = new PostsViewModel();
            postView.PostsPerPage = 3;
            postView.Posts = _context.Posts.Include(p => p.Category).Where(p => p.PostTitle.Contains(search) || search == null);
            postView.CurrentPage = page;

            return View(postView);
        }


    }
}