using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DonorFinderWebApp.Models;
using ProjectDAL;

namespace DonorFinderWebApp.Controllers
{
    public class UserController : Controller
    {

        UserRepository userRepository = new UserRepository();
        DBSLEntities onlineBloodDonorEntities = new DBSLEntities();
        //
        // GET: /User/

        public ActionResult Index()
        {

            return View();

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
        public ActionResult SearchDonor(string city, string bloodGroup)
        {

            if (city == null && bloodGroup == null)
            {
                return View(onlineBloodDonorEntities.Users.ToList());
            }
            if (city != "" && bloodGroup != "")
            {
                return View(onlineBloodDonorEntities.Users.Where(x => x.City == city && x.BloodGroup == bloodGroup).ToList());    
            }
            else if (city!= "")
            {
                return View(onlineBloodDonorEntities.Users.Where(x => x.City == city).ToList());
            }
            else if (bloodGroup != "")
            {
                return View(onlineBloodDonorEntities.Users.Where(x => x.BloodGroup == bloodGroup).ToList());
            }
            else
            {
                return View(onlineBloodDonorEntities.Users.ToList());
            }


        }

        public ActionResult SearchDonorForBloodBank(string city, string bloodGroup)
        {

            if (city == null && bloodGroup == null)
            {
                return View(onlineBloodDonorEntities.Users.ToList());
            }
            if (city != "" && bloodGroup != "")
            {
                return View(onlineBloodDonorEntities.Users.Where(x => x.City == city && x.BloodGroup == bloodGroup).ToList());
            }
            else if (city != "")
            {
                return View(onlineBloodDonorEntities.Users.Where(x => x.City == city).ToList());
            }
            else if (bloodGroup != "")
            {
                return View(onlineBloodDonorEntities.Users.Where(x => x.BloodGroup == bloodGroup).ToList());
            }
            else
            {
                return View(onlineBloodDonorEntities.Users.ToList());
            }


        }

        public ActionResult SearchBloodBankByCity(string city)
        {

            /*
            /*            List<BloodBank> bb = bloodBankRepository.GetBloodBankListByCity(city);

                        List<BloodGroupStock> bg = BloodGroupStockRepository.GetBloodGroupStockByBloodGroupName(city);#1#
                        var bbank = from m in onlineBloodDonorEntities.BloodBanks join n in onlineBloodDonorEntities.BloodGroupStocks  on m.UserName equals n.BBUsername select 
            
                        select m;

                        List<BloodGroupStock> bgstk = new List<BloodGroupStock>();


                        foreach (var bg in bbank)
                        {
                            bgstk.AddRange(from o in onlineBloodDonorEntities.BloodGroupStocks where o.BloodGroupName.Equals(blood));
                        }
            */


            /*  bbank = from m in onlineBloodDonorEntities.BloodBanks where m.City.Equals(city)  select m;*/
            return View(onlineBloodDonorEntities.BloodBanks.Where(x => x.City == city).ToList());

        }


        public ActionResult SearchBloodBankByBloodGroup(string bloodGroup)
        {
            return View(onlineBloodDonorEntities.BloodGroupStocks.Where(x => x.BloodGroupName == bloodGroup).ToList());

        }

        public ActionResult SearchBloodBank()
        {
            return View();
        }

/*        public bool CheckAuthentication()
        {
            if (Session["User"].ToString() == "User")
                return true;

            return false;
        }*/
    }
}
