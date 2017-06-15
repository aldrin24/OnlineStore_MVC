using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineStore_MVC.Models;
using OnlineStore_MVC;

namespace OnlineStore_MVC.Controllers
{
    public class CitiesController : Controller
    {
        private Store_DB db = new Store_DB();

        // GET: Cities
        public ActionResult Index()
        {
            var tbl_Cities = db.tbl_Cities.Include(t => t.City_Name);
            return View(tbl_Cities.ToList());
        }

        // GET: Cities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Cities tbl_Cities = db.tbl_Cities.Find(id);
            if (tbl_Cities == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Cities);
        }

        // GET: Cities/Create
        public ActionResult Create()
        {
            ViewBag.AccountID = new SelectList(db.tbl_Accounts, "Account_ID", "Account_FirstName");
            return View();
        }

        // POST: Cities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "City_ID,City_Name,AccountID")] tbl_Cities tbl_Cities)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Cities.Add(tbl_Cities);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountID = new SelectList(db.tbl_Accounts, "Account_ID", "Account_FirstName", tbl_Cities.AccountID);
            return View(tbl_Cities);
        }

        // GET: Cities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Cities tbl_Cities = db.tbl_Cities.Find(id);
            if (tbl_Cities == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountID = new SelectList(db.tbl_Accounts, "Account_ID", "Account_FirstName", tbl_Cities.AccountID);
            return View(tbl_Cities);
        }

        // POST: Cities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "City_ID,City_Name,AccountID")] tbl_Cities tbl_Cities)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Cities).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountID = new SelectList(db.tbl_Accounts, "Account_ID", "Account_FirstName", tbl_Cities.AccountID);
            return View(tbl_Cities);
        }

        // GET: Cities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Cities tbl_Cities = db.tbl_Cities.Find(id);
            if (tbl_Cities == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Cities);
        }

        // POST: Cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Cities tbl_Cities = db.tbl_Cities.Find(id);
            db.tbl_Cities.Remove(tbl_Cities);
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
