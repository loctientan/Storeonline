namespace Storeonline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "CreateDate", c => c.DateTime());
            AlterColumn("dbo.Products", "ModifiedDate", c => c.DateTime());
            AlterColumn("dbo.Feedbacks", "CreateDate", c => c.DateTime());
            AlterColumn("dbo.News", "CreateDate", c => c.DateTime());
            AlterColumn("dbo.News", "ModifiedDate", c => c.DateTime());
            AlterColumn("dbo.NewsCategories", "CreateDate", c => c.DateTime());
            AlterColumn("dbo.NewsCategories", "ModifiedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.NewsCategories", "ModifiedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.NewsCategories", "CreateDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.News", "ModifiedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.News", "CreateDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Feedbacks", "CreateDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Products", "ModifiedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Products", "CreateDate", c => c.DateTime(nullable: false));
        }
    }
}
