using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectDAL;

namespace DBSLWebApp.Controllers
{
    public class AdminController : Controller
    {
        private UserRepository userRepository = new UserRepository();
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

        public ActionResult BBDetails(int id)
        {
            return View();
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
        // GET: /Admin/EditBB/5

        public ActionResult EditBB(int id)
        {
            return View();
        }

        //
        // POST: /Admin/Edit/5

        [HttpPost]
        public ActionResult EditBB(int id, FormCollection collection)
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
        // GET: /Admin/DeleteUser/5

        public ActionResult DeleteUser(String username)
        {
            if (username == "Akash")
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

        public ActionResult DeleteBB(int id)
        {
            return View();
        }

        //
        // POST: /Admin/Delete/5

        [HttpPost]
        public ActionResult DeleteBB(int id, FormCollection collection)
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

        //
        // GET: /Admin/UserList/
        public ActionResult UserList()
        {
            List<User> users = userRepository.GetUserList();

            return View(users);
        }

        //
        // GET: /Admin/BBList/
        public ActionResult BBList()
        {
            List<User> users = userRepository.GetUserList();

            return View(users);
        }
    }
}
