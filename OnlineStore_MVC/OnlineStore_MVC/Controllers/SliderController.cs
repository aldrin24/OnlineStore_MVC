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

namespace OnlineStore_MVC.Controllers
{
    public class SliderController : Controller
    {
        private Store_DB db = new Store_DB();

        // GET: ImageCommercialSlider
        public ActionResult Index()
        {
            Store_DB db = new Store_DB();

            foreach (var item in db.tbl_ImageCommercialSlider)
            {
                item.Slider_Path = "~/Content/Uploads/SlideShow/" + item.Image_Name;
            }

            return View(db.tbl_ImageCommercialSlider.ToList());
        }

        // GET: ImageCommercialSlider/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_ImageCommercialSlider tbl_ImageCommercialSlider = db.tbl_ImageCommercialSlider.Find(id);
            if (tbl_ImageCommercialSlider == null)
            {
                return HttpNotFound();
            }
            return View(tbl_ImageCommercialSlider);
        }

        // GET: ImageCommercialSlider/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ImageCommercialSlider/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Image_ID,Image_Name,Image_Path,Image_Timer,Image_Active")] tbl_ImageCommercialSlider tbl_ImageCommercialSlider, HttpPostedFileBase file)
        {
            using (Store_DB db = new Store_DB())
            {
                if (file != null)
                {
                    string pathToSave = Server.MapPath(@"~/Content/Uploads/SlideShow/");

                    var createSlideImage = new tbl_ImageCommercialSlider()
                    {
                        Image_Active = tbl_ImageCommercialSlider.Image_Active,
                        Image_Name = tbl_ImageCommercialSlider.Image_Name,
                        Image_Path = pathToSave,
                        Image_Timer = tbl_ImageCommercialSlider.Image_Timer
                    };

                    string newImageSlideName = String.Format("{0}.png", createSlideImage.Image_Name);
                    createSlideImage.Image_Name = newImageSlideName;
                    file.SaveAs(Path.Combine(pathToSave, newImageSlideName));

                    db.tbl_ImageCommercialSlider.Add(createSlideImage);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            return View(tbl_ImageCommercialSlider);
        }

        // GET: ImageCommercialSlider/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_ImageCommercialSlider tbl_ImageCommercialSlider = db.tbl_ImageCommercialSlider.Find(id);
            //tbl_ImageCommercialSlider tbl_ImageCommercialSlider = new tbl_ImageCommercialSlider();
            //var imageID = (db.tbl_ImageCommercialSlider.Where(i => i.Image_ID == id));

            if (tbl_ImageCommercialSlider == null)
            {
                return HttpNotFound();
            }

            return View(tbl_ImageCommercialSlider);
        }

        // POST: ImageCommercialSlider/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Image_ID,Image_Name,Image_Path,Image_Timer,Image_Active")] tbl_ImageCommercialSlider tbl_ImageCommercialSlider, HttpPostedFileBase ImageSlideEdit)
        {
            if (ModelState.IsValid)
            {
                if (ImageSlideEdit != null)
                {
                    string pathToSave = Server.MapPath(@"~/Content/Uploads/SlideShow/");

                    //tbl_Categories.Category_ImageName = file.FileName;

                    var replaceSlidePhoto = new tbl_ImageCommercialSlider()
                    {
                        Image_Active = tbl_ImageCommercialSlider.Image_Active,
                        Image_Name = tbl_ImageCommercialSlider.Image_Name,
                        Image_Path = pathToSave,
                        Image_Timer = tbl_ImageCommercialSlider.Image_Timer
                    };

                    string NewFileName = String.Format("{0}.png", replaceSlidePhoto.Image_Name);
                    replaceSlidePhoto.Image_Name = NewFileName;
                    ImageSlideEdit.SaveAs(Path.Combine(pathToSave, NewFileName));
                }
                db.Entry(tbl_ImageCommercialSlider).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_ImageCommercialSlider);
        }

        // GET: ImageCommercialSlider/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_ImageCommercialSlider tbl_ImageCommercialSlider = db.tbl_ImageCommercialSlider.Find(id);
            if (tbl_ImageCommercialSlider == null)
            {
                return HttpNotFound();
            }
            return View(tbl_ImageCommercialSlider);
        }

        // POST: ImageCommercialSlider/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_ImageCommercialSlider tbl_ImageCommercialSlider = db.tbl_ImageCommercialSlider.Find(id);
            db.tbl_ImageCommercialSlider.Remove(tbl_ImageCommercialSlider);
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
