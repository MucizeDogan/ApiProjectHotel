using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebApi.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        [HttpGet]
        public ApiResponse TestimonialfList()
        {
            try
            {
                var data = _testimonialService.TGetList();
                return new ApiResponse { IsSuccessful = true, Message = "Successful", Set = data };
            }
            catch (Exception exp)
            {

                return new ApiResponse { IsSuccessful = false, Message = "Error", Set = exp.StackTrace };
            }
        }
        [HttpPost]
        public ApiResponse AddTestimonial(Testimonial testimonial)
        {
            try
            {
                _testimonialService.TInsert(testimonial);
                return new ApiResponse { IsSuccessful = true, Message = "Successfully Added", Set = testimonial };
            }
            catch (Exception exp)
            {
                return new ApiResponse { IsSuccessful = false, Message = "Error", Set = exp.StackTrace };
            }
        }
        [HttpDelete]
        public ApiResponse DeleteTestimonial(int id)
        {
            try
            {
                var data = _testimonialService.TGetById(id);
                _testimonialService.TDelete(data);
                return new ApiResponse { IsSuccessful = true, Message = "Successfully Deleted", Set = data };
            }
            catch (Exception exp)
            {
                return new ApiResponse { IsSuccessful = false, Message = "Error", Set = exp.Message };
            }
        }
        [HttpPut]
        public ApiResponse UpdateTestimonial(Testimonial testimonial)
        {
            try
            {
                _testimonialService.TUpdate(testimonial);
                return new ApiResponse { IsSuccessful = true, Message = "Successfully Updated", Set = testimonial };
            }
            catch (Exception exp)
            {
                return new ApiResponse { IsSuccessful = false, Message = "Error", Set = exp.StackTrace };
            }

        }
        [HttpGet("{id}")] // bu httpGet dışarıdan bi id parametresi alıcak.
        public ApiResponse GetTestimonial(int id)
        {
            try
            {
                var data = _testimonialService.TGetById(id);
                return new ApiResponse { IsSuccessful = true, Message = "Successfully Get", Set = data };
            }
            catch (Exception exp)
            {
                return new ApiResponse { IsSuccessful = false, Message = "Error", Set = exp.StackTrace };
            }

        }
    }
}
