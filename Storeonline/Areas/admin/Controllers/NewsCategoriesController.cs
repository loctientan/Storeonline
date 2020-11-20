using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Storeonline.Models;

namespace Storeonline.Areas.admin.Controllers
{
    public class NewsCategoriesController : Controller
    {
        private connectDB db = new connectDB();

        // GET: admin/NewsCategories
        public ActionResult Index()
        {
            return View(db.NewsCategories.ToList());
        }

        // GET: admin/NewsCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsCategory newsCategory = db.NewsCategories.Find(id);
            if (newsCategory == null)
            {
                return HttpNotFound();
            }
            return View(newsCategory);
        }

        // GET: admin/NewsCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/NewsCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NewsCategoryID,Name,NCCode,Description,CreateDate,CreateBy,ModifiedDate,ModifiedBy,Status,TopHot")] NewsCategory newsCategory)
        {
            if (ModelState.IsValid)
            {
                db.NewsCategories.Add(newsCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newsCategory);
        }

        // GET: admin/NewsCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsCategory newsCategory = db.NewsCategories.Find(id);
            if (newsCategory == null)
            {
                return HttpNotFound();
            }
            return View(newsCategory);
        }

        // POST: admin/NewsCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NewsCategoryID,Name,NCCode,Description,CreateDate,CreateBy,ModifiedDate,ModifiedBy,Status,TopHot")] NewsCategory newsCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newsCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newsCategory);
        }

        // GET: admin/NewsCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsCategory newsCategory = db.NewsCategories.Find(id);
            if (newsCategory == null)
            {
                return HttpNotFound();
            }
            return View(newsCategory);
        }

        // POST: admin/NewsCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NewsCategory newsCategory = db.NewsCategories.Find(id);
            db.NewsCategories.Remove(newsCategory);
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
