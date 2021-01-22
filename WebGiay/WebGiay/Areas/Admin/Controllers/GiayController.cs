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
    public class GiayController : Controller
    {
        private MyDBContext db = new MyDBContext();

        // GET: Admin/Giay
        public ActionResult Index()
        {
            var giays = db.Giays.Include(g => g.LoaiGiay);
            return View(giays.ToList());
        }

        // GET: Admin/Giay/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Giay giay = db.Giays.Find(id);
            if (giay == null)
            {
                return HttpNotFound();
            }
            return View(giay);
        }

        // GET: Admin/Giay/Create
        public ActionResult Create()
        {
            ViewBag.maLoai = new SelectList(db.LoaiGiays, "maLoai", "tenLoai");
            return View();
        }

        // POST: Admin/Giay/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maGiay,trangThai,maLoai,tenGiay,slug,giaBan,giaNhap,ngayTao,image,chiTiet")] Giay giay)
        {
            if (ModelState.IsValid)
            {
                db.Giays.Add(giay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.maLoai = new SelectList(db.LoaiGiays, "maLoai", "tenLoai", giay.maLoai);
            return View(giay);
        }

        // GET: Admin/Giay/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Giay giay = db.Giays.Find(id);
            if (giay == null)
            {
                return HttpNotFound();
            }
            ViewBag.maLoai = new SelectList(db.LoaiGiays, "maLoai", "tenLoai", giay.maLoai);
            return View(giay);
        }

        // POST: Admin/Giay/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maGiay,trangThai,maLoai,tenGiay,slug,giaBan,giaNhap,ngayTao,image,chiTiet")] Giay giay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(giay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maLoai = new SelectList(db.LoaiGiays, "maLoai", "tenLoai", giay.maLoai);
            return View(giay);
        }

        // GET: Admin/Giay/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Giay giay = db.Giays.Find(id);
            if (giay == null)
            {
                return HttpNotFound();
            }
            return View(giay);
        }

        // POST: Admin/Giay/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Giay giay = db.Giays.Find(id);
            db.Giays.Remove(giay);
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
        public ActionResult Status(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Giay giay = db.Giays.Find(id);
            giay.trangThai = (giay.trangThai == 1) ? 2 : 1;
            if (giay.trangThai == 1)
                db.Entry(giay).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
