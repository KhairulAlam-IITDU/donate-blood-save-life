using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DonorFinderWebApp.Models;
using ProjectDAL;

namespace DonorFinderWebApp.Controllers
{
    [Authorize]
    public class BloodGroupStockController : Controller
    {

        BloodGroupStockRepository bloodGroupStockRepository = new BloodGroupStockRepository();
        BloodBankRepository bloodBankRepository = new BloodBankRepository();
        //
        // GET: /BloodGroupStock/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /BloodGroupStock/Details/5

        public ActionResult Details(int id)
        {
            BloodGroupStock bloodGroupStock = bloodGroupStockRepository.GetBloodGroupStockByBloodGroupStockId(id);
            return View(bloodGroupStock);
        }

        //
        // GET: /BloodGroupStock/Create

        public ActionResult Create(String username)
        {
           // BloodBank bloodBank = blo
            return View();
        }

        //
        // POST: /BloodGroupStock/Create

        [HttpPost]
        public ActionResult Create(BloodGroupStock bloodGroupStock)
        {
            try
            {
                // TODO: Add insert logic here

                if (ModelState.IsValid)
                {
                    bloodGroupStockRepository.AddBloodGroupStock(bloodGroupStock);
                    return RedirectToAction("StockDetails", "BloodBank", new { username = bloodGroupStock.BBUsername});
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /BloodGroupStock/Edit/5

        public ActionResult Edit(int id)
        {
            BloodGroupStock bloodGroupStock = bloodGroupStockRepository.GetBloodGroupStockByBloodGroupStockId(id);
            return View(bloodGroupStock);
        }

        //
        // POST: /BloodGroupStock/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, BloodGroupStock bloodGroupStock)
        {
            try
            {
                // TODO: Add insert logic here

                if (ModelState.IsValid)
                {
                    bloodGroupStockRepository.EditBloodGroupStock(bloodGroupStock);
                    return RedirectToAction("StockDetails", "BloodBank", new { username = bloodGroupStock.BBUsername });
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /BloodGroupStock/Delete/5

        public ActionResult Delete(int id)
        {
            BloodGroupStock bloodGroupStock = bloodGroupStockRepository.GetBloodGroupStockByBloodGroupStockId(id);
            return View(bloodGroupStock);
        }

        //
        // POST: /BloodGroupStock/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, BloodGroupStock bloodGroupStock)
        {
            try
            {
                // TODO: Add insert logic here

                if (bloodGroupStockRepository.DeleteBloodGroupStock(bloodGroupStock))
                {
                    return RedirectToAction("Index", "BloodBank");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        
    }

}
