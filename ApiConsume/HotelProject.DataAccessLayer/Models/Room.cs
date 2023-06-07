using System;
using System.Collections.Generic;

namespace HotelProject.DataAccessLayer.Models
{
    public partial class Room
    {
        public int RoomId { get; set; }
        public string RoomNumber { get; set; } = null!;
        public string RoomCoverImage { get; set; } = null!;
        public int Price { get; set; }
        public string Title { get; set; } = null!;
        public string BedCount { get; set; } = null!;
        public string BathCount { get; set; } = null!;
        public string Wifi { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
