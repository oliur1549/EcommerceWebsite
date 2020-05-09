using EcommerceWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.LatestProductViewComponent
{
    [ViewComponent(Name = "LatestProduct")]
    public class LatestProductViewComponent : ViewComponent
    {
        private DatabaseContext db;
        public LatestProductViewComponent(DatabaseContext _db)
        {
            db = _db;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Product> products = db.Products.OrderByDescending(p => p.Id).Where(p => p.Status && p.Featured).Take(2).ToList();
            return View("Index", products);
        }
    }
}
