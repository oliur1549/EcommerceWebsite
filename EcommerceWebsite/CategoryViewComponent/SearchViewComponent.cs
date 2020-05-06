﻿using EcommerceWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.SearchViewComponent
{
    [ViewComponent(Name ="Search")]
    public class SearchViewComponent : ViewComponent
    {
        private DatabaseContext db;
        public SearchViewComponent(DatabaseContext _db)
        {
            db = _db;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Category> categories = db.Categories.Where(c => c.Status && c.Parent==null).ToList();
            return View("Index", categories);
        }
    }
}