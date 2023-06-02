using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.TestimonialDto
{
    public class CreateTestimonial
    {
        [Required(ErrorMessage = "Please enter Testimonial Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter Testimonial Title")]
        [StringLength(100, ErrorMessage = "The Testimonial Title can be up to 100 characters.")]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
