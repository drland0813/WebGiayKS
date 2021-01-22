using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyClass.Model;

namespace WebGiay.Areas.Admin.Controllers
{
    public class DonHangController : Controller
    {
        private MyDBContext db = new MyDBContext();

        // GET: Admin/DonHang
        public ActionResult Index()
        {
            var donHangs = db.DonHangs.Include(d => d.User_KH);
            return View(donHangs.ToList());
        }

        // GET: Admin/DonHang/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang donHang = db.DonHangs.Find(id);
            if (donHang == null)
            {
                return HttpNotFound();
            }
            return View(donHang);
        }

        // GET: Admin/DonHang/Create
        public ActionResult Create()
        {
            ViewBag.id_KH = new SelectList(db.User_KH, "id_KH", "id_KH");
            return View();
        }

        // POST: Admin/DonHang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "soDH,id_KH,ngayLap,ngayGiaoHang,tongTien,tinhTrang,tenNVGiaoHang")] DonHang donHang)
        {
            if (ModelState.IsValid)
            {
                db.DonHangs.Add(donHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_KH = new SelectList(db.User_KH, "id_KH", "id_KH", donHang.id_KH);
            return View(donHang);
        }

        // GET: Admin/DonHang/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang donHang = db.DonHangs.Find(id);
            if (donHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_KH = new SelectList(db.User_KH, "id_KH", "id_KH", donHang.id_KH);
            return View(donHang);
        }

        // POST: Admin/DonHang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "soDH,id_KH,ngayLap,ngayGiaoHang,tongTien,tinhTrang,tenNVGiaoHang")] DonHang donHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_KH = new SelectList(db.User_KH, "id_KH", "id_KH", donHang.id_KH);
            return View(donHang);
        }

        // GET: Admin/DonHang/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang donHang = db.DonHangs.Find(id);
            if (donHang == null)
            {
                return HttpNotFound();
            }
            return View(donHang);
        }

        // POST: Admin/DonHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DonHang donHang = db.DonHangs.Find(id);
            db.DonHangs.Remove(donHang);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
