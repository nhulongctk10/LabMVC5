namespace CheapShop.DAL
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductProfile : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductProfiles",
                c => new
                    {
                        ProductProfileId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        ViewCount = c.Int(nullable: false),
                        VoteCount = c.Int(nullable: false),
                        TotalScore = c.Int(nullable: false),
                        Sales = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductProfileId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductProfiles", "ProductId", "dbo.Products");
            DropIndex("dbo.ProductProfiles", new[] { "ProductId" });
            DropTable("dbo.ProductProfiles");
        }
    }
}
