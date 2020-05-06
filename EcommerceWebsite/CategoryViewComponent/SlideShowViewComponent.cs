using EcommerceWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.SlideShowViewComponent
{
    [ViewComponent(Name = "SlideShow")]
    public class SlideShowViewComponent : ViewComponent
    {
        private DatabaseContext db;
        public SlideShowViewComponent(DatabaseContext _db)
        {
            db = _db;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<SlideShow> slideshow = db.SlideShows.Where(c => c.Status).ToList();
            return View("Index", slideshow);
        }
    }
}
