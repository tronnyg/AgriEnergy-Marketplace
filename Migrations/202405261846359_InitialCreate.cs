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
                        UserId = c.Int(nullable: false),
                        Department = c.String(maxLength: 255),
                        Position = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Users", t => t.UserId)
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
                        Role = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Farmers",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        FarmName = c.String(maxLength: 255),
                        ContactEmail = c.String(maxLength: 255),
                        ContactNumber = c.String(maxLength: 20),
                        AboutFarm = c.String(),
                        FarmLocation = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Farmers", "UserId", "dbo.Users");
            DropForeignKey("dbo.Employees", "UserId", "dbo.Users");
            DropIndex("dbo.Farmers", new[] { "UserId" });
            DropIndex("dbo.Employees", new[] { "UserId" });
            DropTable("dbo.Farmers");
            DropTable("dbo.Users");
            DropTable("dbo.Employees");
        }
    }
}
