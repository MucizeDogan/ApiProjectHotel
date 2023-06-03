using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.RegisterDto
{
    public class CreateNewUserDto
    {
        [Required(ErrorMessage = "Name field is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname field is required")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Username field is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "EMail field is required")]
        public string EMail { get; set; }
        public string City{ get; set; }

        [Required(ErrorMessage = "Password field is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password field is required")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

    }
}
