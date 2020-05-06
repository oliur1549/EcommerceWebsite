using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceWebsite.Models;
using EcommerceWebsite.Security;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EcommerceWebsite.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/login")]
    public class LoginController : Controller
    {
        private DatabaseContext db;
        private SecurityManager securityManager = new SecurityManager();
        public LoginController(DatabaseContext _db)
        {
            db = _db;
        }
        
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("process")]
        public IActionResult Process(string username, string password)
        {
            var account = processingLogin(username, password);
            if(account != null)
            {
                securityManager.SignIn(this.HttpContext, account);
                return RedirectToAction("index", "dashboard", new { area = "admin" });
            }
            else
            {
                ViewBag.error = "Invaid Account";
                return View("index");
            }
        }

        private Account processingLogin(string username, string password)
        {
            var account = db.Accounts.SingleOrDefault(a => a.Username.Equals(username) && a.Status==true);
            if (account != null)
            {
                if (BCrypt.Net.BCrypt.Verify(password, account.Password))
                {
                    return account;
                }
            }
            
            return null;
        }
        
        [Route("signout")]
        public IActionResult SignOut()
        {
            securityManager.SignOut(this.HttpContext);
            return RedirectToAction("index", "login", new { area = "admin" });
        }
        [HttpGet]
        [Route("profile")]
        public IActionResult Profile()
        {
            var user = User.FindFirst(ClaimTypes.Name);
            var username = user.Value;
            var account = db.Accounts.SingleOrDefault(a => a.Username.Equals(username));
            return View("profile", account);
        }
        [HttpPost]
        [Route("profile")]
        public IActionResult Profile(Account account)
        {
            var currentAccount = db.Accounts.SingleOrDefault(a => a.Id ==account.Id);
            if (!string.IsNullOrEmpty(account.Password))
            {
                currentAccount.Password = BCrypt.Net.BCrypt.HashPassword(account.Password);
            }
            currentAccount.Username = account.Username;
            currentAccount.Email = account.Email;
            currentAccount.FullName = account.FullName;
            db.SaveChanges();
            ViewBag.msg = "Done";
            return View();
        }
        [Route("accessdenied")]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}