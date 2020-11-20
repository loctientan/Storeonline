namespace Storeonline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class up : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        CartID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(),
                        ProductID = c.Int(),
                        DateOfPurchase = c.DateTime(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CartID)
                .ForeignKey("dbo.Products", t => t.ProductID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductCode = c.String(nullable: false),
                        ProductName = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        ProductImage = c.String(nullable: false),
                        Price = c.Int(nullable: false),
                        PromotionPrice = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        CategoryID = c.Int(),
                        Detail = c.String(nullable: false),
                        Warranty = c.Int(nullable: false),
                        CreateDate = c.DateTime(),
                        CreateBy = c.String(),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(),
                        Status = c.Boolean(nullable: false),
                        TopHot = c.DateTime(nullable: false),
                        ViewCounts = c.Int(nullable: false),
                        ProductCategory_CategoryID = c.Int(),
                        ProductCategorys_CategoryID = c.Int(),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.ProductCategories", t => t.ProductCategory_CategoryID)
                .ForeignKey("dbo.ProductCategories", t => t.CategoryID)
                .ForeignKey("dbo.ProductCategories", t => t.ProductCategorys_CategoryID)
                .Index(t => t.CategoryID)
                .Index(t => t.ProductCategory_CategoryID)
                .Index(t => t.ProductCategorys_CategoryID);
            
            CreateTable(
                "dbo.InvoiceDetails",
                c => new
                    {
                        InvoiceDetailsID = c.Int(nullable: false, identity: true),
                        InvoiceID = c.Int(),
                        ProductID = c.Int(),
                        ProductName = c.String(),
                        UserCode = c.String(),
                        Price = c.Int(nullable: false),
                        PromotionPrice = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceDetailsID)
                .ForeignKey("dbo.Invoices", t => t.InvoiceID)
                .ForeignKey("dbo.Products", t => t.ProductID)
                .Index(t => t.InvoiceID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceID = c.Int(nullable: false, identity: true),
                        InvoiceCode = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        Email = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        ghichu = c.String(nullable: false),
                        Payment = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        UserCode = c.String(),
                        Product_ProductID = c.Int(),
                    })
                .PrimaryKey(t => t.InvoiceID)
                .ForeignKey("dbo.Products", t => t.Product_ProductID)
                .Index(t => t.Product_ProductID);
            
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        ParentID = c.Int(nullable: false),
                        CreateDate = c.DateTime(),
                        CreateBy = c.String(),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(),
                        Status = c.Boolean(nullable: false),
                        ShowOnHome = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserCode = c.String(),
                        LastName = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        ConfirmPassword = c.String(nullable: false),
                        IsStaff = c.Boolean(nullable: false),
                        Position = c.String(),
                        CustomerNotAccount = c.Boolean(nullable: false),
                        RoleID = c.Int(),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Roles", t => t.RoleID)
                .Index(t => t.RoleID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(nullable: false),
                        Details = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        FeedbackID = c.Int(nullable: false, identity: true),
                        FeedbackCode = c.String(),
                        FirstName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Content = c.String(nullable: false),
                        Status = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.FeedbackID);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        NewsID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        MetaTitle = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        NewsImage = c.String(nullable: false),
                        NewsCategoryID = c.Int(),
                        Details = c.String(nullable: false),
                        CreateDate = c.DateTime(),
                        CreateBy = c.String(),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(),
                        Status = c.Boolean(nullable: false),
                        TopHot = c.Boolean(nullable: false),
                        ViewCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NewsID)
                .ForeignKey("dbo.NewsCategories", t => t.NewsCategoryID)
                .Index(t => t.NewsCategoryID);
            
            CreateTable(
                "dbo.NewsCategories",
                c => new
                    {
                        NewsCategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        NCCode = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                        CreateDate = c.DateTime(),
                        CreateBy = c.String(),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(),
                        Status = c.Boolean(nullable: false),
                        TopHot = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.NewsCategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.News", "NewsCategoryID", "dbo.NewsCategories");
            DropForeignKey("dbo.Carts", "UserID", "dbo.Users");
            DropForeignKey("dbo.Users", "RoleID", "dbo.Roles");
            DropForeignKey("dbo.Carts", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Products", "ProductCategorys_CategoryID", "dbo.ProductCategories");
            DropForeignKey("dbo.Products", "CategoryID", "dbo.ProductCategories");
            DropForeignKey("dbo.Products", "ProductCategory_CategoryID", "dbo.ProductCategories");
            DropForeignKey("dbo.Invoices", "Product_ProductID", "dbo.Products");
            DropForeignKey("dbo.InvoiceDetails", "ProductID", "dbo.Products");
            DropForeignKey("dbo.InvoiceDetails", "InvoiceID", "dbo.Invoices");
            DropIndex("dbo.News", new[] { "NewsCategoryID" });
            DropIndex("dbo.Users", new[] { "RoleID" });
            DropIndex("dbo.Invoices", new[] { "Product_ProductID" });
            DropIndex("dbo.InvoiceDetails", new[] { "ProductID" });
            DropIndex("dbo.InvoiceDetails", new[] { "InvoiceID" });
            DropIndex("dbo.Products", new[] { "ProductCategorys_CategoryID" });
            DropIndex("dbo.Products", new[] { "ProductCategory_CategoryID" });
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropIndex("dbo.Carts", new[] { "ProductID" });
            DropIndex("dbo.Carts", new[] { "UserID" });
            DropTable("dbo.NewsCategories");
            DropTable("dbo.News");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.ProductCategories");
            DropTable("dbo.Invoices");
            DropTable("dbo.InvoiceDetails");
            DropTable("dbo.Products");
            DropTable("dbo.Carts");
        }
    }
}
