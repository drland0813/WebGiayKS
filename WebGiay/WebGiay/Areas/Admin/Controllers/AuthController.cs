using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyClass;
using MyClass.Model;
using MyClass.DAO;

namespace WebGiay.Areas.Admin.Controllers
{
    public class AuthController : Controller
    {

        // GET: Admin/Auth
        AccountDAO AccountDAO = new AccountDAO();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection thamso)
        {
            string tendangnhap = thamso["username"];
            string matkhau = thamso["password"];
            Account row_account = AccountDAO.getRow(tendangnhap);
            string error = "";
            if (row_account!= null)
            {
                if (row_account.passwords==matkhau)
                {
                    Session["UserAdmin"] = tendangnhap;
                    Session["UserID"] = row_account.id_account;
                    Session["UserFullName"] =row_account.fullName;
                    ViewBag.Error = "<p class='text-danger'>" + tendangnhap + "</p>";
                    Response.Redirect("~/Admin");
                }
                else
                {
                    error = "Mật khẩu không đúng!";
                }
            }
            else
            {
                error = "Tên đăng nhập không tồn tại";
            }
            return View();
        }
        public ActionResult Logout()
        {
         
            Session["UserAdmin"] = "";
            Session["UserID"] = "";
            Session["UserFullName"] = "";
            Response.Redirect("~/Admin/login");
            return null;
        }
    }
}