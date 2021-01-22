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
    public class BaiVietController : Controller
    {
        private MyDBContext db = new MyDBContext();

        // GET: Admin/BaiViet
        public ActionResult Index()
        {
            var baiViets = db.BaiViets.Include(b => b.ChuDeBV).Include(b => b.User_NV);
            return View(baiViets.ToList());
        }

        // GET: Admin/BaiViet/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiViet baiViet = db.BaiViets.Find(id);
            if (baiViet == null)
            {
                return HttpNotFound();
            }
            return View(baiViet);
        }

        // GET: Admin/BaiViet/Create
        public ActionResult Create()
        {
            ViewBag.maCD = new SelectList(db.ChuDeBVs, "maCD", "tenCD");
            ViewBag.id_NV = new SelectList(db.User_NV, "id_NV", "soCMND");
            return View();
        }

        // POST: Admin/BaiViet/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maBV,id_NV,maCD,slug,noiDung,trangThai,ngayTao,ngayDang,image,tenCD")] BaiViet baiViet)
        {
            if (ModelState.IsValid)
            {
                db.BaiViets.Add(baiViet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.maCD = new SelectList(db.ChuDeBVs, "maCD", "tenCD", baiViet.maCD);
            ViewBag.id_NV = new SelectList(db.User_NV, "id_NV", "soCMND", baiViet.id_NV);
            return View(baiViet);
        }

        // GET: Admin/BaiViet/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiViet baiViet = db.BaiViets.Find(id);
            if (baiViet == null)
            {
                return HttpNotFound();
            }
            ViewBag.maCD = new SelectList(db.ChuDeBVs, "maCD", "tenCD", baiViet.maCD);
            ViewBag.id_NV = new SelectList(db.User_NV, "id_NV", "soCMND", baiViet.id_NV);
            return View(baiViet);
        }

        // POST: Admin/BaiViet/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maBV,id_NV,maCD,slug,noiDung,trangThai,ngayTao,ngayDang,image,tenCD")] BaiViet baiViet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(baiViet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maCD = new SelectList(db.ChuDeBVs, "maCD", "tenCD", baiViet.maCD);
            ViewBag.id_NV = new SelectList(db.User_NV, "id_NV", "soCMND", baiViet.id_NV);
            return View(baiViet);
        }

        // GET: Admin/BaiViet/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiViet baiViet = db.BaiViets.Find(id);
            if (baiViet == null)
            {
                return HttpNotFound();
            }
            return View(baiViet);
        }

        // POST: Admin/BaiViet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BaiViet baiViet = db.BaiViets.Find(id);
            db.BaiViets.Remove(baiViet);
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
            BaiViet baiViet = db.BaiViets.Find(id);
            baiViet.trangThai = (baiViet.trangThai == 1) ? 2 : 1;
            if (baiViet.trangThai == 1)
            db.Entry(baiViet).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
