using AgriEnergy_WebApp.Models;
using AgriEnergy_WebApp.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgriEnergy_WebApp.Controllers
{
    public class AccountController : Controller
    {

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            User user = UserHelper.context.Users.FirstOrDefault(u => u.Username == username);
            if (user != null)
            {
                if (PasswordHasher.CheckPassword(password, user.PasswordHash))
                {
                    UserHelper.SetCurrentUser(user);
                    Session["CurrentUser"] = user;
                    if (user.Role.ToUpper() == "FARMER")
                    {
                        UserHelper.Farmer = UserHelper.context.Farmers.FirstOrDefault(u => u.UserId == user.UserId);
                        return RedirectToAction("Shop", "Farmer");
                    }
                    else 
                    {
                       UserHelper.Employee= UserHelper.context.Employees.FirstOrDefault(u => u.UserId == user.UserId);
                       return RedirectToAction("FarmerList", "Employee");
                    }
                   
                }
            }
            return View(); 
           
        }

        [AllowAnonymous]
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }

        [CustomAuthorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [CustomAuthorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}