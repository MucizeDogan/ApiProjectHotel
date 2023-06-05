using HotelProject.WebUI.Dtos.SubscribeDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult _SubscribePartial()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> _SubscribePartial(CreateSubscribeDto createSubscribeDto)
        {
           
            var client = _httpClientFactory.CreateClient();
            var jsonResult = JsonConvert.SerializeObject(createSubscribeDto); // Bir veri göndereceğiz bu veriyi json olarka göndereceğimizden serialize diyoruz.
            StringContent stringContent = new StringContent(jsonResult, Encoding.UTF8, "application/json"); // İçeriğimizin dönüşümü için kullnacağımız bir sınıf. 
            // stringContent nesnemin içerisinde şu anda datamız, datamın kodlanmış hali ve türü bulunuyor.
            await client.PostAsync("http://localhost:35402/api/Subscribe", stringContent);
            
            return RedirectToAction("Index","Default");
            
            
        }
    }
}
