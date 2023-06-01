using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class StaffController : Controller
    {
        // **** HTTPCLIENT nedir?
        //Projemizin bir başka uç noktayla(endpoint) iletişim kurması ve bu noktaya Http istekleri atabilmesini sağlayan bir sınıftır.Http isteklerimizi Get, Put, Delete veya Post olarak asenkron olarak yapmamızı sağlamaktadır.
        private readonly IHttpClientFactory _httpClientFactory;
        public StaffController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task <IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient(); // Bir tane istemci oluşturduk.
            var responseMessage = await client.GetAsync("http://localhost:5159/api/Staff");
            return View();
        }
    }
}
