using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebApi.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet]
        public ApiResponse ServiceList()
        {
            try
            {
                var data = _serviceService.TGetList();
                return new ApiResponse { IsSuccessful = true, Message = "Successful", Set = data };
            }
            catch (Exception exp)
            {

                return new ApiResponse { IsSuccessful = false, Message = "Error", Set = exp.StackTrace };
            }
        }
        [HttpPost]
        public ApiResponse AddService(Service service)
        {
            try
            {
                _serviceService.TInsert(service);
                return new ApiResponse { IsSuccessful = true, Message = "Successfully Added", Set = service };
            }
            catch (Exception exp)
            {
                return new ApiResponse { IsSuccessful = false, Message = "Error", Set = exp.StackTrace };
            }
        }
        [HttpDelete]
        public ApiResponse DeleteService(int id)
        {
            try
            {
                var data = _serviceService.TGetById(id);
                _serviceService.TDelete(data);
                return new ApiResponse { IsSuccessful = true, Message = "Successfully Deleted", Set = data };
            }
            catch (Exception exp)
            {
                return new ApiResponse { IsSuccessful = false, Message = "Error", Set = exp.Message };
            }
        }
        [HttpPut]
        public ApiResponse UpdateService(Service service)
        {
            try
            {
                _serviceService.TUpdate(service);
                return new ApiResponse { IsSuccessful = true, Message = "Successfully Updated", Set = service };
            }
            catch (Exception exp)
            {
                return new ApiResponse { IsSuccessful = false, Message = "Error", Set = exp.StackTrace };
            }
        }

        [HttpGet("{id}")] // bu httpGet dışarıdan bi id parametresi alıcak.
        public ApiResponse GetService(int id)
        {
            try
            {
                var data = _serviceService.TGetById(id);
                return new ApiResponse { IsSuccessful = true, Message = "Successfully Get", Set = data };
            }
            catch (Exception exp)
            {
                return new ApiResponse { IsSuccessful = false, Message = "Error", Set = exp.StackTrace };
            }

        }
    }
}
