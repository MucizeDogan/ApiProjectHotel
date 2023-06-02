using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.ServiceDto
{
    public class CreateServiceDto
    {

        [Required(ErrorMessage = "Please enter service icon link")]
        public string ServiceIcon { get; set; }
        [Required(ErrorMessage = "Please enter service Title")]
        [StringLength(100,ErrorMessage = "The service title can be up to 100 characters.")]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
