using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.Dtos.RoomDto
{
    public class RoomUpdateDto
    {
        public int RoomID { get; set; }
        [Required(ErrorMessage = "Please enter the room number")]
        public string RoomNumber { get; set; }
        public string RoomCoverImage { get; set; }
        [Required(ErrorMessage = "Please enter the price!")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Please enter the room title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter the Bed count")]
        public string BedCount { get; set; }
        [Required(ErrorMessage = "Please enter the Bath count")]
        public string BathCount { get; set; }
        public string Wifi { get; set; }
        [Required(ErrorMessage = "Please enter the Description")]
        public string Description { get; set; }
    }
}
