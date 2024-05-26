using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgriEnergy_WebApp.Models
{
    public class Employee
    {
        [Key, ForeignKey("User")]
        public int UserId { get; set; }

        [StringLength(255)]
        public string Department { get; set; }

        [StringLength(255)]
        public string Position { get; set; }

        public virtual User User { get; set; }
    }
}