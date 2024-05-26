using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AgriEnergy_WebApp.Models
{
    public class Farmer
    {
        [Key, ForeignKey("User")]
        public int UserId { get; set; }

        [StringLength(255)]
        public string FarmName { get; set; }

        [StringLength(255)]
        public string ContactEmail { get; set; }

        [StringLength(20)]
        public string ContactNumber { get; set; }

        public string AboutFarm { get; set; }

        [StringLength(255)]
        public string FarmLocation { get; set; }

        public virtual User User { get; set; }
    }
}