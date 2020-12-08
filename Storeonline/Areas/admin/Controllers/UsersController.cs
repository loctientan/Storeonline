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
    public class UsersController : Controller
    {
        private connectDB db = new connectDB();

        // GET: admin/Users
        public ActionResult Index()
        {
            var users = db.Users.Include(u => u.Role);
            return View(users.ToList());
        }

        // GET: admin/Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: admin/Users/Create
        public ActionResult Create()
        {
            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "RoleName");
            return View();
        }

        // POST: admin/Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,UserCode,LastName,FirstName,Address,Phone,Email,Username,Password,ConfirmPassword,IsStaff,Position,RoleID")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "RoleName", user.RoleID);
            return View(user);
        }

        // GET: admin/Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "RoleName", user.RoleID);
            return View(user);
        }

        // POST: admin/Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,UserCode,LastName,FirstName,Address,Phone,Email,Username,Password,ConfirmPassword,IsStaff,Position,RoleID")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "RoleName", user.RoleID);
            return View(user);
        }

        // GET: admin/Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: admin/Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
