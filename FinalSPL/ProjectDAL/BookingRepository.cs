using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDAL;

namespace ProjectDAL
{
    public class BookingRepository
    {
        DBSLEntities myOnlineBloodDonorEntities = null;

        public BookingRepository()
        {
            myOnlineBloodDonorEntities = new DBSLEntities();
        }

        public bool AddBooking(Booking booking)
        {
            myOnlineBloodDonorEntities.Bookings.Add(booking);
            return myOnlineBloodDonorEntities.SaveChanges() > 0;
        }

        public bool EditBooking(Booking booking)
        {
            myOnlineBloodDonorEntities.Bookings.Attach(booking);
            myOnlineBloodDonorEntities.Entry(booking).State = System.Data.Entity.EntityState.Modified;
            return myOnlineBloodDonorEntities.SaveChanges() > 0;
        }

        public bool DeleteBooking(Booking booking)
        {
            myOnlineBloodDonorEntities.Bookings.Attach(booking);
            myOnlineBloodDonorEntities.Entry(booking).State = System.Data.Entity.EntityState.Deleted;
            return myOnlineBloodDonorEntities.SaveChanges() > 0;
        }

        public List<Booking> GetBookingList()
        {
            return myOnlineBloodDonorEntities.Bookings.ToList();
        }

        public Booking GetBookingByBookingId(int id)
        {
            return myOnlineBloodDonorEntities.Bookings.FirstOrDefault(u => u.Id == id);
        }

        public Booking GetBookingByBookingId2(int bookingId)
        {
            return myOnlineBloodDonorEntities.Bookings.FirstOrDefault(u => u.Id == bookingId);
        }

    }
}