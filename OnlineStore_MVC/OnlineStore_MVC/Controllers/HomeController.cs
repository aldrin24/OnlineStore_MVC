using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineStore_MVC.Models;

namespace OnlineStore_MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Store_DB db = new Store_DB();

            foreach (var item in db.tbl_ImageCommercialSlider)
            {
                item.Image_Path = "~/Content/Uploads/SlideShow/" + item.Image_Name;
            }

            return View(db.tbl_ImageCommercialSlider.ToList());
        }

        [HttpPost]
        public ActionResult Index(AccountsModel user)
        {
            using (Store_DB db = new Store_DB())
            {
                var userLogin = (db.tbl_Accounts.SingleOrDefault(u => u.Account_UserName.ToLower() == user.AccountUserName.ToLower() && u.Account_Password == user.AccountPassword));

                if (userLogin != null)
                {
                    Session["AccountID"] = userLogin.Account_ID;
                    Session["AccountUserName"] = userLogin.Account_UserName.ToLower();
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "User name or Password is incorrect!");
            }
            return View();
        }

        public ActionResult Single()
        {
            return View();
        }

        public ActionResult Contect()
        {
            return View();
        }

        public ActionResult Blog()
        {
            return View();
        }

        public ActionResult Blog_Single()
        {
            return View();
        }

        public ActionResult Checkout()
        {
            return View();
        }

        public ActionResult Products()
        {
            return View();
        }
    }
}