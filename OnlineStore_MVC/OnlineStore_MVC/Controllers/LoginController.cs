using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineStore_MVC.Models;
using System.Configuration;

namespace OnlineStore_MVC.Controllers
{
    public class LoginController : Controller
    {
        Store_DB db = new Store_DB();

        // GET: LogIn
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AccountsModel user)
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

        public ActionResult Logout()
        {
            Session.Clear();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Register()
        {
            Store_DB db = new Store_DB();

            List<tbl_Cities> cityList = (from data in db.tbl_Cities
                                         select data).ToList();
            tbl_Cities objCities = new tbl_Cities();
            objCities.City_Name = "Select City";
            objCities.City_ID = 0;
            cityList.Insert(0, objCities);
            SelectList objCityModel = new SelectList(cityList, "City_ID", "City_Name", 0);

            AccountsModel objModelForCity = new AccountsModel();
            objModelForCity.AccountCityList = objCityModel;

            return View(objModelForCity);
        }

        [HttpPost]
        public ActionResult Register(AccountsModel user, int Cityid)
        {
            using (Store_DB db = new Store_DB())
            {
                List<tbl_Cities> cityList = (from data in db.tbl_Cities
                                             select data).ToList();
                tbl_Cities objCities = new tbl_Cities();
                objCities.City_Name = "Select City";
                objCities.City_ID = 0;
                cityList.Insert(0, objCities);
                SelectList objCityModel = new SelectList(cityList, "City_ID", "City_Name", 0);

                AccountsModel objModelForCity = new AccountsModel();
                objModelForCity.AccountCityList = objCityModel;

                var accountCitySelected = ViewBag.City_Name = cityList.Where(c => c.City_ID == Cityid).FirstOrDefault().City_Name;

                if (ModelState.IsValid)
                {
                    var createAccount = new tbl_Accounts()
                    {
                        Account_FirstName = user.AccountFirstName,
                        Account_LastName = user.AccountLastName,
                        Account_BirthDate = user.AccountBirthDate,
                        Account_City = accountCitySelected,
                        Account_EmailAddress = user.AccountEmailAddress,
                        Account_UserName = user.AccountUserName,
                        Account_Password = user.AccountPassword,
                        Account_Mobile = user.AccountMobile,
                        Account_Phone = user.AccountPhone,
                        Account_CreatedDate = user.AccountCreateDate
                    };

                    db.tbl_Accounts.Add(createAccount);
                    db.SaveChanges();

                    return RedirectToAction("Index", "Home");
                }

                return View(objModelForCity);
            }
        }
    }
}