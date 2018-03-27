using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectDAL;

namespace DBSLWebApp.Controllers
{
    public class UserController : Controller
    {

        UserRepository userRepository = new UserRepository();
        //
        // GET: /User/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /User/Profile/

        public ActionResult Profile(String username)
        {
            User user = userRepository.GetUserByUsername(username);
            return View(user);
        }


        //
        // GET: /Home/Details/5

        public ActionResult Details(String username)
        {
            User user = userRepository.GetUserByUsername(username);
            return View(user);
        }

        //
        // GET: /User/Create

        public ActionResult Create()
        {

            return View();
        }

        //
        // POST: /User/Create

        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                // TODO: Add insert logic here

                if (ModelState.IsValid)
                {
                    userRepository.AddUser(user);
                    return RedirectToAction("Login", "Home");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /User/Edit/5

        public ActionResult Edit(String username)
        {

            User user = userRepository.GetUserByUsername(username);

            return View(user);
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        public ActionResult Edit(String username, User user)
        {
            try
            {
                // TODO: Add update logic here

                if (ModelState.IsValid)
                {
                    userRepository.EditUser(user);
                    return RedirectToAction("Details");

                }

                return View("Index");
            }
            catch
            {
                return View("Index");
            }
        }

        //
        // GET: /User/Delete/5

        public ActionResult Delete(String username)
        {
            User user = userRepository.GetUserByUsername(username);
            return View(user);
        }

        //
        // POST: /User/Delete/5

        [HttpPost]
        public ActionResult Delete(String username, User user)
        {

            try
            {
                // TODO: Add delete logic here

                if (userRepository.DeleteUser(user))
                {

                    return RedirectToAction("Create");
                }
                else
                {
                    return View();
                }

            }
            catch
            {
                return View();
            }
        }

        /*MyDbslEntities myDbslEntities = new MyDbslEntities();*/

        //
        // GET: /User/SearchDonor/5
        public ActionResult SearchDonor()
        {

            /*  List<User> users = userRepository.GetUserList();
            
              var query = from user in users
                          join pet in pets on person equals pet.Owner
                          select new { OwnerName = user.Username, PetName = pet.Name };
              */
            return View();
        }
    }
}
