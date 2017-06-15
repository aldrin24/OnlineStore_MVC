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
    public class AccountsController : Controller
    {
        // Initial Context Database.
        private Store_DB db = new Store_DB();

        // GET: Accounts
        public ActionResult Index()
        {
            tbl_Accounts Account = new tbl_Accounts();

            Store_DB db = new Store_DB();

            foreach (var item in db.tbl_Accounts)
            {
                //item.Category_ImagePath = "~/Content/Uploads/Categories/" + item.Category_ImageName;
                item.Account_ImagePath = "~/Content/Uploads/Users/" + item.Account_ImageName;

            }

            //if (Category.Category_ImageName == db.tbl_Categories.FirstOrDefault().Category_ImageName)
            //{
            //    Category.Category_ImageName = "~/Content/Uploads/Categories/" + Category.Category_ID.ToString() + ".png";
            //}

            var tbl_Accounts = db.tbl_Accounts.Include(t => t.tbl_Roles);
            return View(tbl_Accounts.ToList());
        }

        // GET: Accounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Accounts tbl_Accounts = db.tbl_Accounts.Find(id);
            if (tbl_Accounts == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Accounts);
        }

        // GET: Accounts/Create
        public ActionResult Create()
        {
            ViewBag.City_ID = new SelectList(db.tbl_Cities, "City_ID", "City_Name");
            ViewBag.Role_ID = new SelectList(db.tbl_Roles, "Role_ID", "Role_Name");
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Account_ID,Account_FirstName,Account_LastName,Account_BirthDate,Account_EmailAddress,Account_Country,Account_City,Account_Mobile,Account_Phone,Account_UserName,Account_Password,Account_ImageName,Role_ID,City_ID")] tbl_Accounts tbl_Accounts, HttpPostedFileBase file)
        {
            AccountsModel account = new AccountsModel();
            tbl_Cities cities = new tbl_Cities();

            using (Store_DB db = new Store_DB())
            {
                if (file != null)
                {
                    string pathToSave = Server.MapPath(@"~/Content/Uploads/Users/");

                    //tbl_Categories.Category_ImageName = file.FileName;

                    //var createUser = new tbl_Accounts()
                    //{
                    //    Account_ImageName = account.Account_ImageName,
                    //    Account_FirstName = account.AccountFirstName,
                    //    Account_LastName = account.AccountLastName,
                    //    Account_BirthDate = DateTime.Today.Date,
                    //    Account_UserName = account.AccountUserName,
                    //    Account_Password = account.AccountPassword,
                    //    Account_City = account.AccountCityList.SelectedValue.ToString(),
                    //    Role_ID = (int)account.AccountRolesList.SelectedValue,
                    //    Account_EmailAddress = account.AccountEmailAddress,
                    //    Account_Mobile = account.AccountMobile,
                    //    Account_Phone = account.AccountPhone,
                    //    Account_CreatedDate = account.AccountCreateDate,
                    //    Account_Country = null
                    //};

                    var checkUser = db.tbl_Accounts.SingleOrDefault().Account_UserName;

                    if (tbl_Accounts.Account_UserName != checkUser)
                    {
                        string NewFileName = String.Format("{0}.png", tbl_Accounts.Account_UserName);
                        tbl_Accounts.Account_ImageName = NewFileName;
                        file.SaveAs(Path.Combine(pathToSave, NewFileName));
                    }

                    db.tbl_Accounts.Add(tbl_Accounts);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            //if (ModelState.IsValid)
            //{
            //    db.tbl_Accounts.Add(tbl_Accounts);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            ViewBag.City_ID = new SelectList(db.tbl_Cities, "City_ID", "City_Name", cities.City_ID);
            ViewBag.Role_ID = new SelectList(db.tbl_Roles, "Role_ID", "Role_Name", tbl_Accounts.Role_ID);
            return View(tbl_Accounts);
        }

        // GET: Accounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Accounts tbl_Accounts = db.tbl_Accounts.Find(id);
            if (tbl_Accounts == null)
            {
                return HttpNotFound();
            }
            ViewBag.Role_ID = new SelectList(db.tbl_Roles, "Role_ID", "Role_Name", tbl_Accounts.Role_ID);
            return View(tbl_Accounts);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Account_ID,Account_FirstName,Account_LastName,Account_BirthDate,Account_EmailAddress,Account_Country,Account_City,Account_Mobile,Account_Phone,Account_UserName,Account_Password,Role_ID,Account_CreatedDate")] tbl_Accounts tbl_Accounts, HttpPostedFileBase AccountEdit)
        {
            if (ModelState.IsValid)
            {
                if (AccountEdit != null)
                {
                    string pathToSave = Server.MapPath(@"~/Content/Uploads/Users/");

                    //tbl_Categories.Category_ImageName = file.FileName;

                    var replaceUserProfilePhoto = new tbl_Accounts()
                    {
                        Account_ID = tbl_Accounts.Account_ID,
                        Account_ImagePath = pathToSave
                    };

                    string NewFileName = String.Format("{0}.png", replaceUserProfilePhoto.Account_ID);
                    replaceUserProfilePhoto.Account_ImageName = NewFileName;
                    AccountEdit.SaveAs(Path.Combine(pathToSave, NewFileName));
                }

                db.Entry(tbl_Accounts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Role_ID = new SelectList(db.tbl_Roles, "Role_ID", "Role_Name", tbl_Accounts.Role_ID);
            return View(tbl_Accounts);
        }

        // GET: Accounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Accounts tbl_Accounts = db.tbl_Accounts.Find(id);
            if (tbl_Accounts == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Accounts);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Accounts tbl_Accounts = db.tbl_Accounts.Find(id);
            db.tbl_Accounts.Remove(tbl_Accounts);
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
