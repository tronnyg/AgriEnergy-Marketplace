using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgriEnergy_WebApp.Models
{
    public class StoreViewModel
    {
        public Farmer farmer { get; set; }
        public List<Product> Products { get; set; }
    }
}