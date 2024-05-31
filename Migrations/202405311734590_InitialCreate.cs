namespace AgriEnergy_WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Department = c.String(maxLength: 255),
                        Position = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 255),
                        PasswordHash = c.String(nullable: false, maxLength: 255),
                        Email = c.String(nullable: false, maxLength: 255),
                        Name = c.String(nullable: false, maxLength: 255),
                        Surname = c.String(nullable: false, maxLength: 255),
                        UserProfilePicture = c.String(),
                        Role = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Farmers",
                c => new
                    {
                        FarmerId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        FarmName = c.String(maxLength: 255),
                        ContactNumber = c.String(maxLength: 20),
                        StoreImageUrl = c.String(),
                        AboutFarm = c.String(),
                        FarmLocation = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.FarmerId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        FarmerId = c.Int(nullable: false),
                        Category = c.String(),
                        Quantity = c.Int(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Farmers", t => t.FarmerId, cascadeDelete: true)
                .Index(t => t.FarmerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "FarmerId", "dbo.Farmers");
            DropForeignKey("dbo.Farmers", "UserId", "dbo.Users");
            DropForeignKey("dbo.Employees", "UserId", "dbo.Users");
            DropIndex("dbo.Products", new[] { "FarmerId" });
            DropIndex("dbo.Farmers", new[] { "UserId" });
            DropIndex("dbo.Employees", new[] { "UserId" });
            DropTable("dbo.Products");
            DropTable("dbo.Farmers");
            DropTable("dbo.Users");
            DropTable("dbo.Employees");
        }
    }
}
