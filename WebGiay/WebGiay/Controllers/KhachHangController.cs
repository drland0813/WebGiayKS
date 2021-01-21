using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyClass.Model;

namespace WebGiay.Controllers
{
    public class KhachHangController : Controller
    {
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View("DangNhap");
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection collection)
        {
            string email = collection.Get("email");
            string password = collection.Get("password");
            MyDBContext context = new MyDBContext();
            User_KH user = context.User_KH.Where(m => m.Account.email == email && m.Account.passwords == password).FirstOrDefault();
            if (user != null)
            {
                Session.Add("userID", user.id_KH);
                Session.Add("FullName", user.Account.fullName);
                return RedirectToAction("Home", "Site");

            }
            else
            {
                ViewBag.Message = "User Not Found !";
                return View("DangNhap");
            }

        }
        public ActionResult DangKy()
        {
            return View();
        }
        public ActionResult DangXuat()
        {
            return View();
        }
    }
}