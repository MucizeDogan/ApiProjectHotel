using HotelProject.WebUI.Dtos.BookingDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class BookingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult CreateBooking()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> AddBooking(CreateBookingDto createBookingDto)
        {
            createBookingDto.Status = "Waiting";
            var client = _httpClientFactory.CreateClient();
            var jsonResult = JsonConvert.SerializeObject(createBookingDto); // Bir veri göndereceğiz bu veriyi json olarka göndereceğimizden serialize diyoruz.
            StringContent stringContent = new StringContent(jsonResult, Encoding.UTF8, "application/json"); // İçeriğimizin dönüşümü için kullnacağımız bir sınıf. 
            // stringContent nesnemin içerisinde şu anda datamız, datamın kodlanmış hali ve türü bulunuyor.
            await client.PostAsync("http://localhost:5159/api/Booking",stringContent);

            return RedirectToAction("Index", "Default");
        }
    }
}
