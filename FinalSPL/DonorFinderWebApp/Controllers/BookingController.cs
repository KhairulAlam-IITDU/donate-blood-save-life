using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectDAL;

namespace DonorFinderWebApp.Controllers
{
    public class BookingController : Controller
    {
        BookingRepository bookingRepository = new BookingRepository();
        //
        // GET: /Booking/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Booking/Details/5

        public ActionResult Details(int id)
        {
            Booking booking = bookingRepository.GetBookingByBookingId2(id);
            return View(booking);

        }

        //
        // GET: /Booking/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Booking/Create

        [HttpPost]
        public ActionResult Create(Booking booking)
        {
            try
            {
                // TODO: Add insert logic here

                if (ModelState.IsValid)
                {
                    bookingRepository.AddBooking(booking);
                    return RedirectToAction("Details", "Booking", new { id = booking.Id });

                }
                return View();
            }
            catch
            {
                return View();
            }
        }
        //
        // GET: /Booking/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Booking/Edit/5

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
        // GET: /Booking/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Booking/Delete/5

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