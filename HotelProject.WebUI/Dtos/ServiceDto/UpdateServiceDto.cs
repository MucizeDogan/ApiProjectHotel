using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.ServiceDto
{
    public class UpdateServiceDto
    {
        [Required(ErrorMessage = "Please enter service ID")]
        public int ServiceID { get; set; }
        [Required(ErrorMessage = "Please enter service icon link")]
        public string ServiceIcon { get; set; }
        [Required(ErrorMessage = "Please enter service Title")]
        [StringLength(100, ErrorMessage = "The service title can be up to 100 characters.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter service Description")]
        [StringLength(600, ErrorMessage = "The service Description can be up to 100 characters.")]
        public string Description { get; set; }
    }
}
