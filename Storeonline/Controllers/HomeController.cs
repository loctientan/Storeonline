﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Storeonline.Models;
using Storeonline.Areas.admin.Controllers;
using PagedList;


namespace Storeonline.Controllers
{
    public class HomeController : Controller
    {
        private connectDB db = new connectDB();


        public ActionResult Index(string id, int? page)
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
            var links = (from l in db.Products
                         select l).OrderBy(x => x.ProductID);
            return View(links.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}