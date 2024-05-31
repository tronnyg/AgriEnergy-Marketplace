using AgriEnergy_WebApp.Models;
using AgriEnergy_WebApp.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgriEnergy_WebApp.Controllers
{
    [CustomAuthorize]
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FarmerList()
        {
            var viewModel = UserHelper.context.Farmers.Where(f => f.User.Role.ToUpper() == "FARMER").ToList();
            return View(viewModel);
        }

        public ActionResult FarmerAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FarmerAdd(string username, string password, string email, string name, string surname)
        {
            Debug.WriteLine("Hello");
            var user = new User
            {
                Name = name,
                Surname = surname,
                Email = email,
                Username = username,
                PasswordHash = PasswordHasher.HashPassword(password),
                Role = "FARMER"
            };

            var farmer = new Farmer
            {
                User = user,
            };
            UserHelper.context.Users.Add(user);
            UserHelper.context.Farmers.Add(farmer);
            UserHelper.context.SaveChanges();

            return RedirectToAction("FarmerList");
        }

        public ActionResult Profile()
        {
            return View();
        }


        public ActionResult FarmerProducts(DateTime? startDate, DateTime? endDate)
        {
            var products = UserHelper.context.products.Include("Farmer.User").AsQueryable();

            if (startDate.HasValue)
            {
                products = products.Where(p => p.DateAdded >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                products = products.Where(p => p.DateAdded <= endDate.Value);
            }

            return View(products.ToList());
        }
    }
}