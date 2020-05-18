using EcommerceWebsite.Helpers;
using EcommerceWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.CategoryViewComponent
{
    [ViewComponent(Name = "CartLeft")]
    public class CartLeftViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (SessionHelper.GetObjectAsJson<List<Item>>(HttpContext.Session, "cart") == null)
            {
                ViewBag.CountItems = 0;
                ViewBag.Total = 0;
            }
            else
            {
                List<Item> cart = SessionHelper.GetObjectAsJson<List<Item>>(HttpContext.Session, "cart");
                ViewBag.CountItems = cart.Count;
                ViewBag.Total = cart.Sum(it => it.Quantity * it.Price);
            }
            return View("Index");
        }
    }
}
