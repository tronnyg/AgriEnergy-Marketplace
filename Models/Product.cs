using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgriEnergy_WebApp.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string Description { get; set; }

        [ForeignKey("Farmer")]
        public int FarmerId { get; set; }

        public string Category { get; set; }

        public int Quantity { get; set; }

        public DateTime DateAdded { get; set; }

        public string ImageUrl { get; set; }

        public virtual Farmer Farmer { get; set; }
    }
}