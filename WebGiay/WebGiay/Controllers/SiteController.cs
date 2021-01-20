using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyClass;
using MyClass.DAO;
using MyClass.Model;
namespace WebGiay.Controllers
{
    public class SiteController : Controller
    {
        ProductDAO productDAO = new ProductDAO();
        // GET: Site
        public ActionResult Index(String slug=null)
        {
            LinkDAO LinkDAO = new LinkDAO();

            if (slug == null)
            {
                return this.Home();
            }
            else
            {
                Link row_link = LinkDAO.getRow(slug);
                if(row_link != null)
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
        public ActionResult DeitalProductCategory(int maloai)
        {
            ProductDAO productyDAO = new ProductDAO();
            List<Giay> list = productyDAO.getList2(maloai);
            return View("DeitalProductCategory",list);
        }
        public ActionResult PostDetail(String slug)
        {
            return View("PostDetail");

        }
        public ActionResult Product()
        {
            ProductDAO productyDAO = new ProductDAO();
            List<Giay> list = productyDAO.getList();
            return View("Product",list);
        }
        public ActionResult Error404()
        {
            return View("Error404");
        }
        public ActionResult ProductDetail(String slug)
        {
            //khong hieu lam
            CategoryDAO categoryDAO = new CategoryDAO();
            ProductDAO productDAO = new ProductDAO();
            //List<Giay> list = productDAO.getList(slug);
            Giay row = productDAO.getRow(slug);
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
            List<Giay> listorder = productDAO.getList(listcatid, 8,row.maGiay);

            ViewData["GiayLienQuan"] = listorder;
            return View("ProductDetail", row);
        }
        public ActionResult ProductCategory(String slug)
        {
            CategoryDAO categoryDAO = new CategoryDAO();
            List<LoaiGiay> list = categoryDAO.getList(slug);
            return View("ProductCategory",list);
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