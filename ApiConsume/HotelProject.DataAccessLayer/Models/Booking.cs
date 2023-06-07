using System;
using System.Collections.Generic;

namespace HotelProject.DataAccessLayer.Models
{
    public partial class Booking
    {
        public int BookingId { get; set; }
        public string Name { get; set; } = null!;
        public string Mail { get; set; } = null!;
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string AdultCount { get; set; } = null!;
        public string ChildCount { get; set; } = null!;
        public string SpecialRequest { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Status { get; set; } = null!;
    }
}
