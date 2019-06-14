using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;
using Newsportal.Models;
using System.Data.Entity;


namespace Newsportal.Controllers
{
    public class ImagesController : Controller
    {
        private ApplicationDbContext _context;
        public ImagesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Images
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Image imageModel)
        {

            string fileName = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);
            string extension = Path.GetExtension(imageModel.ImageFile.FileName);
            fileName = fileName + "-" + DateTime.Now.ToString("yymmssfff") + extension;
            imageModel.Url = "~/Images/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
            imageModel.ImageFile.SaveAs(fileName);

            _context.Images.Add(imageModel);
            _context.SaveChanges();
            
            ModelState.Clear();
            return View();
        }

        public ActionResult View(int id)
        {
            Image imageModel = new Image();

            imageModel = _context.Images.Where(i => i.Id == id).FirstOrDefault();

            return View(imageModel);
        }

    }
}