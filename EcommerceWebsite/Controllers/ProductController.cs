using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using X.PagedList;

namespace EcommerceWebsite.Controllers
{
    [Route("product")]
    public class ProductController : Controller
    {
        private DatabaseContext db;

        public ProductController(DatabaseContext _db)
        {
            db = _db;
        }

        [Route("details/{id}")]
        public IActionResult Details(int id)
        {
            var product = db.Products.Find(id);
            ViewBag.Product = product;
            var featuredProduct = db.Photos.FirstOrDefault(p => p.Status && p.Featured);
            ViewBag.FeaturedProduct = featuredProduct == null ? "no-image.jpg" : featuredProduct.Name;
            ViewBag.ProductImages = product.Photos.Where(p => p.Status).ToList();
            ViewBag.RelatedProducts = db.Products.Where(p => p.CategoryId == product.CategoryId && p.Id != id && p.Status).ToList();
            return View("details");
        }
        [Route("category/{id}")]
        public IActionResult Category(int id, int? page)
        {
            var pagenumber = page ?? 1;
            var category = db.Categories.Find(id);
            ViewBag.Category = category;
            ViewBag.CountProduct = category.Products.Count(p => p.Status);
            ViewBag.Products = category.Products.Where(p => p.Status).ToList().ToPagedList(pagenumber, 6);
            return View("category");
        }
        [HttpGet]
        [Route("search")]
        public IActionResult Search(string Keyword,int categoryId, int? page)
        {
            var pagenumber = page ?? 1;
            var products = db.Products.Where(p => p.Name.Contains(Keyword) && p.CategoryId == categoryId && p.Status).ToList();
            ViewBag.Keyword = Keyword;
            ViewBag.categoryId = categoryId;
            ViewBag.CountProducts = products.Count;
            ViewBag.Products = products.ToPagedList(pagenumber, 6);
            return View("Search");
        }
    }
}