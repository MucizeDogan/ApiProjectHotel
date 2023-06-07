using System;
using System.Collections.Generic;

namespace HotelProject.DataAccessLayer.Models
{
    public partial class Service
    {
        public int ServiceId { get; set; }
        public string ServiceIcon { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
