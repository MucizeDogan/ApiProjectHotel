using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EfBookingDal(Context context) : base(context)
        {
        }

        public void ConfirmBooking(Booking booking)
        {
            var context = new Context();
            var data = context.Bookings.Where(x => x.BookingID == booking.BookingID).FirstOrDefault();
            data.Status = "Confirm";
            context.SaveChanges();
        }

        public void ConfirmBookingforId(int id)
        {
            var context = new Context();
            var data = context.Bookings.Find(id); 
            data.Status = "Confirm";
            context.SaveChanges();
        }
    }
}
