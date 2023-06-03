using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.RegisterDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;  //Bu sınıfta gerçekleşecek olan işlemler hangi sınıf için yapılacak(AppUser) 

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateNewUserDto createNewUserDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var appUser = new AppUser()
            {
                Name = createNewUserDto.Name,
                Surname = createNewUserDto.Surname,
                Email = createNewUserDto.EMail,
                UserName = createNewUserDto.Username,
                City=createNewUserDto.City

            };
            var user = await _userManager.CreateAsync(appUser,createNewUserDto.Password);
            if(user.Succeeded)
            {
                return RedirectToAction("Index","Login");
            }
            return View();
        }
    }
}
