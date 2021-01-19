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
    public class ModuleController : Controller
    {
        // GET: Module
        public ActionResult ProductSize()
        {

            SizeDAO sizeDAO = new SizeDAO();
            List<Size> list = sizeDAO.getList();
            return View("ProductSize", list);
        }
        public ActionResult ProductSide()
        {

           ProductDAO productDAO = new ProductDAO();
            List<Giay> list = productDAO.getList(7);
            return View("ProductSide", list);
        }
        public ActionResult NewSide()
        {

            PostDAO postDAO = new PostDAO();
            List<BaiViet> list = postDAO.getList(7);
            return View("NewSide", list);
        }
        public ActionResult HomePost()
        {

            PostDAO postDAO = new PostDAO();
            List<BaiViet> list = postDAO.getList(3);
            return View("HomePost", list);
        }
        public ActionResult Post()
        {

            PostDAO postDAO = new PostDAO();
            List<BaiViet> list = postDAO.getList();
            return View("Post",list);
        }
        public ActionResult SaleSite()
        {
            //CategoryDAO categoryDAO = new CategoryDAO();
            //List<LoaiGiay> list = categoryDAO.getList();
            return View("SaleSite"/*, list*/);
        }
        public ActionResult MainMenu()
        {
            CategoryDAO categoryDAO = new CategoryDAO();
            List<LoaiGiay> list = categoryDAO.getList();
            return View("MainMenu",list);
        }
        public ActionResult SlideShow()
        {
            SlideDAO slideDAO = new SlideDAO();
            List<Slider> list = slideDAO.getList("slideshow");
            return View("SlideShow",list);
        }
    }
}