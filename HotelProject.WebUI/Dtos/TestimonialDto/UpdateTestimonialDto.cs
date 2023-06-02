using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.TestimonialDto
{
    public class UpdateTestimonialDto
    {
        [Required(ErrorMessage = "Please enter Testimonial ID")]
        public int TestimonialID { get; set; }
        [Required(ErrorMessage = "Please enter Testimonial Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter Testimonial Title")]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
