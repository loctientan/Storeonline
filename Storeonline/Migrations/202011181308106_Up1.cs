namespace Storeonline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Up1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "CustomerNotAccount", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "CustomerNotAccount");
        }
    }
}
