using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Storeonline.Models;
using Storeonline.Areas.admin.Controllers;
using PagedList;
using System.Net;

namespace Storeonline.Controllers
{
    public class HomeController : Controller
    {
        private connectDB db = new connectDB();
        // GET: Home
        public ActionResult Index(string id, int? page, string ten, string price)
        {
            int pageSize = 8;
            int pageNumber = (page ?? 1);

            if (page == null)
                page = 1;

            //Phân loại sản phẩm
            if (!String.IsNullOrEmpty(id))
            {
                int temp = Convert.ToInt32(id);
                var result = (from r in db.Products
                              where r.CategoryID == temp
                              select r).OrderBy(x => x.ProductID);
                return View(result.ToPagedList(pageNumber, pageSize));
            }

            if (!String.IsNullOrEmpty(ten) || !String.IsNullOrEmpty(price))
            {
                var result = (from r in db.Products
                              where r.ProductName.Contains(ten)
                              && r.Price.ToString().Contains(price)
                              select r).OrderBy(a => a.ProductID);
                return View(result.ToPagedList(pageNumber, pageSize));
            }

            var links = (from l in db.Products
                         select l).OrderBy(x => x.ProductID);

            return View(links.ToPagedList(pageNumber, pageSize));
        }

        // GET: Home/Details/5
        public ActionResult DetailProducts(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
