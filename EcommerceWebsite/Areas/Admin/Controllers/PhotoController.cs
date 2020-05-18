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
    [Route("admin/photo")]
    public class PhotoController : Controller
    {
        private DatabaseContext db;

        private IHostingEnvironment ihostingEnvironment;
        public PhotoController(DatabaseContext _db, IHostingEnvironment _ihostingEnvironment)
        {
            db = _db;
            ihostingEnvironment = _ihostingEnvironment;
        }
        [Route("index/{id}")]
        public IActionResult Index(int id)
        {
            ViewBag.Product = db.Products.Find(id);
            ViewBag.Photos = db.Photos.Where(p => p.ProductId == id).ToList();
            return View();
        }
        [HttpGet]
        [Route("add/{id}")]
        public IActionResult Add(int id)
        {
            ViewBag.Product = db.Products.Find(id);
            var photo = new Photo
            {
                ProductId = id
            };
            return View("Add", photo);
        }
        [HttpPost]
        [Route("add/{ProductId}")]
        public IActionResult Add(int ProductId, Photo photo, IFormFile fileUpload)
        {
            var fileName = DateTime.Now.Date.ToString("MMddyyyyhhmmss") + fileUpload.FileName;
            var path = Path.Combine(this.ihostingEnvironment.WebRootPath, "products",
                fileName);
            var stream = new FileStream(path, FileMode.Create);
            fileUpload.CopyToAsync(stream);
            photo.Name = fileName;
            photo.Status = photo.Status;
            photo.Featured = photo.Featured;
            //photo.ProductId = photo.ProductId;
            db.Photos.Add(photo);
            db.SaveChanges();
            return RedirectToAction("index", "photo", new { area = "admin", Id = ProductId });
        }
        [HttpGet]
        [Route("delete/{id}/productId")]
        public IActionResult Delete(int Id, int productId)
        {
            var photo = db.Photos.Find(Id);
            db.Photos.Remove(photo);
            db.SaveChanges();
            return RedirectToAction("Index", "photo", new { area = "admin", Id = productId });
        }
        [HttpGet]
        [Route("edit/{id}/{productId}")]
        public IActionResult Edit(int Id, int productId)
        {
            ViewBag.Product = db.Products.Find(productId);
            var photo = db.Photos.Find(Id);
            return View("Edit", photo);
        }
        [HttpPost]
        [Route("edit/{id}/{productId}")]
        public IActionResult Edit(int Id, int productId, Photo photo, IFormFile fileUpload)
        {
            var currentPhoto = db.Photos.Find(photo.Id);
            if (fileUpload != null && !string.IsNullOrEmpty(fileUpload.FileName))
            {
                var fileName = DateTime.Now.ToString("MMddyyyyhhmmss") + fileUpload.FileName;
                var path = Path.Combine(this.ihostingEnvironment.WebRootPath, "products",
                    fileName);
                var stream = new FileStream(path, FileMode.Create);
                fileUpload.CopyToAsync(stream);
                photo.Name = fileName;
            }
            currentPhoto.Status = photo.Status;
            currentPhoto.Featured = photo.Featured;
            db.SaveChanges();
            return RedirectToAction("Index", "photo", new { area = "admin", Id = productId });
        }
        [HttpGet]
        [Route("SetFeatured/{id}/{productId}")]
        public IActionResult SetFeatured(int Id, int productId)
        {
            var product = db.Products.Find(productId);
            product.Photos.ToList().ForEach(p =>
            {
                p.Featured = false;
                db.Entry(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            });

            var photo = db.Photos.Find(Id);
            photo.Featured = true;
            db.SaveChanges();
            return RedirectToAction("index", "photo", new { area = "admin", Id = productId });
        }
    }
}