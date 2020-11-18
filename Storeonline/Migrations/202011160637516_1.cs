namespace Storeonline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProductCategories", "CreateDate", c => c.DateTime());
            AlterColumn("dbo.ProductCategories", "ModifiedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductCategories", "ModifiedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProductCategories", "CreateDate", c => c.DateTime(nullable: false));
        }
    }
}
