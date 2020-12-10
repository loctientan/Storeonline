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
    public class CustomerController : Controller
    {
        private connectDB db = new connectDB();

        public ActionResult Login(User _user)
        {
          
            if (ModelState.IsValid)
            {
                SetAlert("Bạn vui lòng điền thông tin đăng nhập", "danger");
                return View("Login");
            }
            else
            {
                User us = db.Users
                   .Where(u => u.Username.Equals(_user.Username) && u.Password.Equals(_user.Password)).FirstOrDefault();

                User NoUsername = db.Users
                 .Where(u => u.Password.Equals(_user.Password)).FirstOrDefault();

                User NoPass = db.Users
                 .Where(u => u.Username.Equals(_user.Username)).FirstOrDefault();

                if(us != null && us.IsStaff == false)
                {
                    Session["Username"] = us;
                    Session["UserID"] = us.UserID;
                    Session["Username"] = us.Username.ToString();

                    return RedirectToAction("Index", "Home");
                }
                else if(us!=null && us.IsStaff == true)
                {
                    Session["Username"] = us;
                    Session["Username"] = us.Username.ToString();
               
                    return RedirectToAction("Index", "Products", new { Area = "admin" });
                }
                else if (NoUsername != null)
                {
                    SetAlert("Username của bạn không đúng", "danger");
                    return View("Login");
                }
                else if (NoPass != null)
                {
                    SetAlert("Password của bạn không đúng", "danger");
                    return View("Login");
                }
                else
                {
                    return View("Login");
                }
            }

        }
        public ActionResult LogOut()
        {
            Session.Remove("Username");
            Session.Remove("Carts");
            return RedirectToAction("Index", "Home", new { area = "" });
        }
        public ActionResult Signup(User _user)
        {
            if (ModelState.IsValid)
            {
                var check = db.Users.FirstOrDefault(s => s.Username == _user.Username);
                if (check == null)
                {
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.Users.Add(_user);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.error = "Tài khoản đã có người sử dụng";
                    return View();
                }
            }
            return View();
        }
        //Đặt thông báo lỗi
        protected void SetAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;
            if (type == "success")
            {
                TempData["AlertType"] = "alert-success";
            }
            else if (type == "warning")
            {
                TempData["AlertType"] = "alert-warning";
            }
            else if (type == "danger")
            {
                TempData["AlertType"] = "alert-danger";
            }
            else
            {
                TempData["AlertType"] = "alert-info";
            }
        }
  
      
    }
}
