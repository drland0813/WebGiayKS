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
    public class User_NVController : Controller
    {
        private MyDBContext db = new MyDBContext();

        // GET: Admin/User_NV
        public ActionResult Index()
        {
            var user_NV = db.User_NV.Include(u => u.Account).Include(u => u.LoaiNV);
            return View(user_NV.ToList());
        }

        // GET: Admin/User_NV/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_NV user_NV = db.User_NV.Find(id);
            if (user_NV == null)
            {
                return HttpNotFound();
            }
            return View(user_NV);
        }

        // GET: Admin/User_NV/Create
        public ActionResult Create()
        {
            ViewBag.id_NV = new SelectList(db.Accounts, "id_account", "fullName");
            ViewBag.id_LoaiNV = new SelectList(db.LoaiNVs, "id_LoaiNV", "tenLoai");
            return View();
        }

        // POST: Admin/User_NV/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_NV,id_LoaiNV,ngayBDLam,heSoLuong,ngaySinh,soCMND")] User_NV user_NV)
        {
            if (ModelState.IsValid)
            {
                db.User_NV.Add(user_NV);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_NV = new SelectList(db.Accounts, "id_account", "fullName", user_NV.id_NV);
            ViewBag.id_LoaiNV = new SelectList(db.LoaiNVs, "id_LoaiNV", "tenLoai", user_NV.id_LoaiNV);
            return View(user_NV);
        }

        // GET: Admin/User_NV/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_NV user_NV = db.User_NV.Find(id);
            if (user_NV == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_NV = new SelectList(db.Accounts, "id_account", "fullName", user_NV.id_NV);
            ViewBag.id_LoaiNV = new SelectList(db.LoaiNVs, "id_LoaiNV", "tenLoai", user_NV.id_LoaiNV);
            return View(user_NV);
        }

        // POST: Admin/User_NV/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_NV,id_LoaiNV,ngayBDLam,heSoLuong,ngaySinh,soCMND")] User_NV user_NV)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user_NV).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_NV = new SelectList(db.Accounts, "id_account", "fullName", user_NV.id_NV);
            ViewBag.id_LoaiNV = new SelectList(db.LoaiNVs, "id_LoaiNV", "tenLoai", user_NV.id_LoaiNV);
            return View(user_NV);
        }

        // GET: Admin/User_NV/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_NV user_NV = db.User_NV.Find(id);
            if (user_NV == null)
            {
                return HttpNotFound();
            }
            return View(user_NV);
        }

        // POST: Admin/User_NV/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User_NV user_NV = db.User_NV.Find(id);
            db.User_NV.Remove(user_NV);
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
