using System;
using System.Collections.Generic;

namespace HotelProject.DataAccessLayer.Models
{
    public partial class AboutU
    {
        public int AboutUid { get; set; }
        public string Title1 { get; set; } = null!;
        public string Title2 { get; set; } = null!;
        public string Content { get; set; } = null!;
        public int RoomCount { get; set; }
        public int StaffCount { get; set; }
        public int CustomerCount { get; set; }
    }
}
