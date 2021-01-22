using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyClass.DAO;
using MyClass.Model;
namespace WebGiay.Controllers
{
    public class LienHeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            string fullname = collection.Get("fullName");
            string email = collection.Get("email");
            string phoneNumber = collection.Get("phonenumber");
            string address = collection.Get("address");
            string content = collection.Get("content");

            LienHe lh = new LienHe()
            {
                hoten = fullname,
                email = email,
                sdt = phoneNumber,
                diachi = address,
                noidung = content
            };

            LienHeDAO lienHeDAO = new LienHeDAO();
            lienHeDAO.AddLH(lh);

            ViewBag.Message = "Chào mừng bạn đến với shop giày " + fullname + "! Shop đã nhận được liên hệ của bạn.";
            return View();
        }

    }
}