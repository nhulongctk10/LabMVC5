namespace CheapShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KhoiTao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        CustomerId = c.String(nullable: false, maxLength: 128),
                        EmployeeId = c.String(nullable: false, maxLength: 128),
                        OrderDate = c.DateTime(),
                        RequiredDate = c.DateTime(),
                        ShipDate = c.DateTime(),
                        Freight = c.Int(nullable: false),
                        ShipVia = c.Int(),
                        ShipName = c.String(nullable: false, maxLength: 50),
                        ShipAddress = c.String(nullable: false, maxLength: 300),
                        ShipTel = c.String(nullable: false, maxLength: 20),
                        Status = c.Int(nullable: false),
                        Notes = c.String(maxLength: 500),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Shippers", t => t.ShipVia)
                .ForeignKey("dbo.Accounts", t => t.CustomerId)
                .ForeignKey("dbo.Accounts", t => t.EmployeeId)
                .Index(t => t.CustomerId)
                .Index(t => t.EmployeeId)
                .Index(t => t.ShipVia);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Discount = c.Single(nullable: false),
                        Notes = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => new { t.OrderId, t.ProductId })
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Alias = c.String(nullable: false, maxLength: 100),
                        Thumbnail = c.String(nullable: false, maxLength: 300),
                        ProductCode = c.String(nullable: false, maxLength: 20),
                        ShortIntro = c.String(maxLength: 500),
                        Description = c.String(storeType: "ntext"),
                        QtyPerUnit = c.String(maxLength: 50),
                        Price = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Discount = c.Single(nullable: false),
                        SupplierId = c.Int(nullable: false),
                        Actived = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.SupplierId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Alias = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false, maxLength: 1000),
                        IconPath = c.String(maxLength: 500),
                        Actived = c.Boolean(nullable: false),
                        ParentId = c.Int(),
                        OrderNo = c.Int(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.CategoryId)
                .ForeignKey("dbo.Categories", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 100),
                        Subject = c.String(nullable: false, maxLength: 100),
                        Content = c.String(nullable: false, maxLength: 1000),
                        PostedTime = c.DateTime(),
                        Actived = c.Boolean(nullable: false),
                        Status = c.Int(nullable: false),
                        ReplyContent = c.String(maxLength: 1000),
                        ReplyTime = c.DateTime(),
                        AccountId = c.String(maxLength: 128),
                        ProductId = c.Int(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Accounts", t => t.AccountId, cascadeDelete: true)
                .Index(t => t.AccountId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        PictureId = c.Int(nullable: false, identity: true),
                        Caption = c.String(maxLength: 150),
                        Path = c.String(maxLength: 500),
                        OrderNo = c.Int(nullable: false),
                        Actived = c.Boolean(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PictureId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.ProductHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        AccountId = c.String(maxLength: 128),
                        ActionTime = c.DateTime(nullable: false),
                        HistoryAction = c.Int(nullable: false),
                        OriginalProduct = c.String(storeType: "ntext"),
                        ModifiedProduct = c.String(storeType: "ntext"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Accounts", t => t.AccountId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.ProductProfiles",
                c => new
                    {
                        ProductProfileId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        ViewCount = c.Int(nullable: false),
                        VoteCount = c.Int(nullable: false),
                        TotalScore = c.Int(nullable: false),
                        Sales = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductProfileId)
                .ForeignKey("dbo.Products", t => t.ProductProfileId)
                .Index(t => t.ProductProfileId);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SupplierId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        Description = c.String(maxLength: 1000),
                        ContactName = c.String(nullable: false, maxLength: 50),
                        ContactTitle = c.String(maxLength: 20),
                        Address = c.String(nullable: false, maxLength: 200),
                        Email = c.String(),
                        Phone = c.String(maxLength: 20),
                        Fax = c.String(maxLength: 20),
                        HomePage = c.String(maxLength: 100),
                        Actived = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.SupplierId);
            
            CreateTable(
                "dbo.Shippers",
                c => new
                    {
                        ShipperId = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false, maxLength: 100),
                        Phone = c.String(nullable: false, maxLength: 20),
                        Address = c.String(nullable: false, maxLength: 300),
                    })
                .PrimaryKey(t => t.ShipperId);
            
            CreateTable(
                "dbo.UserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.Accounts", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        AccountId = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        LastName = c.String(nullable: false, maxLength: 30),
                        JobPosition = c.String(maxLength: 50),
                        BirthDate = c.DateTime(),
                        Address = c.String(maxLength: 300),
                        Picture = c.String(maxLength: 500),
                        Notes = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.AccountId)
                .ForeignKey("dbo.Accounts", t => t.AccountId)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.UserInRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Accounts", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.ProductCategory",
                c => new
                    {
                        CategoryId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CategoryId, t.ProductId })
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserInRoles", "UserId", "dbo.Accounts");
            DropForeignKey("dbo.UserLogins", "UserId", "dbo.Accounts");
            DropForeignKey("dbo.UserClaims", "UserId", "dbo.Accounts");
            DropForeignKey("dbo.UserInRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.UserProfiles", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.ProductHistories", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.Orders", "EmployeeId", "dbo.Accounts");
            DropForeignKey("dbo.Comments", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Accounts");
            DropForeignKey("dbo.Orders", "ShipVia", "dbo.Shippers");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Products", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.ProductProfiles", "ProductProfileId", "dbo.Products");
            DropForeignKey("dbo.ProductHistories", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Pictures", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Comments", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductCategory", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductCategory", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Categories", "ParentId", "dbo.Categories");
            DropIndex("dbo.ProductCategory", new[] { "ProductId" });
            DropIndex("dbo.ProductCategory", new[] { "CategoryId" });
            DropIndex("dbo.Roles", "RoleNameIndex");
            DropIndex("dbo.UserInRoles", new[] { "RoleId" });
            DropIndex("dbo.UserInRoles", new[] { "UserId" });
            DropIndex("dbo.UserProfiles", new[] { "AccountId" });
            DropIndex("dbo.UserLogins", new[] { "UserId" });
            DropIndex("dbo.UserClaims", new[] { "UserId" });
            DropIndex("dbo.ProductProfiles", new[] { "ProductProfileId" });
            DropIndex("dbo.ProductHistories", new[] { "AccountId" });
            DropIndex("dbo.ProductHistories", new[] { "ProductId" });
            DropIndex("dbo.Pictures", new[] { "ProductId" });
            DropIndex("dbo.Comments", new[] { "ProductId" });
            DropIndex("dbo.Comments", new[] { "AccountId" });
            DropIndex("dbo.Categories", new[] { "ParentId" });
            DropIndex("dbo.Products", new[] { "SupplierId" });
            DropIndex("dbo.OrderDetails", new[] { "ProductId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.Orders", new[] { "ShipVia" });
            DropIndex("dbo.Orders", new[] { "EmployeeId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.Accounts", "UserNameIndex");
            DropTable("dbo.ProductCategory");
            DropTable("dbo.Roles");
            DropTable("dbo.UserInRoles");
            DropTable("dbo.UserProfiles");
            DropTable("dbo.UserLogins");
            DropTable("dbo.UserClaims");
            DropTable("dbo.Shippers");
            DropTable("dbo.Suppliers");
            DropTable("dbo.ProductProfiles");
            DropTable("dbo.ProductHistories");
            DropTable("dbo.Pictures");
            DropTable("dbo.Comments");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Orders");
            DropTable("dbo.Accounts");
        }
    }
}
