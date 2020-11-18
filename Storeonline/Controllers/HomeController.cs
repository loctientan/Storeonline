using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Storeonline.Models;
using Storeonline.Areas.admin.Controllers;

namespace Storeonline.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            connectDB db = new connectDB();

            return View(db.ProductCategories.ToList());
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