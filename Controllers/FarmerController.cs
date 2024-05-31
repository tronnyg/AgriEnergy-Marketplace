using AgriEnergy_WebApp.Models;
using AgriEnergy_WebApp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgriEnergy_WebApp.Controllers
{
    [CustomAuthorize]
    public class FarmerController : Controller
    {

        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult Profile()
        {
            return View();
        }

        public ActionResult Settings()
        {
            return View();
        }

        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product product)
        {

            if (ModelState.IsValid)
            {
               
                if (product.DateAdded == DateTime.MinValue)
                {
                    product.DateAdded = DateTime.Now;
                }

                product.Farmer = UserHelper.Farmer;

                UserHelper.context.products.Add(product);
                UserHelper.context.SaveChanges();

                return RedirectToAction("Shop");
            }
            return View();
        }


        public ActionResult Shop()
        {
            var userID = UserHelper.Farmer.FarmerId;
            var viewModel = new StoreViewModel()
            {
                farmer = UserHelper.Farmer,
                Products = UserHelper.context.products.Where(p => p.FarmerId == userID).ToList()
            };
            return View(viewModel);
        }
    }
}