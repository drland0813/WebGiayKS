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
    public class User_KHController : Controller
    {
        private MyDBContext db = new MyDBContext();

        // GET: Admin/User_KH
        public ActionResult Index()
        {
            var user_KH = db.User_KH.Include(u => u.Account);
            return View(user_KH.ToList());
        }

        // GET: Admin/User_KH/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_KH user_KH = db.User_KH.Find(id);
            if (user_KH == null)
            {
                return HttpNotFound();
            }
            return View(user_KH);
        }

        // GET: Admin/User_KH/Create
        public ActionResult Create()
        {
            ViewBag.id_KH = new SelectList(db.Accounts, "id_account", "fullName");
            return View();
        }

        // POST: Admin/User_KH/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_KH,diem,avatar")] User_KH user_KH)
        {
            if (ModelState.IsValid)
            {
                db.User_KH.Add(user_KH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_KH = new SelectList(db.Accounts, "id_account", "fullName", user_KH.id_KH);
            return View(user_KH);
        }

        // GET: Admin/User_KH/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_KH user_KH = db.User_KH.Find(id);
            if (user_KH == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_KH = new SelectList(db.Accounts, "id_account", "fullName", user_KH.id_KH);
            return View(user_KH);
        }

        // POST: Admin/User_KH/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_KH,diem,avatar")] User_KH user_KH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user_KH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_KH = new SelectList(db.Accounts, "id_account", "fullName", user_KH.id_KH);
            return View(user_KH);
        }

        // GET: Admin/User_KH/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_KH user_KH = db.User_KH.Find(id);
            if (user_KH == null)
            {
                return HttpNotFound();
            }
            return View(user_KH);
        }

        // POST: Admin/User_KH/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User_KH user_KH = db.User_KH.Find(id);
            db.User_KH.Remove(user_KH);
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
