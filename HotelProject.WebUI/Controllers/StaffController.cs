using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

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

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient(); // Bir tane istemci oluşturduk.
            var responseMessage = await client.GetAsync("http://localhost:35402/api/Staff"); // Bu adrese istekte bullunuyoruz.
            if (responseMessage.IsSuccessStatusCode)             //Eğer ki burası başarılı bir durum kodu dönerse
            {
                var jsonResult = await responseMessage.Content.ReadAsStringAsync();       //Gelen veriyi jsonResult a ata
                var data = JsonConvert.DeserializeObject<List<StaffViewModel>>(jsonResult);    //Bize gelen data json türünde bu datayı deserilize edeceğiz  
                return View(data);
            }
            return View();
        }

        [HttpGet]
        public IActionResult AddStaff()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddStaff(AddStaffViewModel model)
        {
            var client= _httpClientFactory.CreateClient();
            var jsonResult=JsonConvert.SerializeObject(model); // Bir veri göndereceğiz bu veriyi json olarka göndereceğimizden serialize diyoruz.
            StringContent stringContent = new StringContent(jsonResult,Encoding.UTF8,"application/json"); // İçeriğimizin dönüşümü için kullnacağımız bir sınıf. 
            // stringContent nesnemin içerisinde şu anda datamız, datamın kodlanmış hali ve türü bulunuyor.
            var responseMessage = await client.PostAsync("http://localhost:35402/api/Staff", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteStaff(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:35402/api/Staff/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateStaff(int id)
        {
            var client = _httpClientFactory.CreateClient(); 
            var responseMessage = await client.GetAsync($"http://localhost:35402/api/Staff/{id}");
            if(!responseMessage.IsSuccessStatusCode)
            {
                return View();
            }
            var jsonResult = await responseMessage.Content.ReadAsStringAsync(); //Gelen veriyi jsonResult a ata
            var data = JsonConvert.DeserializeObject<UpdateViewModel>(jsonResult);
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateStaff(UpdateViewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonResult= JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonResult, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync($"http://localhost:35402/api/Staff", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
                
            }
            return View(); 
        }
    }
}
