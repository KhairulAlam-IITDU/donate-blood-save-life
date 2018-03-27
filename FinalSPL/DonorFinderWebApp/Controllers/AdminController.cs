using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using System.Web.Providers.Entities;
using ProjectDAL;
using User = ProjectDAL.User;


namespace DonorFinderWebApp.Controllers
{

    public class AdminController : Controller
    {
        private UserRepository userRepository = new UserRepository();

        BloodBankRepository bloodBankRepository = new BloodBankRepository();
        //
        // GET: /Admin/
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Admin/UserDetails/5

        public ActionResult UserDetails(String username)
        {
            User user = userRepository.GetUserByUsername(username);
            return View(user);
        }

        //
        // GET: /Admin/BBDetails/5

        public ActionResult BbDetails(String username)
        {
            BloodBank bloodBank = bloodBankRepository.GetBloodBankByBloodBankUserName(username);
            return View(bloodBank);
        }

        /*//
        // GET: /Admin/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Create

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
        }*/

        //
        // GET: /Admin/EditUser/5

        public ActionResult EditUser(String username)
        {
            User user = userRepository.GetUserByUsername(username);
            return View(user);
        }

        //
        // POST: /Admin/EditUser/5

        [HttpPost]
        public ActionResult EditUser(String username, User user)
        {
            try
            {
                // TODO: Add update logic here

                if (ModelState.IsValid)
                {
                    userRepository.EditUser(user);
                    return RedirectToAction("UserList");
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        //
        // GET: /Admin/EditBb/5

        public ActionResult EditBb(String username)
        {
            BloodBank bloodBank = bloodBankRepository.GetBloodBankByBloodBankUserName(username);
            return View(bloodBank);
        }

        //
        // POST: /Admin/Edit/5

        [HttpPost]
        public ActionResult EditBb(String username, BloodBank bloodBank)
        {
            try
            {
                // TODO: Add update logic here

                if (ModelState.IsValid)
                {
                    bloodBankRepository.EditBloodBank(bloodBank);
                    return RedirectToAction("BbList");
                }
                else
                {
                    return RedirectToAction("BbList");
                }
            }
            catch
            {
                return View();
            }
        }


        //
        // GET: /Admin/DeleteUser/5

        public ActionResult DeleteUser(String username)
        {
            if (username == "Admin")
            {
                return View("Index");
            }
            else
            {
                User user = userRepository.GetUserByUsername(username);
                return View(user);
            }

        }

        //
        // POST: /Admin/Delete/5

        [HttpPost]
        public ActionResult DeleteUser(String username, User user)
        {
            try
            {
                // TODO: Add delete logic here

                if (userRepository.DeleteUser(user))
                {
                    return RedirectToAction("UserList");
                }
                else
                {
                    return RedirectToAction("UserList");
                }

            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/DeleteBB/5

        public ActionResult DeleteBb(String username)
        {
            BloodBank bloodBank = bloodBankRepository.GetBloodBankByBloodBankUserName(username);
            return View(bloodBank);
        }

        //
        // POST: /Admin/Delete/5

        [HttpPost]
        public ActionResult DeleteBb(String username, BloodBank bloodBank)
        {
            try
            {
                // TODO: Add delete logic here

                if (bloodBankRepository.DeleteBloodBank(bloodBank))
                {
                    return RedirectToAction("BbList");
                }
                else
                {
                    return RedirectToAction("BbList");
                }

            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/UserList/
        public ActionResult UserList()
        {
            List<User> users = userRepository.GetUserList();

            return View(users);
        }

        //
        // GET: /Admin/BBList/
        public ActionResult BbList()
        {
            List<BloodBank> bbank = bloodBankRepository.GetBloodBankList();

            return View(bbank);
        }


    }
}
