using HotelProject.WebUI.Dtos.StaffDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Default
{
    public class _TeamPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _TeamPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var client = _httpClientFactory.CreateClient(); // Bir tane istemci oluşturduk.
            var responseMessage = await client.GetAsync("http://localhost:5159/api/Staff"); // Bu adrese istekte bullunuyoruz.
            if (responseMessage.IsSuccessStatusCode)             //Eğer ki burası başarılı bir durum kodu dönerse
            {
                var jsonResult = await responseMessage.Content.ReadAsStringAsync();       //Gelen veriyi jsonResult a ata
                var data = JsonConvert.DeserializeObject<List<ListStaffDto>>(jsonResult);    //Bize gelen data json türünde bu datayı deserilize edeceğiz  
                var selectedData = data.Take(4).ToList();
                return View(selectedData);
            }
            return View();
        }
    }
}
