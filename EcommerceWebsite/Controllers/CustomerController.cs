using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceWebsite.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWebsite.Controllers
{
    [Route("customer")]
    public class CustomerController : Controller
    {
        private DatabaseContext db;

        public CustomerController(DatabaseContext _db)
        {
            db = _db;
        }
        [HttpGet]
        [Route("register")]
        public IActionResult Register()
        {
            var account = new Account();
            return View(account);
        }
        [HttpPost]
        [Route("register")]
        public IActionResult Register(Account account, RoleAccount roleAccount)
        {
            account.Password = BCrypt.Net.BCrypt.HashPassword(account.Password);
            account.Status = true;
            db.Accounts.Add(account);
            db.SaveChanges();

            roleAccount.RoleId = 2;
            roleAccount.AccountId = account.Id;
            roleAccount.Status = true;
            //var roleAccount = new RoleAccount
            //{
            //    RoleId = 2,
            //    AccountId = account.Id,
            //    Status = true
            //};
            db.RoleAccounts.Add(roleAccount);
            db.SaveChanges();
            return View("Login", "Account");
        }
    }
}