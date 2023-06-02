using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
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
        public IActionResult TestimonialList()
        {
            try
            {
                var data = _testimonialService.TGetList();
                return Ok(data);
            }
            catch (Exception exp)
            {

                return BadRequest(exp.Message);
            }
        }
        [HttpPost]
        public IActionResult AddTestimonial(Testimonial testimonial)
        {
            try
            {
                _testimonialService.TInsert(testimonial);
                return Ok();
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            try
            {
                var data = _testimonialService.TGetById(id);
                _testimonialService.TDelete(data);
                return Ok();
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }
        [HttpPut]
        public IActionResult UpdateTestimonial(Testimonial testimonial)
        {
            try
            {
                _testimonialService.TUpdate(testimonial);
                return Ok();
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }

        }
        [HttpGet("{id}")] // bu httpGet dışarıdan bi id parametresi alıcak.
        public IActionResult GetTestimonial(int id)
        {
            try
            {
                var data = _testimonialService.TGetById(id);
                return Ok(data);
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }

        }
    }
}
