using System;
using System.Collections.Generic;

namespace HotelProject.DataAccessLayer.Models
{
    public partial class Subscribe
    {
        public int SubscribeId { get; set; }
        public string Mail { get; set; } = null!;
    }
}
