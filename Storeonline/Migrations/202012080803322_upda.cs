namespace Storeonline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upda : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PaymentCategories",
                c => new
                    {
                        paymentcategoryID = c.Int(nullable: false, identity: true),
                        paymentstatus = c.String(),
                    })
                .PrimaryKey(t => t.paymentcategoryID);
            
            AddColumn("dbo.InvoiceDetails", "paymentCategoryID", c => c.Int());
            AddColumn("dbo.Invoices", "PaymentCategory_paymentcategoryID", c => c.Int());
            CreateIndex("dbo.InvoiceDetails", "paymentCategoryID");
            CreateIndex("dbo.Invoices", "PaymentCategory_paymentcategoryID");
            AddForeignKey("dbo.Invoices", "PaymentCategory_paymentcategoryID", "dbo.PaymentCategories", "paymentcategoryID");
            AddForeignKey("dbo.InvoiceDetails", "paymentCategoryID", "dbo.PaymentCategories", "paymentcategoryID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InvoiceDetails", "paymentCategoryID", "dbo.PaymentCategories");
            DropForeignKey("dbo.Invoices", "PaymentCategory_paymentcategoryID", "dbo.PaymentCategories");
            DropIndex("dbo.Invoices", new[] { "PaymentCategory_paymentcategoryID" });
            DropIndex("dbo.InvoiceDetails", new[] { "paymentCategoryID" });
            DropColumn("dbo.Invoices", "PaymentCategory_paymentcategoryID");
            DropColumn("dbo.InvoiceDetails", "paymentCategoryID");
            DropTable("dbo.PaymentCategories");
        }
    }
}
