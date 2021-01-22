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
    public class LoaiNVsController : Controller
    {
        private MyDBContext db = new MyDBContext();

        // GET: Admin/LoaiNVs
        public ActionResult Index()
        {
            return View(db.LoaiNVs.ToList());
        }

        // GET: Admin/LoaiNVs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiNV loaiNV = db.LoaiNVs.Find(id);
            if (loaiNV == null)
            {
                return HttpNotFound();
            }
            return View(loaiNV);
        }

        // GET: Admin/LoaiNVs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/LoaiNVs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_LoaiNV,tenLoai,LuongCB,phuCap,chucVu")] LoaiNV loaiNV)
        {
            if (ModelState.IsValid)
            {
                db.LoaiNVs.Add(loaiNV);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaiNV);
        }

        // GET: Admin/LoaiNVs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiNV loaiNV = db.LoaiNVs.Find(id);
            if (loaiNV == null)
            {
                return HttpNotFound();
            }
            return View(loaiNV);
        }

        // POST: Admin/LoaiNVs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_LoaiNV,tenLoai,LuongCB,phuCap,chucVu")] LoaiNV loaiNV)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiNV).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaiNV);
        }

        // GET: Admin/LoaiNVs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiNV loaiNV = db.LoaiNVs.Find(id);
            if (loaiNV == null)
            {
                return HttpNotFound();
            }
            return View(loaiNV);
        }

        // POST: Admin/LoaiNVs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoaiNV loaiNV = db.LoaiNVs.Find(id);
            db.LoaiNVs.Remove(loaiNV);
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
