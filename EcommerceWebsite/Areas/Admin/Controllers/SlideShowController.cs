using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EcommerceWebsite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWebsite.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin", AuthenticationSchemes = "Admin_Schema")]
    [Area("admin")]
    [Route("admin/slideshow")]
    public class SlideShowController : Controller
    {
        private DatabaseContext db;

        private IHostingEnvironment ihostingEnvironment;
        public SlideShowController(DatabaseContext _db, IHostingEnvironment _ihostingEnvironment)
        {
            db = _db;
            ihostingEnvironment = _ihostingEnvironment;
        }
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            ViewBag.SlideShows = db.SlideShows.ToList();
            return View();
        }
        [Route("Add")]
        public IActionResult Add()
        {
            var slideshow = new SlideShow();
            return View("Add", slideshow);
        }
        [HttpPost]
        [Route("Add")]
        public IActionResult Add(SlideShow slideShow, IFormFile photo)
        {
            var fileName = DateTime.Now.ToString("MMddyyyyhhmmss") + photo.FileName;
            var path = Path.Combine(this.ihostingEnvironment.WebRootPath, "slideshow",
                fileName);
            var stream = new FileStream(path, FileMode.Create);
            photo.CopyToAsync(stream);
            slideShow.Name = fileName;
            slideShow.Title = slideShow.Title;
            slideShow.Description = slideShow.Description;
            slideShow.Status = slideShow.Status;
            db.SlideShows.Add(slideShow);
            db.SaveChanges();
            return RedirectToAction("Index", "slideshow", new { area = "admin" });
        }
        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult Delete(int Id)
        {
            var Slideshow = db.SlideShows.Find(Id);
            db.SlideShows.Remove(Slideshow);
            db.SaveChanges();
            return RedirectToAction("Index", "slideshow", new { area = "admin" });
        }
        [HttpGet]
        [Route("edit/{id}")]
        public IActionResult Edit(int Id)
        {
            var slideshow = db.SlideShows.Find(Id);
            return View("Edit", slideshow);
        }
        [HttpPost]
        [Route("edit/{id}")]
        public IActionResult Edit(int Id, SlideShow slideShow, IFormFile photo)
        {
            var currentSlideshow = db.SlideShows.Find(slideShow.Id);
            if(photo != null && !string.IsNullOrEmpty(photo.FileName))
            {
                var fileName = DateTime.Now.ToString("MMddyyyyhhmmss") + photo.FileName;
                var path = Path.Combine(this.ihostingEnvironment.WebRootPath, "slideshow",
                    fileName);
                var stream = new FileStream(path, FileMode.Create);
                photo.CopyToAsync(stream);
                slideShow.Name = fileName;
            }
            currentSlideshow.Title = slideShow.Title;
            currentSlideshow.Description = slideShow.Description;
            currentSlideshow.Status = slideShow.Status;
            db.SaveChanges();
            return RedirectToAction("Index", "slideshow", new { area = "admin" });
        }
    }
}