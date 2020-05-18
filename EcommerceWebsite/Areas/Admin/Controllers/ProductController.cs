using System;
using System.Collections.Generic;
using System.Linq;
using EcommerceWebsite.Areas.Admin.Models.ProductViewModel;
using EcommerceWebsite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EcommerceWebsite.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin", AuthenticationSchemes = "Admin_Schema")]
    [Area("admin")]
    [Route("admin/product")]
    public class ProductController : Controller
    {
        private DatabaseContext db;

        public ProductController(DatabaseContext _db)
        {
            db = _db;
        }
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            ViewBag.Product = db.Products.ToList();
            return View();
        }
        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            var productModel = new ProductViewModel();
            productModel.Product = new Product();
            productModel.Categories = new List<SelectListItem>();
            var categories = db.Categories.ToList();
            foreach (var category in categories)
            {
                var group = new SelectListGroup { Name = category.Name };
                if (category.InverseParents != null && category.InverseParents.Count > 0)
                {
                    foreach (var subcategory in category.InverseParents)
                    {
                        var selectListItem = new SelectListItem
                        {
                            Text = subcategory.Name,
                            Value = subcategory.Id.ToString(),
                            Group = group
                        };
                        productModel.Categories.Add(selectListItem);
                    }
                }
            }

            return View("Add", productModel);
        }
        [HttpPost]
        [Route("add")]
        public IActionResult Add(ProductViewModel productViewModel)
        {
            db.Products.Add(productViewModel.Product);
            db.SaveChanges();
            var defaultPhoto = new Photo
            {
                Name = "no-image.jpg",
                Status = true,
                ProductId = productViewModel.Product.Id,
                Featured = true
            };
            db.Photos.Add(defaultPhoto);
            db.SaveChanges();
            return RedirectToAction("Index", "product", new { area = "admin" });
        }
        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult Delete(int Id)
        {
            try
            {
                var product = db.Products.Find(Id);
                db.Products.Remove(product);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }

            return RedirectToAction("Index", "product", new { area = "admin" });
        }
        [HttpGet]
        [Route("edit/{Id}")]
        public IActionResult Edit(int Id)
        {
            var productModel = new ProductViewModel();
            productModel.Product = db.Products.Find(Id);
            productModel.Categories = new List<SelectListItem>();
            var categories = db.Categories.ToList();
            foreach (var category in categories)
            {
                var group = new SelectListGroup { Name = category.Name };
                if (category.InverseParents != null && category.InverseParents.Count > 0)
                {
                    foreach (var subcategory in category.InverseParents)
                    {
                        var selectListItem = new SelectListItem
                        {
                            Text = subcategory.Name,
                            Value = subcategory.Id.ToString(),
                            Group = group
                        };
                        productModel.Categories.Add(selectListItem);
                    }
                }
            }
            return View("Edit", productModel);
        }
        [HttpPost]
        [Route("edit/{id}")]
        public IActionResult Edit( ProductViewModel productViewModel)
        {
            db.Entry(productViewModel.Product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "product", new { area = "admin" });
        }
    }
}