using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebApi.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private readonly ISubscribeService _subscribeService;

        public SubscribeController(ISubscribeService subscribeService)
        {
            _subscribeService = subscribeService;
        }

        [HttpGet]
        public ApiResponse SubscribeList()
        {
            try
            {
                var data = _subscribeService.TGetList();
                return new ApiResponse { IsSuccessful = true, Message = "Successful", Set = data };
            }
            catch (Exception exp)
            {

                return new ApiResponse { IsSuccessful = false, Message = "Error", Set = exp.StackTrace };
            }
        }
        [HttpPost]
        public ApiResponse AddSubscribe(Subscribe subscribe)
        {
            try
            {
                _subscribeService.TInsert(subscribe);
                return new ApiResponse { IsSuccessful = true, Message = "Successfully Added", Set = subscribe };
            }
            catch (Exception exp)
            {
                return new ApiResponse { IsSuccessful = false, Message = "Error", Set = exp.StackTrace };
            }
        }
        [HttpDelete]
        public ApiResponse DeleteSubscribe(int id)
        {
            try
            {
                var data = _subscribeService.TGetById(id);
                _subscribeService.TDelete(data);
                return new ApiResponse { IsSuccessful = true, Message = "Successfully Deleted", Set = data };
            }
            catch (Exception exp)
            {
                return new ApiResponse { IsSuccessful = false, Message = "Error", Set = exp.Message };
            }
        }
        [HttpPut]
        public ApiResponse UpdateSubscribe(Subscribe subscribe)
        {
            try
            {
                _subscribeService.TUpdate(subscribe);
                return new ApiResponse { IsSuccessful = true, Message = "Successfully Updated", Set = subscribe };
            }
            catch (Exception exp)
            {
                return new ApiResponse { IsSuccessful = false, Message = "Error", Set = exp.StackTrace };
            }

        }
        [HttpGet("{id}")] // bu httpGet dışarıdan bi id parametresi alıcak.
        public ApiResponse GetSubscribe(int id)
        {
            try
            {
                var data = _subscribeService.TGetById(id);
                return new ApiResponse { IsSuccessful = true, Message = "Successfully Get", Set = data };
            }
            catch (Exception exp)
            {
                return new ApiResponse { IsSuccessful = false, Message = "Error", Set = exp.StackTrace };
            }

        }
    }
}
