namespace CheapShop.DAL
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDatetimeType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "PostedTime", c => c.DateTime());
            AlterColumn("dbo.Comments", "ReplyTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comments", "ReplyTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Comments", "PostedTime", c => c.DateTime(nullable: false));
        }
    }
}
