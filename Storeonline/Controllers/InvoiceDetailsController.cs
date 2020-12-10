using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Storeonline.Models;

namespace Storeonline.Controllers
{
    public class InvoiceDetailsController : Controller
    {
        private connectDB db = new connectDB();

        // GET: admin/InvoiceDetails
        public ActionResult Index()
        {
            var invoiceDetails = db.InvoiceDetails.Include(i => i.Invoice).Include(i => i.Product);
            return View(invoiceDetails.ToList());
        }

        // GET: admin/InvoiceDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice model = db.Invoices.SingleOrDefault(n =>n.InvoiceID == id);
            if (model == null)
            {
                return HttpNotFound();
            }
            var listproductdetails = db.InvoiceDetails.Where(s => s.InvoiceID == id);
            ViewBag.Listproductdetails = listproductdetails;
            return View(model);
        }

        // GET: admin/InvoiceDetails/Create
        public ActionResult Create()
        {
            ViewBag.InvoiceID = new SelectList(db.Invoices, "InvoiceID", "InvoiceCode");
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductCode");
            return View();
        }

        // POST: admin/InvoiceDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InvoiceDetailsID,InvoiceID,ProductID,ProductName,UserCode,Price,PromotionPrice,Quantity")] InvoiceDetails invoiceDetails)
        {
            if (ModelState.IsValid)
            {
                db.InvoiceDetails.Add(invoiceDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InvoiceID = new SelectList(db.Invoices, "InvoiceID", "InvoiceCode", invoiceDetails.InvoiceID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductCode", invoiceDetails.ProductID);
            return View(invoiceDetails);
        }

        // GET: admin/InvoiceDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceDetails invoiceDetails = db.InvoiceDetails.Find(id);
            if (invoiceDetails == null)
            {
                return HttpNotFound();
            }
            ViewBag.InvoiceID = new SelectList(db.Invoices, "InvoiceID", "InvoiceCode", invoiceDetails.InvoiceID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductCode", invoiceDetails.ProductID);
            return View(invoiceDetails);
        }

        // POST: admin/InvoiceDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InvoiceDetailsID,InvoiceID,ProductID,ProductName,UserCode,Price,PromotionPrice,Quantity")] InvoiceDetails invoiceDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invoiceDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InvoiceID = new SelectList(db.Invoices, "InvoiceID", "InvoiceCode", invoiceDetails.InvoiceID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductCode", invoiceDetails.ProductID);
            return View(invoiceDetails);
        }

        // GET: admin/InvoiceDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceDetails invoiceDetails = db.InvoiceDetails.Find(id);
            if (invoiceDetails == null)
            {
                return HttpNotFound();
            }
            return View(invoiceDetails);
        }

        // POST: admin/InvoiceDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InvoiceDetails invoiceDetails = db.InvoiceDetails.Find(id);
            db.InvoiceDetails.Remove(invoiceDetails);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
