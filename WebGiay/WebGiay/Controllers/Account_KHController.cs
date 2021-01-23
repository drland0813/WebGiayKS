using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyClass.Model;

namespace WebGiay.Controllers
{
    public class Account_KHController : Controller
    {
        private MyDBContext db = new MyDBContext();

        // GET: Account_KH
        public ActionResult Index()
        {
            var accounts = db.Accounts.Include(a => a.ChiTietQuyen).Include(a => a.User_KH).Include(a => a.User_NV);
            return View(accounts.ToList());
        }

        // GET: Account_KH/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // GET: Account_KH/Create
        public ActionResult Create()
        {
            ViewBag.index_quyen = new SelectList(db.ChiTietQuyens, "index_quyen", "tenQuyen");
            ViewBag.id_account = new SelectList(db.User_KH, "id_KH", "id_KH");
            ViewBag.id_account = new SelectList(db.User_NV, "id_NV", "soCMND");
            return View();
        }

        // POST: Account_KH/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_account,index_quyen,fullName,ngayTao,gioiTinh,diaChi,sdt,email,passwords")] Account account)
        {
            if (ModelState.IsValid)
            {
                db.Accounts.Add(account);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.index_quyen = new SelectList(db.ChiTietQuyens, "index_quyen", "tenQuyen", account.index_quyen);
            ViewBag.id_account = new SelectList(db.User_KH, "id_KH", "id_KH", account.id_account);
            ViewBag.id_account = new SelectList(db.User_NV, "id_NV", "soCMND", account.id_account);
            return View(account);
        }

        // GET: Account_KH/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            ViewBag.index_quyen = new SelectList(db.ChiTietQuyens, "index_quyen", "tenQuyen", account.index_quyen);
            ViewBag.id_account = new SelectList(db.User_KH, "id_KH", "id_KH", account.id_account);
            ViewBag.id_account = new SelectList(db.User_NV, "id_NV", "soCMND", account.id_account);
            return View(account);
        }

        // POST: Account_KH/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_account,index_quyen,fullName,ngayTao,gioiTinh,diaChi,sdt,email,passwords")] Account account)
        {
            if (ModelState.IsValid)
            {
                db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.index_quyen = new SelectList(db.ChiTietQuyens, "index_quyen", "tenQuyen", account.index_quyen);
            ViewBag.id_account = new SelectList(db.User_KH, "id_KH", "id_KH", account.id_account);
            ViewBag.id_account = new SelectList(db.User_NV, "id_NV", "soCMND", account.id_account);
            return View(account);
        }

        // GET: Account_KH/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Account_KH/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Account account = db.Accounts.Find(id);
            db.Accounts.Remove(account);
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
