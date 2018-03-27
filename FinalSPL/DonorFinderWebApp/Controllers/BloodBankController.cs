using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using ProjectDAL;

namespace DonorFinderWebApp.Controllers
{
    public class BloodBankController : Controller
    {
        DBSLEntities onlineBloodDonorEntities = new DBSLEntities();
        
        BloodBankRepository bloodBankRepository = new BloodBankRepository();

        BloodGroupStockRepository bloodGroupStockRepository = new BloodGroupStockRepository();

        //
        // GET: /BloodBank/

        public ActionResult Index()
        {

            return View();

/*            if (CheckAuthentication())
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }*/
        }

        //
        // GET: /BloodBank/Details/5

        public ActionResult Details(string username)
        {
            BloodBank bloodBank = bloodBankRepository.GetBloodBankByBloodBankUserName(username);
            return View(bloodBank);
        }

        //
        // GET: /BloodBank/StockDetails/5

        public ActionResult StockDetails(string username)
        {
            
            /*List<BloodBank> bbank = new BloodBankRepository().GetBloodBankListByUserName(username);
            List<BloodGroupStock> bgstk = new BloodGroupStockRepository().GetBloodGroupStockListByBloodBankUserName(username);

            IEnumerable<BloodGroupStock> query = from bb in bbank
                join bg in bgstk on bb.UserName equals bg.BBUsername 
                select bg
            ;*/

            var bbank = from m in onlineBloodDonorEntities.BloodBanks select m;

            bbank = bbank.Where(b => b.UserName.Contains(username));

            List<BloodGroupStock> bgstk = new List<BloodGroupStock>();

            foreach (var bg in bbank)
            {
                bgstk.AddRange(onlineBloodDonorEntities.BloodGroupStocks.Where( bs => bs.BBUsername.Equals(bg.UserName)));
            }


            return View(bgstk);
        }

        //
        // GET: /BloodBank/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /BloodBank/Create

        [HttpPost]
        public ActionResult Create(BloodBank bloodBank)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    bloodBankRepository.AddBloodBank(bloodBank);
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
        // GET: /BloodBank/Edit/5

        public ActionResult Edit(String username)
        {
            BloodBank bloodBank = bloodBankRepository.GetBloodBankByBloodBankUserName(username);

            return View(bloodBank);
        }

        //
        // POST: /BloodBank/Edit/5

        [HttpPost]
        public ActionResult Edit(String username, BloodBank bloodBank)
        {
            try
            {
                // TODO: Add update logic here

                if (ModelState.IsValid)
                {
                    bloodBankRepository.EditBloodBank(bloodBank);
                    return RedirectToAction("Details");

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        //
        // GET: /BloodBank/EditStock/5

/*        public ActionResult EditStock(String username)
        {
            BloodBank bloodBank = bloodBankRepository.GetBloodBankByBloodBankUserName(username);

            return View(bloodBank);
        }

        //
        // POST: /BloodBank/EditStock/5

        [HttpPost]
        public ActionResult EditStock(String username, BloodBank bloodBank)
        {
            try
            {
                // TODO: Add update logic here

                if (ModelState.IsValid)
                {
                    bloodBankRepository.EditBloodBank(bloodBank);
                    return RedirectToAction("Details");

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }*/

        //
        // GET: /BloodBank/Delete/5

        public ActionResult Delete(String username)
        {
            BloodBank bloodBank = bloodBankRepository.GetBloodBankByBloodBankUserName(username);
            return View(bloodBank);
        }

        //
        // POST: /BloodBank/Delete/5

        [HttpPost]
        public ActionResult Delete(String username, BloodBank bloodBank)
        {
            try
            {
                // TODO: Add delete logic here
                if (bloodBankRepository.DeleteBloodBank(bloodBank))
                {
                    return RedirectToAction("Login", "Home"); 
                }
                return View();

            }
            catch
            {
                return View();
            }
        }
        [Authorize]
        public ActionResult SearchDonor(string city, string bloodGroup)
        {

            return View(onlineBloodDonorEntities.Users.Where(x => x.City == city && x.BloodGroup == bloodGroup).ToList());

        }

        public ActionResult AddBgStock(String username)
        {
            BloodGroupStock bloodGroupStock = new BloodGroupStock();

            return View(bloodGroupStock);
        }

        public ActionResult StockDetailsviewer(string username)
        {

            /*List<BloodBank> bbank = new BloodBankRepository().GetBloodBankListByUserName(username);
            List<BloodGroupStock> bgstk = new BloodGroupStockRepository().GetBloodGroupStockListByBloodBankUserName(username);

            IEnumerable<BloodGroupStock> query = from bb in bbank
                join bg in bgstk on bb.UserName equals bg.BBUsername 
                select bg
            ;*/

            var bbank = from m in onlineBloodDonorEntities.BloodBanks select m;

            /*string bbankname = Session["BloodBank"].ToString();*/

            bbank = bbank.Where(b => b.UserName.Contains(username));

            List<BloodGroupStock> bgstk = new List<BloodGroupStock>();

            foreach (var bg in bbank)
            {
                bgstk.AddRange(onlineBloodDonorEntities.BloodGroupStocks.Where(bs => bs.BBUsername.Equals(bg.UserName)));
            }

            return View(bgstk);
        }


        public ActionResult BookingDetails(string username)
        {

            /*List<BloodBank> bbank = new BloodBankRepository().GetBloodBankListByUserName(username);
            List<BloodGroupStock> bgstk = new BloodGroupStockRepository().GetBloodGroupStockListByBloodBankUserName(username);

            IEnumerable<BloodGroupStock> query = from bb in bbank
                join bg in bgstk on bb.UserName equals bg.BBUsername 
                select bg
            ;*/

            var bbank = from m in onlineBloodDonorEntities.BloodBanks select m;

            /*string bbankname = Session["BloodBank"].ToString();*/

            bbank = bbank.Where(b => b.UserName.Contains(username));

            List<Booking> bgstk = new List<Booking>();

            foreach (var bg in bbank)
            {
                bgstk.AddRange(onlineBloodDonorEntities.Bookings.Where(bs => bs.BBUsername.Equals(bg.UserName)));
            }

            return View(bgstk);
        }

/*        public bool CheckAuthentication()
        {
            if (Session["BloodBank"].ToString()=="BloodBank")
                return true;

            return false;
        }*/
    }
}
