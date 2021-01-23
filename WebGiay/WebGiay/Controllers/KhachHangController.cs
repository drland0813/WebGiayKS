using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyClass.DAO;
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
            User_KH user = context.User_KH.
                Where(m => m.Account.index_quyen == 0).
                Where(m => m.Account.email == email && m.Account.passwords == password).
                FirstOrDefault();
            if (user != null)
            {
                Session.Add("userID", user.id_KH);
                Session.Add("FullName", user.Account.fullName);
                return RedirectToAction("Home", "Site");

            }
            else
            {
                ViewBag.Message = "SDT, email không tồn tại, hoặc mật khẩu của bạn không đúng";
                return View("DangNhap");
            }

        }

        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangKy(FormCollection collection)
        {
            string fullname = collection.Get("fullName");
            string email = collection.Get("email");
            string phoneNumber = collection.Get("phone");
            string diachi = collection.Get("diaChi");
            string gioitinh = collection.Get("gioitinh");
            string password = collection.Get("passwords");
            string confirmpassword = collection.Get("confirmPasswords");

            MyDBContext context = new MyDBContext();
            Account checkEmail = context.Accounts.FirstOrDefault(a => a.email.Equals(email));
            Account checkSDT = context.Accounts.FirstOrDefault(a => a.sdt.Equals(phoneNumber));

            if (checkEmail != null)
            {
                TempData["msg"] = "<script>alert('Email đã tồn tại');</script>";
            }
            else if (checkSDT != null)
            {
                TempData["msg"] = "<script>alert('Số điện thoại đã tồn tại');</script>";
            }
            else
            {
                Account ac = new Account()
                {
                    fullName = fullname,
                    email = email,
                    sdt = phoneNumber,
                    gioiTinh = gioitinh,
                    passwords = password,
                    ngayTao = DateTime.Now,
                    diaChi = diachi,
                    index_quyen = 0
                };

                AccountDAO AD = new AccountDAO();
                AD.addAccount(ac);

                TempData["msg"] = "<script>alert('Quý khách đã đăng ký thành công');</script>";

                Session.Add("userID", ac.id_account);
                Session.Add("FullName", ac.fullName);

            }
            return View();
        }
        public ActionResult DangXuat()
        {
            return View();
        }
    }
}