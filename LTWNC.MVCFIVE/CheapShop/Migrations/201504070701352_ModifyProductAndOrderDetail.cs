namespace CheapShop.DAL
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyProductAndOrderDetail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Alias", c => c.String(nullable: false, maxLength: 100,defaultValue:""));
            AddColumn("dbo.Products", "Thumbnail", c => c.String(nullable: false, maxLength: 300,defaultValue:"~/Images/noimage.jpg"));
            AddColumn("dbo.Products", "ProductCode", c => c.String(nullable: false, maxLength: 20,defaultValue:"SP000000"));
            AddColumn("dbo.OrderDetails", "Notes", c => c.String(maxLength: 300));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderDetails", "Notes");
            DropColumn("dbo.Products", "ProductCode");
            DropColumn("dbo.Products", "Thumbnail");
            DropColumn("dbo.Products", "Alias");
        }
    }
}
