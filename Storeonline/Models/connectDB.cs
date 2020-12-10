using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace Storeonline.Models
{
    public class connectDB : DbContext
    {
        public connectDB()
        {
            SqlConnectionStringBuilder sql = new SqlConnectionStringBuilder();
            sql.DataSource = "TANLOC";
            sql.InitialCatalog = "StoreOnline";
            sql.IntegratedSecurity = true;
            this.Database.Connection.ConnectionString = sql.ConnectionString;
        }

        public virtual DbSet<Product> Products {get;set;}
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<NewsCategory> NewsCategories { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<InvoiceDetails> InvoiceDetails { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }

        public System.Data.Entity.DbSet<Storeonline.Models.PaymentCategory> PaymentCategories { get; set; }
    }
}