using System;
using System.Collections.Generic;

namespace HotelProject.DataAccessLayer.Models
{
    public partial class Staff
    {
        public int StaffId { get; set; }
        public string Name { get; set; } = null!;
        public string JobTitle { get; set; } = null!;
        public string TwitterUrl { get; set; } = null!;
        public string InstagramUrl { get; set; } = null!;
    }
}
