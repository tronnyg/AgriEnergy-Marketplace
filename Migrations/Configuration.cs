namespace AgriEnergy_WebApp.Migrations
{
    using AgriEnergy_WebApp.Models;
    using AgriEnergy_WebApp.Utilities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AgriEnergy_WebApp.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AgriEnergy_WebApp.Models.ApplicationDbContext context)
        {
            context.Employees.RemoveRange(context.Employees);
            context.Farmers.RemoveRange(context.Farmers);
            context.products.RemoveRange(context.products);
            context.SaveChanges();

            var users = new List<User>
        {
            new User
            {
                Username = "employee1",
                PasswordHash = PasswordHasher.HashPassword("admin@123"),
                Email = "employee1@example.com",
                Name = "John",
                Surname = "Doe",
                UserProfilePicture = "employee1.jpg",
                Role = "Employee"
            },
            new User
            {
                Username = "farmer1",
                PasswordHash = PasswordHasher.HashPassword("jsmith@123"),
                Email = "farmer1@example.com",
                Name = "Jane",
                Surname = "Smith",
                UserProfilePicture = "farmer1.jpg",
                Role = "Farmer"
            },
            new User
            {
                Username = "farmer2",
                PasswordHash = PasswordHasher.HashPassword("ejohn@123"),
                Email = "farmer2@example.com",
                Name = "Emily",
                Surname = "Johnson",
                UserProfilePicture = "farmer2.jpg",
                Role = "Farmer"
            }
        };

            context.Users.AddRange(users);
            context.SaveChanges();

            var employees = new List<Employee>
        {
            new Employee
            {
                UserId = users[0].UserId,
                Department = "HR",
                Position = "Manager"
            }
        };

            context.Employees.AddRange(employees);

            var farmers = new List<Farmer>
        {
            new Farmer
            {
                UserId = users[1].UserId,
                FarmName = "Green Acres",
                ContactNumber = "123-456-7890",
                StoreImageUrl = "greenacres.jpg",
                AboutFarm = "Organic farming",
                FarmLocation = "Rural Area"
            },
            new Farmer
            {
                UserId = users[2].UserId,
                FarmName = "Sunny Fields",
                ContactNumber = "098-765-4321",
                StoreImageUrl = "sunnyfields.jpg",
                AboutFarm = "Dairy farming",
                FarmLocation = "Countryside"
            }
        };

            context.Farmers.AddRange(farmers);
            context.SaveChanges();


    var products = new List<Product>
    {
        // Products for Farmer 1
        new Product
        {
            Name = "Apples",
            Price = 2.5m,
            Description = "Freshly harvested from our orchard.",
            Category = "Fruits",
            Quantity = 50,
            DateAdded = DateTime.Now.AddDays(-7),
            ImageUrl = "apples.jpg",
            FarmerId = 1 // Assuming FarmerId for Farmer 1 is 1
        },
        new Product
        {
            Name = "Carrots",
            Price = 1.75m,
            Description = "Locally grown and organic.",
            Category = "Vegetables",
            Quantity = 30,
            DateAdded = DateTime.Now.AddDays(-10),
            ImageUrl = "carrots.jpg",
            FarmerId = 1
        },
        // Add more products for Farmer 1 here...
        new Product
        {
            Name = "Tomatoes",
            Price = 1.0m,
            Description = "Ripe and juicy tomatoes from our farm.",
            Category = "Vegetables",
            Quantity = 40,
            DateAdded = DateTime.Now.AddDays(-3),
            ImageUrl = "tomatoes.jpg",
            FarmerId = 1
        },
        new Product
        {
            Name = "Potatoes",
            Price = 2.0m,
            Description = "Freshly dug and ready to cook.",
            Category = "Vegetables",
            Quantity = 25,
            DateAdded = DateTime.Now.AddDays(-8),
            ImageUrl = "potatoes.jpg",
            FarmerId = 1
        },
        new Product
        {
            Name = "Lettuce",
            Price = 1.5m,
            Description = "Crisp and green lettuce leaves.",
            Category = "Vegetables",
            Quantity = 35,
            DateAdded = DateTime.Now.AddDays(-5),
            ImageUrl = "lettuce.jpg",
            FarmerId = 1
        },
        new Product
        {
            Name = "Pumpkins",
            Price = 3.0m,
            Description = "Perfect for pies or carving.",
            Category = "Vegetables",
            Quantity = 20,
            DateAdded = DateTime.Now.AddDays(-12),
            ImageUrl = "pumpkins.jpg",
            FarmerId = 1
        },

        // Products for Farmer 2
        new Product
        {
            Name = "Milk",
            Price = 3.0m,
            Description = "Fresh and creamy milk from our farm.",
            Category = "Dairy",
            Quantity = 20,
            DateAdded = DateTime.Now.AddDays(-5),
            ImageUrl = "milk.jpg",
            FarmerId = 2 // Assuming FarmerId for Farmer 2 is 2
        },
        new Product
        {
            Name = "Eggs",
            Price = 1.0m,
            Description = "Farm-fresh eggs from free-range chickens.",
            Category = "Eggs",
            Quantity = 40,
            DateAdded = DateTime.Now.AddDays(-3),
            ImageUrl = "eggs.jpg",
            FarmerId = 2
        },
        // Add more products for Farmer 2 here...
        new Product
        {
            Name = "Cheese",
            Price = 4.5m,
            Description = "Handcrafted artisanal cheese.",
            Category = "Dairy",
            Quantity = 15,
            DateAdded = DateTime.Now.AddDays(-8),
            ImageUrl = "cheese.jpg",
            FarmerId = 2
        },
        new Product
        {
            Name = "Yogurt",
            Price = 2.0m,
            Description = "Smooth and creamy yogurt.",
            Category = "Dairy",
            Quantity = 25,
            DateAdded = DateTime.Now.AddDays(-6),
            ImageUrl = "yogurt.jpg",
            FarmerId = 2
        },
        new Product
        {
            Name = "Beef",
            Price = 8.0m,
            Description = "Premium grass-fed beef cuts.",
            Category = "Meat",
            Quantity = 10,
            DateAdded = DateTime.Now.AddDays(-9),
            ImageUrl = "beef.jpg",
            FarmerId = 2
        },
        new Product
        {
            Name = "Chicken",
            Price = 6.0m,
            Description = "Fresh chicken meat from our farm.",
            Category = "Meat",
            Quantity = 30,
            DateAdded = DateTime.Now.AddDays(-4),
            ImageUrl = "chicken.jpg",
            FarmerId = 2
        }
    };


            context.products.AddRange(products);
            context.SaveChanges();

            base.Seed(context);
        }

    }


}
    