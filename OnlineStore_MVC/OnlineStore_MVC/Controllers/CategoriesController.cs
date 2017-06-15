using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineStore_MVC;
using OnlineStore_MVC.Models;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace OnlineStore_MVC.Controllers
{
    public class CategoriesController : Controller
    {
        private Store_DB db = new Store_DB();

        // GET: Categories
        public ActionResult Index()
        {
            Store_DB db = new Store_DB();

            foreach (var item in db.tbl_Categories)
            {
                item.Category_ImagePath = "~/Content/Uploads/Categories/" + item.Category_ImageName;

            }

            return View(db.tbl_Categories.ToList());
        }

        // GET: Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Categories tbl_Categories = db.tbl_Categories.Find(id);
            if (tbl_Categories == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Categories);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [Bind(Include = "Category_ID,Category_Name,Category_ImageName")] EXAMPLE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Category_ID,Category_Name,Category_ImageName")] tbl_Categories tbl_Categories, HttpPostedFileBase file)
        {
            using (Store_DB db = new Store_DB())
            {
                if (file != null)
                {
                    string pathToSave = Server.MapPath(@"~/Content/Uploads/Categories/");
                    
                    //tbl_Categories.Category_ImageName = file.FileName;

                    var createCategory = new tbl_Categories()
                    {
                        Category_Name = tbl_Categories.Category_Name,
                        Category_ImagePath = pathToSave
                    };
                    string NewFileName = String.Format("{0}.png", createCategory.Category_Name);
                    createCategory.Category_ImageName = NewFileName;
                    file.SaveAs(Path.Combine(pathToSave, NewFileName));

                    db.tbl_Categories.Add(createCategory);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            return View(tbl_Categories);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Categories tbl_Categories = db.tbl_Categories.Find(id);
            if (tbl_Categories == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Categories);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Category_ID,Category_Name,Category_ImageName")] tbl_Categories tbl_Categories, HttpPostedFileBase CategoryEdit)
        {
            if (ModelState.IsValid)
            {
                if (CategoryEdit != null)
                {
                    string pathToSave = Server.MapPath(@"~/Content/Uploads/Categories/");

                    //tbl_Categories.Category_ImageName = file.FileName;

                    var replaceCategoryPhoto = new tbl_Categories()
                    {
                        Category_Name = tbl_Categories.Category_Name,
                        Category_ImagePath = pathToSave
                    };

                    string NewFileName = String.Format("{0}.png", replaceCategoryPhoto.Category_Name);
                    replaceCategoryPhoto.Category_ImageName = NewFileName;
                    CategoryEdit.SaveAs(Path.Combine(pathToSave, NewFileName));
                }

                db.Entry(tbl_Categories).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Categories);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Categories tbl_Categories = db.tbl_Categories.Find(id);
            if (tbl_Categories == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Categories);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Categories tbl_Categories = db.tbl_Categories.Find(id);
            db.tbl_Categories.Remove(tbl_Categories);
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
