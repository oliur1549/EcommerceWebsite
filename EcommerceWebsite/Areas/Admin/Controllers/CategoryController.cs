using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceWebsite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWebsite.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin", AuthenticationSchemes = "Admin_Schema")]
    [Area("admin")]
    [Route("admin/category")]
    public class CategoryController : Controller
    {
        private DatabaseContext db;
        
        public CategoryController(DatabaseContext _db)
        {
            db = _db;
        }
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            ViewBag.categories = db.Categories.Where(c => c.Parent == null).ToList();
            return View();
        }
        
        [Route("Add")]
        public IActionResult Add()
        {
            var category = new Category();
            return View("Add", category);
        }
        [HttpPost]
        [Route("Add")]
        public IActionResult Add(Category category)
        {
            category.Parent = null;
            db.Categories.Add(category);
            db.SaveChanges();
            return RedirectToAction("Index", "category", new { area = "admin" });
        }
        [HttpGet]
        [Route("edit/id")]
        public IActionResult Edit(int Id)
        {
            var category = db.Categories.Find(Id);
            return View("Edit", category);
        }
        [HttpPost]
        [Route("edit/id")]
        public IActionResult Edit(int Id, Category category)
        {
            var currentCategory = db.Categories.Find(Id);
            currentCategory.Name = category.Name;
            currentCategory.Status = category.Status;
            db.SaveChanges();
            return RedirectToAction("Index", "category", new { area = "admin" });
        }
        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult Delete(int Id)
        {
            var Category = db.Categories.Find(Id);
            db.Categories.Remove(Category);
            db.SaveChanges();
            return RedirectToAction("Index", "category", new { area = "admin" });
        }
        [HttpGet]
        [Route("addsubcategory/{id}")]
        public IActionResult AddSubcategory(int Id)
        {
            var subcategory = new Category
            {
                ParentId = Id
            };
            return View("AddSubcategory", subcategory);
        }
        [HttpPost]
        [Route("addsubcategory/{categoryid}")]
        public IActionResult AddSubcategory(int categoryid, Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
            return RedirectToAction("Index", "category", new { area = "admin" });
        }
    }
}