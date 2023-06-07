using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.ServiceDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ServiceController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var client = _httpClientFactory.CreateClient(); // Bir tane istemci oluşturduk.
            var responseMessage = await client.GetAsync("http://localhost:5159/api/Service"); // Bu adrese istekte bullunuyoruz.
            if (responseMessage.IsSuccessStatusCode)             //Eğer ki burası başarılı bir durum kodu dönerse
            {
                var jsonResult = await responseMessage.Content.ReadAsStringAsync();       //Gelen veriyi jsonResult a ata
                var data = JsonConvert.DeserializeObject<List<ListServiceDto>>(jsonResult);    //Bize gelen data json türünde bu datayı deserilize edeceğiz  
                return View(data);
            }
            return View();
        }

        [HttpGet]
        public IActionResult AddService()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddService(CreateServiceDto model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var client = _httpClientFactory.CreateClient();
            var jsonResult = JsonConvert.SerializeObject(model); // Bir veri göndereceğiz bu veriyi json olarka göndereceğimizden serialize diyoruz.
            StringContent stringContent = new StringContent(jsonResult, Encoding.UTF8, "application/json"); // İçeriğimizin dönüşümü için kullnacağımız bir sınıf. 
            // stringContent nesnemin içerisinde şu anda datamız, datamın kodlanmış hali ve türü bulunuyor.
            var responseMessage = await client.PostAsync("http://localhost:5159/api/Service", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> DeleteService(int id)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5159/api/Service/{id}");
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateService(int id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5159/api/Service/{id}");
            if(!responseMessage.IsSuccessStatusCode)
            {
                return View();
            }
            var jsonResult = await responseMessage.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<UpdateServiceDto>(jsonResult);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateService(UpdateServiceDto model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var client = _httpClientFactory.CreateClient();
            var jsonResult= JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonResult,Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync($"http://localhost:5159/api/Service",stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
