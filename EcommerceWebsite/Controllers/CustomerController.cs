using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using EcommerceWebsite.Models;
using EcommerceWebsite.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWebsite.Controllers
{
    [Route("customer")]
    public class CustomerController : Controller
    {
        private DatabaseContext db;
        private SecurityManager securityManager = new SecurityManager();
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
        public IActionResult Register(Account account)
        {
            var exists = db.Accounts.Count(a => a.Username.Equals(account.Username)) >0;
            if (!exists)
            {
                account.Password = BCrypt.Net.BCrypt.HashPassword(account.Password);
                account.Status = true;
                db.Accounts.Add(account);
                db.SaveChanges();

                var roleAccount = new RoleAccount
                {
                    RoleId = 2,
                    AccountId = account.Id,
                    Status = true
                };
                db.RoleAccounts.Add(roleAccount);
                db.SaveChanges();
                return View("Login", "Account");
            }
            else
            {
                ViewBag.error = "Username exists";
                return View("Register", account);
            }
            
        }
        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login(string username, string password)
        {
            var account = processingLogin(username, password);
            if (account != null)
            {
                securityManager.SignIn(this.HttpContext, account, "User_Schema");
                return RedirectToAction("dashboard", "customer");
            }
            else
            {
                ViewBag.error = "Invaid Account";
                return View("Login");
            }
        }
        private Account processingLogin(string username, string password)
        {
            var account = db.Accounts.SingleOrDefault(a => a.Username.Equals(username) && a.Status == true);
            if (account != null)
            {
                var roleAccount = account.RoleAccounts.FirstOrDefault(); 
                if (roleAccount.RoleId == 2 && roleAccount.Status==true && BCrypt.Net.BCrypt.Verify(password, account.Password))
                {
                    return account;
                }
            }

            return null;
        }
        [Route("signout")]
        public IActionResult SignOut()
        {
            securityManager.SignOut(this.HttpContext, "User_Schema");
            return RedirectToAction("login", "customer");
        }
        [Authorize(Roles= "Customer", AuthenticationSchemes = "User_Schema")]
        [HttpGet]
        [Route("profile")]
        public IActionResult Profile()
        {
            var user = User.FindFirst(ClaimTypes.Name);
            var customer = db.Accounts.SingleOrDefault(s => s.Username.Equals(user.Value));
            return View("profile", customer);
        }
        [Authorize(Roles = "Customer", AuthenticationSchemes = "User_Schema")]
        [HttpPost]
        [Route("profile")]
        public IActionResult Profile(Account account)
        {
            var currentCustomer = db.Accounts.Find(account.Id);
            if (!string.IsNullOrEmpty(account.Password))
            {
                currentCustomer.Password = BCrypt.Net.BCrypt.HashPassword(account.Password);
            }
            currentCustomer.Username = account.Username;
            currentCustomer.FullName = account.FullName;
            currentCustomer.Email = account.Email;
            currentCustomer.Address = account.Address;
            currentCustomer.Mobile = account.Mobile;
            db.SaveChanges();
            return View("profile",currentCustomer);
        }
        [Authorize(Roles = "Customer", AuthenticationSchemes = "User_Schema")]
        [HttpGet]
        [Route("dashboard")]
        public IActionResult Dashboard()
        {
            return View("dashboard");
        }
        [HttpGet]
        [Route("accessdenied")]
        public IActionResult AccessDenied()
        {
            return View("accessdenied");
        }
        [Authorize(Roles = "Customer", AuthenticationSchemes = "User_Schema")]
        [HttpGet]
        [Route("history")]
        public IActionResult History()
        {
            var user = User.FindFirst(ClaimTypes.Name);
            var customer = db.Accounts.SingleOrDefault(a => a.Username.Equals(user.Value));
            ViewBag.Invoices = customer.Invoices.OrderByDescending(i => i.Id).ToList();
            return View("History");
        }
        [Authorize(Roles = "Customer", AuthenticationSchemes = "User_Schema")]
        [HttpGet]
        [Route("details/{id}")]
        public IActionResult Details(int id)
        {

            ViewBag.InvoiceDetails = db.InvoiceDetails.Where(i=> i.InvoiceId==id).ToList();
            return View("Details");
        }
    }
}