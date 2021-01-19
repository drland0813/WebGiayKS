using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebGiay.Controllers
{
    public class KhachHangController : Controller
    {
        // GET: KhachHang
        public ActionResult DangNhap()
        {
            return View();
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