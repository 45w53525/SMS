using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SMS.Models;

namespace SMS.Controllers
{
    public class AccountController : Controller
    {
        StudentDBContext db = new StudentDBContext();
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Register r)
        {
            if (ModelState.IsValid == true)
            {
                db.Registers.Add(r);
                int n = db.SaveChanges();
                if (n != 0)
                {
                    TempData["Insert"] = "<script>alert('Register SuccessFully!!')</script>";
                    return RedirectToAction("Login");
                }
                else
                {
                    TempData["Insert"] = "<script>alert('Register Fail!!')</script>";
                }
            }
            return View();    
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Register lg)
        {
                FormsAuthentication.SetAuthCookie(lg.Email, false);
                bool isValid = db.Registers.Any(x => x.Email ==lg.Email && x.Password == lg.Password);
                if (isValid)
                {
                    return RedirectToAction("Index","Student");
                }
                ModelState.AddModelError("", "Invalid LoginId and Password");
                return View();
           }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("login");
        }
    }
}