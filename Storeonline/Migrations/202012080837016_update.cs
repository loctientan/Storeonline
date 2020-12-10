namespace Storeonline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.InvoiceDetails", "paymentCategoryID", "dbo.PaymentCategories");
            DropIndex("dbo.InvoiceDetails", new[] { "paymentCategoryID" });
            RenameColumn(table: "dbo.Invoices", name: "PaymentCategory_paymentcategoryID", newName: "paymentCategoryID");
            RenameIndex(table: "dbo.Invoices", name: "IX_PaymentCategory_paymentcategoryID", newName: "IX_paymentCategoryID");
            DropColumn("dbo.InvoiceDetails", "paymentCategoryID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.InvoiceDetails", "paymentCategoryID", c => c.Int());
            RenameIndex(table: "dbo.Invoices", name: "IX_paymentCategoryID", newName: "IX_PaymentCategory_paymentcategoryID");
            RenameColumn(table: "dbo.Invoices", name: "paymentCategoryID", newName: "PaymentCategory_paymentcategoryID");
            CreateIndex("dbo.InvoiceDetails", "paymentCategoryID");
            AddForeignKey("dbo.InvoiceDetails", "paymentCategoryID", "dbo.PaymentCategories", "paymentcategoryID");
        }
    }
}
