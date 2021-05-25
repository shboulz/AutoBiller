namespace AutoBiller.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        ServiceId = c.Int(),
                        CustomerFirstName = c.String(nullable: false),
                        CustomerLastName = c.String(nullable: false),
                        CustomerAddress = c.String(nullable: false),
                        CustomerPhoneNumber = c.String(nullable: false),
                        CarOwnerId = c.Guid(nullable: false),
                        IsCustomerVIP = c.Boolean(nullable: false),
                        RepairShop_RepairShopId = c.Int(),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.RepairShop", t => t.RepairShop_RepairShopId)
                .ForeignKey("dbo.ServiceEstimate", t => t.ServiceId)
                .Index(t => t.ServiceId)
                .Index(t => t.RepairShop_RepairShopId);
            
            CreateTable(
                "dbo.ServiceEstimate",
                c => new
                    {
                        ServiceId = c.Int(nullable: false, identity: true),
                        RepairShopId = c.Int(),
                        BayId = c.Guid(nullable: false),
                        VehicleId = c.Int(),
                        VehicleMake = c.String(),
                        ServiceNotes = c.String(),
                        ServicePartCost = c.Double(nullable: false),
                        RepairShop_RepairShopId = c.Int(),
                    })
                .PrimaryKey(t => t.ServiceId)
                .ForeignKey("dbo.RepairShop", t => t.RepairShop_RepairShopId)
                .ForeignKey("dbo.RepairShop", t => t.RepairShopId)
                .ForeignKey("dbo.Vehicle", t => t.VehicleId)
                .Index(t => t.RepairShopId)
                .Index(t => t.VehicleId)
                .Index(t => t.RepairShop_RepairShopId);
            
            CreateTable(
                "dbo.RepairShop",
                c => new
                    {
                        RepairShopId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(),
                        CustomerFirstName = c.String(),
                        CustomerLastName = c.String(),
                        VehicleId = c.Int(),
                        VehicleMake = c.String(),
                        VehicleModel = c.String(),
                        ServiceId = c.Int(),
                        ServiceTotalCost = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.RepairShopId)
                .ForeignKey("dbo.Customer", t => t.CustomerId)
                .ForeignKey("dbo.ServiceEstimate", t => t.ServiceId)
                .ForeignKey("dbo.Vehicle", t => t.VehicleId)
                .Index(t => t.CustomerId)
                .Index(t => t.VehicleId)
                .Index(t => t.ServiceId);
            
            CreateTable(
                "dbo.Vehicle",
                c => new
                    {
                        VehicleId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(),
                        VehicleMake = c.String(nullable: false),
                        VehicleModel = c.String(nullable: false),
                        VehicleYear = c.String(nullable: false),
                        VehicleMileage = c.Double(nullable: false),
                        VehicleTag = c.Guid(nullable: false),
                        RepairShop_RepairShopId = c.Int(),
                    })
                .PrimaryKey(t => t.VehicleId)
                .ForeignKey("dbo.Customer", t => t.CustomerId)
                .ForeignKey("dbo.RepairShop", t => t.RepairShop_RepairShopId)
                .Index(t => t.CustomerId)
                .Index(t => t.RepairShop_RepairShopId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Customer", "ServiceId", "dbo.ServiceEstimate");
            DropForeignKey("dbo.ServiceEstimate", "VehicleId", "dbo.Vehicle");
            DropForeignKey("dbo.ServiceEstimate", "RepairShopId", "dbo.RepairShop");
            DropForeignKey("dbo.RepairShop", "VehicleId", "dbo.Vehicle");
            DropForeignKey("dbo.RepairShop", "ServiceId", "dbo.ServiceEstimate");
            DropForeignKey("dbo.Vehicle", "RepairShop_RepairShopId", "dbo.RepairShop");
            DropForeignKey("dbo.Vehicle", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.ServiceEstimate", "RepairShop_RepairShopId", "dbo.RepairShop");
            DropForeignKey("dbo.Customer", "RepairShop_RepairShopId", "dbo.RepairShop");
            DropForeignKey("dbo.RepairShop", "CustomerId", "dbo.Customer");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Vehicle", new[] { "RepairShop_RepairShopId" });
            DropIndex("dbo.Vehicle", new[] { "CustomerId" });
            DropIndex("dbo.RepairShop", new[] { "ServiceId" });
            DropIndex("dbo.RepairShop", new[] { "VehicleId" });
            DropIndex("dbo.RepairShop", new[] { "CustomerId" });
            DropIndex("dbo.ServiceEstimate", new[] { "RepairShop_RepairShopId" });
            DropIndex("dbo.ServiceEstimate", new[] { "VehicleId" });
            DropIndex("dbo.ServiceEstimate", new[] { "RepairShopId" });
            DropIndex("dbo.Customer", new[] { "RepairShop_RepairShopId" });
            DropIndex("dbo.Customer", new[] { "ServiceId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Vehicle");
            DropTable("dbo.RepairShop");
            DropTable("dbo.ServiceEstimate");
            DropTable("dbo.Customer");
        }
    }
}
