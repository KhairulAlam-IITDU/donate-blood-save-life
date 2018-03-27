using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DBSLWebApp.Models;
using ProjectDAL;

namespace DBSLWebApp.Controllers
{

    public class HomeController : Controller
    {

        UserRepository userRepository = new UserRepository();
        BloodBankRepository bloodBankRepository = new BloodBankRepository();
        //
        // GET: /Home/

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AccountLogin login)
        {
            if (ModelState.IsValid)
            {
                if (userRepository.Validuser(login.Username, login.Password))
                {
                    FormsAuthentication.SetAuthCookie(login.Username, false);
                    User user = userRepository.GetUserByUserNameAndPassword(login.Username, login.Password);
                    Session["User"] = user;
                    if (user.UserName == "Akash")
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("Index", "User");
                    }
                }
                else if (bloodBankRepository.Validuser(login.Username, login.Password))
                {
                    FormsAuthentication.SetAuthCookie(login.Username, false);
                    BloodBank bloodBank = bloodBankRepository.GetBloodBankByCompanyNameAndPassword(login.Username, login.Password);
                    Session["User"] = bloodBank;
                    if (bloodBank.Company_name == "Akash")
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("Index", "BloodBank");
                    }
                }
                else
                {
                    return View("Login");
                }
            }
            else
            {
                return View("Login");
            }
        }


        /*public ActionResult Logout()
        {
            return View();
        }*/

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            return RedirectToAction("Index", "Home");

        }
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /About/

        public ActionResult About()
        {
            return View();
        }

        //
        // GET: /Contact Us/

        public ActionResult ContactUs()
        {
            return View();
        }



        //
        // GET: /Home/Create

        public ActionResult CreateBB()
        {
            return View();
        }

        //
        // POST: /Home/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Home/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
