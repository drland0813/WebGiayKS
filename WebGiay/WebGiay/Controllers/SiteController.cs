using MyClass.DAO;
using MyClass.Model;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
namespace WebGiay.Controllers
{
    public class SiteController : Controller
    {
        ProductDAO productDAO = new ProductDAO();
        // GET: Site
        public ActionResult Index(String slug = null)
        {
            LinkDAO LinkDAO = new LinkDAO();

            if (slug == null)
            {
                return this.Home();
            }
            else
            {
                Link row_link = LinkDAO.getRow(slug);
                if (row_link != null)
                {
                    String linktype = row_link.table_name;
                    switch (linktype)
                    {
                        case "LoaiGiay":
                            return this.ProductCategory(slug);
                        case "BaiViet":
                            return this.PostDetail(slug);
                    }
                }
                else
                {
                    Giay row_product = productDAO.getRow(slug);
                    if (row_product != null)
                    {
                        return ProductDetail(slug);
                    }
                    else
                    {
                        return this.Product();
                    }
                }
            }
            return Error404();
        }
        public ActionResult Search()
        {

            return View("Search");
        }
        public ActionResult DeitalProductCategory(int maloai)
        {
            ProductDAO productyDAO = new ProductDAO();
            List<Giay> list = productyDAO.getList2(maloai);
            return View("DeitalProductCategory", list);
        }
        public ActionResult PostDetail(String slug)
        {
            return View("PostDetail");

        }
        public ActionResult Product()
        {
            ProductDAO productyDAO = new ProductDAO();
            int pageSize = 21;
            var pagecurrent = 1;
            if (!string.IsNullOrEmpty(Request.QueryString["page"]))
            {
                pagecurrent = int.Parse(Request.QueryString["page"].ToString());
            }
            int pageFirst = (pagecurrent - 1) * pageSize;
            int total = productDAO.getCount();
            int num = (total / pageSize);
            if ((total / pageSize) % 2 != 0)
            {
                num++;
            }
            float num2 = total / pageSize;
            if (num < num2)
            {
                num++;
            }
            List<int> pageCount = new List<int>();
            for (int i = 1; i <= num; i++)
            {
                pageCount.Add(i);
            }
            ViewBag.pageCount = pageCount;
            List<Giay> list = productyDAO.getListAll(pageSize, pageFirst);
            return View("Product", list);
        }
        public ActionResult Error404()
        {
            return View("Error404");
        }

        [HttpGet]
        public ActionResult ProductDetail(String slug)
        {
            //khong hieu lam
            CategoryDAO categoryDAO = new CategoryDAO();
            ProductDAO productDAO = new ProductDAO();
            //List<Giay> list = productDAO.getList(slug);
            Giay row = productDAO.getRow(slug);
            if (row == null)
            {
                return RedirectToAction("Home", "Site");
            }
            int catid = row.maLoai;

            List<LoaiGiay> listcat = categoryDAO.getList2(catid);
            List<int> listcatid = new List<int>();
            foreach (LoaiGiay rowcat in listcat)
            {
                List<LoaiGiay> listcat2 = categoryDAO.getList2(rowcat.maLoai);
                foreach (LoaiGiay rowcat2 in listcat2)
                {
                    listcatid.Add(rowcat.maLoai);
                }
            }
            listcatid.Add(catid);
            List<Giay> listorder = productDAO.getList(listcatid, 8, row.maGiay);

            ViewData["GiayLienQuan"] = listorder;
            return View("ProductDetail", row);
        }


        [HttpPost]
        public ActionResult ProductDetail(FormCollection colection)
        {
            int maGiay = int.Parse(colection.Get("maGiay"));
            double size = double.Parse(colection.Get("size"));
            int sl = int.Parse(colection.Get("number"));

            ChiTietDH chiTietDH = new ChiTietDH()
            {
                maGiay = maGiay,
                size = size,
                soLuongMua = sl,
            };

            Session["chiTietDH"] = chiTietDH;

            return RedirectToAction("Index", "GioHang");
        }




        public ActionResult ProductCategory(String slug)
        {
            CategoryDAO categoryDAO = new CategoryDAO();
            List<LoaiGiay> list = categoryDAO.getList(slug);
            return View("ProductCategory", list);
        }
        public ActionResult Home()
        {
            ProductDAO productyDAO = new ProductDAO();
            List<Giay> listsp = productyDAO.getList(16);
            List<Giay> sphot = productDAO.getGiayHot();
            List<Giay> giayKM = productDAO.getGiayKM();
            ViewBag.Message = "Hello My first Web";
            ViewData["ListSP"] = listsp;
            ViewData["ListSPHot"] = sphot;
            ViewData["GiayKM"] = giayKM;

            return View("Home", listsp);
        }
    }
}