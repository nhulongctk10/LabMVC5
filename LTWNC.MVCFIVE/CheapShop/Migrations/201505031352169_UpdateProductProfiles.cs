namespace CheapShop.DAL
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProductProfiles : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductProfiles", "ProductId", "dbo.Products");
            DropIndex("dbo.ProductProfiles", new[] { "ProductId" });
            DropColumn("dbo.ProductProfiles", "ProductProfileId");
            RenameColumn(table: "dbo.ProductProfiles", name: "ProductId", newName: "ProductProfileId");
            DropPrimaryKey("dbo.ProductProfiles");
            AlterColumn("dbo.ProductProfiles", "ProductProfileId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ProductProfiles", "ProductProfileId");
            CreateIndex("dbo.ProductProfiles", "ProductProfileId");
            AddForeignKey("dbo.ProductProfiles", "ProductProfileId", "dbo.Products", "ProductId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductProfiles", "ProductProfileId", "dbo.Products");
            DropIndex("dbo.ProductProfiles", new[] { "ProductProfileId" });
            DropPrimaryKey("dbo.ProductProfiles");
            AlterColumn("dbo.ProductProfiles", "ProductProfileId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.ProductProfiles", "ProductProfileId");
            RenameColumn(table: "dbo.ProductProfiles", name: "ProductProfileId", newName: "ProductId");
            AddColumn("dbo.ProductProfiles", "ProductProfileId", c => c.Int(nullable: false, identity: true));
            CreateIndex("dbo.ProductProfiles", "ProductId");
            AddForeignKey("dbo.ProductProfiles", "ProductId", "dbo.Products", "ProductId", cascadeDelete: true);
        }
    }
}
