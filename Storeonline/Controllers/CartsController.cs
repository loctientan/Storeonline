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
    public class CartsController : Controller
    {
        private connectDB db = new connectDB();

        public FunctionCart GetListCart()
        {
            FunctionCart functioncart = Session["FunctionCart"] as FunctionCart;
            if (functioncart == null || Session["FunctionCart"] == null)
            {
                functioncart = new FunctionCart();
                Session["FunctionCart"] = functioncart;
            }
            return functioncart;
        }

        public ActionResult Add(int id)
        {
            var sp = db.Products.SingleOrDefault(p => p.ProductID.Equals(id));
            if (sp != null)
            {
                User customer = Session["user"] as User;
                GetListCart().addCart(customer, sp);
            }
            return RedirectToAction("ViewCart", "Carts");
        }

        //Trang giỏ hàng
        public ActionResult ViewCart()
        {

            if (Session["FunctionCart"] == null)
            {

                SetAlert("Giỏ hàng không có sản phẩm. Vui lòng thực hiện lại", "danger");
            }
            FunctionCart functioncart = Session["FunctionCart"] as FunctionCart;

            return View(functioncart);

        }

        public ActionResult updateQuantity(FormCollection form)
        {
            FunctionCart functionCart = Session["FunctionCart"] as FunctionCart;
            int productID = int.Parse(form["ProductID"]);
            int quantity = int.Parse(form["Quantity"]);
            functionCart.Update_Quantity(productID, quantity);
            return RedirectToAction("ViewCart", "Carts");
        }

        //Xóa sản phẩm khỏi giỏ hàng
        public ActionResult DeleteProduct(int id)
        {
            FunctionCart functionCart = Session["FunctionCart"] as FunctionCart;
            functionCart.RemoveCartItem(id);
             return RedirectToAction("ViewCart", "Carts");
        }

        public ActionResult DeleteAll()
        {
            FunctionCart functionCart = Session["FunctionCart"] as FunctionCart;

            functionCart.RemoveCartAll();
            return RedirectToAction("ViewCart", "Carts");
        }


        public ActionResult Pay(FormCollection form)
        {
            User user = new User();
            if(user.Username == null)
            {
                user.CustomerNotAccount = true;
                FunctionCart functionCart = Session["FunctionCart"] as FunctionCart;
                Invoice invoice = new Invoice();
                PaymentCategory paymentCategory = new PaymentCategory();
                invoice.CreateDate = DateTime.Now;
                //User user = Session["Username"] as User;
                invoice.UserID = user.UserID;
                invoice.UserCode = user.UserCode;
                invoice.Email = form["email"];
                invoice.LastName = form["lastname"];
                invoice.FirstName = form["firstname"];
                invoice.Phone = form["phone"];
                invoice.Address = form["address"];
                invoice.ghichu = form["ghichu"];
                //invoice.Payment = paymentCategory.paymentcategoryID;
                //invoice.PaymentCategory.paymentstatus = form.AllKeys.Single();
                db.Invoices.Add(invoice);

                foreach (var item in functionCart.carts)
                {
                    InvoiceDetails invoiceDetails = new InvoiceDetails();

                    invoiceDetails.InvoiceID = invoice.InvoiceID;
                    invoiceDetails.UserCode = invoice.UserCode;
                    invoiceDetails.ProductID = item.Product.ProductID;
                    invoiceDetails.ProductName = item.Product.ProductName;
                    invoiceDetails.Price = item.Product.Price;
                    invoiceDetails.PromotionPrice = item.Product.PromotionPrice;
                    invoiceDetails.Quantity = item.Quantity;
                    db.InvoiceDetails.Add(invoiceDetails);
                }

                db.SaveChanges();
                functionCart.RemoveCartAll();
                SetAlert("Bộ phận bán hàng sẽ liên hệ bạn trong vòng 12h tới. Xin cảm ơn bạn đã mua hàng.", "success");
                return RedirectToAction("Details", "InvoiceDetails");
            }
            else if(user.Username != null)
            {
                FunctionCart functionCart = Session["FunctionCart"] as FunctionCart;
                Invoice invoice = new Invoice();
                PaymentCategory paymentCategory = new PaymentCategory();
                invoice.CreateDate = DateTime.Now;
                user = Session["Username"] as User;
                invoice.UserID = user.UserID;
                invoice.UserCode = user.UserCode;
                invoice.Email = user.Email;
                invoice.LastName = user.LastName;
                invoice.FirstName = user.FirstName;
                invoice.Phone = user.Phone;
                invoice.Address = user.Address;
                invoice.ghichu = form["ghichu"];
                //invoice.Payment = paymentCategory.paymentcategoryID;
                //invoice.PaymentCategory.paymentstatus = form.AllKeys.Single();
                db.Invoices.Add(invoice);

                foreach (var item in functionCart.carts)
                {
                    InvoiceDetails invoiceDetails = new InvoiceDetails();

                    invoiceDetails.InvoiceID = invoice.InvoiceID;
                    invoiceDetails.UserCode = invoice.UserCode;
                    invoiceDetails.ProductID = item.Product.ProductID;
                    invoiceDetails.ProductName = item.Product.ProductName;
                    invoiceDetails.Price = item.Product.Price;
                    invoiceDetails.PromotionPrice = item.Product.PromotionPrice;
                    invoiceDetails.Quantity = item.Quantity;
                    db.InvoiceDetails.Add(invoiceDetails);
                }

                db.SaveChanges();
                functionCart.RemoveCartAll();
                SetAlert("Bộ phận bán hàng sẽ liên hệ bạn trong vòng 12h tới. Xin cảm ơn bạn đã mua hàng.", "success");
                return RedirectToAction("Details", "InvoiceDetails");
            }
            else
            { 
                SetAlert("Đặt hàng không thành công. Vui lòng đặt lại.", "danger");
                return RedirectToAction("ViewCart", "Carts");
            }
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


        
//             try
//            {
//                FunctionCart functionCart = Session["FunctionCart"] as FunctionCart;
//        Invoice invoice = new Invoice();
//        PaymentCategory paymentCategory = new PaymentCategory();
//        invoice.CreateDate = DateTime.Now;
//                User user = Session["Username"] as User;
//        invoice.UserID = user.UserID;
//                invoice.UserCode = user.UserCode;
//                invoice.Email = form["email"];
//                invoice.LastName = form["lastname"];
//                invoice.FirstName = form["firstname"];
//                invoice.Phone = form["phone"];
//                invoice.Address = form["address"];
//                invoice.ghichu = form["ghichu"];
//                //invoice.Payment = paymentCategory.paymentcategoryID;
//                //invoice.PaymentCategory.paymentstatus = form.AllKeys.Single();
//                db.Invoices.Add(invoice);

//                foreach (var item in functionCart.carts)
//                {
//                    InvoiceDetails invoiceDetails = new InvoiceDetails();

//        invoiceDetails.InvoiceID = invoice.InvoiceID;
//                    invoiceDetails.UserCode = invoice.UserCode;
//                    invoiceDetails.ProductID = item.Product.ProductID;
//                    invoiceDetails.ProductName = item.Product.ProductName;
//                    invoiceDetails.Price = item.Product.Price;
//                    invoiceDetails.PromotionPrice = item.Product.PromotionPrice;
//                    invoiceDetails.Quantity = item.Quantity;
//                    db.InvoiceDetails.Add(invoiceDetails);
//                }

//    db.SaveChanges();
//                functionCart.RemoveCartAll();
//                SetAlert("Bộ phận bán hàng sẽ liên hệ bạn trong vòng 12h tới. Xin cảm ơn bạn đã mua hàng.", "success");
//                return RedirectToAction("Details", "InvoiceDetails");
//}
//            catch
//{
//    SetAlert("Đặt hàng không thành công. Vui lòng đặt lại.", "danger");
//    return RedirectToAction("ViewCart", "Carts");
//}
    }
}
