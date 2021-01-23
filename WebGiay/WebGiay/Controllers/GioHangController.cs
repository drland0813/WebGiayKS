using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyClass.DAO;
using MyClass.Model;
namespace WebGiay.Controllers
{
    public class GioHangController : Controller
    {

        MyDBContext context = new MyDBContext();
        // GET: GioHang
        public ActionResult Index()
        {


            ChiTietDH chiTietDH = Session["chiTietDH"] as ChiTietDH;
            Session.Remove("chiTietDH");

            if (chiTietDH != null)
            {
                Giay giay = context.Giays.FirstOrDefault(g => g.maGiay == chiTietDH.maGiay) as Giay;

                Cart sanpham = new Cart()
                {
                    giay = giay,
                    size = chiTietDH.size,
                    soLuong = chiTietDH.soLuongMua
                };

                List<Cart> listSP = new List<Cart>();
                if (Session["cart"] != null)
                {
                    listSP = Session["cart"] as List<Cart>;
                }

                listSP.Add(sanpham);
                Session["cart"] = listSP;


            }


            ViewData["cart"] = Session["cart"] as List<Cart>;
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
         
            List<Cart> listSP = new List<Cart>();

            if (Session["cart"] != null)
            {
                listSP = Session["cart"] as List<Cart>;
            }
            else
            {
                return View();
            }


            if (Session["userID"] == null)
            {
                TempData["msg"] = "<script>alert('Bạn cần phải đăng nhập trước khi đặt hàng');</script>";
            }

            else
            {
                int maKH = Convert.ToInt32((Session["userID"]));
                User_KH kH = context.User_KH.FirstOrDefault(k => k.id_KH == maKH);

                DonHang donHang = new DonHang()
                {
                    User_KH = kH,
                    ngayLap = DateTime.Now,
                    tongTien = 0,
                    tinhTrang = 0
                };

                context.DonHangs.Add(donHang);
                context.SaveChanges();
                DonHang temp = context.DonHangs.OrderByDescending(n => n.soDH).First() as DonHang;

                decimal tongTien = 0;
                foreach (var item in listSP)
                {
                    ChiTietDH ct = new ChiTietDH()
                    {
                        maGiay = item.giay.maGiay,
                        size = item.size,
                        soLuongMua = item.soLuong,
                        soDH = temp.soDH
                    };

                    tongTien += (item.soLuong * item.giay.giaBan);
                    ChiTietGiay ctg = context.ChiTietGiays.FirstOrDefault(k => k.maGiay == ct.maGiay) as ChiTietGiay;
                    ctg.soLuongTon -= ct.soLuongMua;

                    temp.ChiTietDHs.Add(ct);
                    context.ChiTietDHs.Add(ct);
                    context.SaveChanges();
                }
                tongTien += tongTien * 0.01M;
                temp.tongTien = tongTien;

                context.SaveChanges();

                TempData["success"] = "<script>alert('Quý khách đã đặt đơn hàng thành công');</script>";
                Session.Remove("cart");
            }

            ViewData["cart"] = listSP;
            return View();
        }
    }


}