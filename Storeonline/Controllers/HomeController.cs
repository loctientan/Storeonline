using System;
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


        public ActionResult Index(string id, int? page,string ten,string price)
        {
            int pageSize = 8;
            int pageNumber = (page ?? 1);

            if (page == null)
                page = 1;

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

            //if (!String.IsNullOrEmpty(price))
            //{
            //    var result = (from r in db.Products
            //                  where r.Price.ToString().Contains(price)
            //                  select r).OrderBy(a => a.ProductID);
            //    return View(result.ToPagedList(pageNumber, pageSize));
            //}
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