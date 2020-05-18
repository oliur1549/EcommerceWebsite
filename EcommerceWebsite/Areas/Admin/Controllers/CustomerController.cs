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
    [Route("admin/customer")]
    public class CustomerController : Controller
    {
        private DatabaseContext db;

        public CustomerController(DatabaseContext _db)
        {
            db = _db;
        }
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            ViewBag.customers = db.Accounts.Where(c=>c.RoleAccounts.FirstOrDefault().RoleId==2).ToList();
            return View();
        }
        [HttpGet]
        [Route("edit/{id}")]
        public IActionResult Edit(int id)
        {
            var customers = db.Accounts.Find(id);
            return View("edit",customers);
        }
        [HttpPost]
        [Route("edit/{id}")]
        public IActionResult Edit(int Id, Account account)
        {
            var currentCustomers = db.Accounts.Find(Id);
            currentCustomers.Username = account.Username;
            if (!string.IsNullOrEmpty(account.Password))
            {
                currentCustomers.Password = BCrypt.Net.BCrypt.HashPassword(account.Password);
            }
            currentCustomers.FullName = account.FullName;
            currentCustomers.Email = account.Email;
            currentCustomers.Address = account.Address;
            currentCustomers.Mobile = account.Mobile;
            currentCustomers.Status = account.Status;
            db.SaveChanges();
            return RedirectToAction("Index", "customer", new { area = "admin" });
        }
        
    }
}