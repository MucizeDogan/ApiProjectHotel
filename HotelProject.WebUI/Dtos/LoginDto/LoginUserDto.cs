using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.LoginDto
{
    public class LoginUserDto
    {
        [Required(ErrorMessage ="Please enter the Username!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please enter the Password!")]
        public string Password{ get; set; }
    }
}
