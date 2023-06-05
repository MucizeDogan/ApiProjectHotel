using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutUController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutUController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            try
            {
                var data = _aboutService.TGetList();
                return Ok(data);
            }
            catch (Exception exp)
            {

                return BadRequest(exp.Message);
            }
        }
        [HttpPost]
        public IActionResult AddAbout(AboutU About)
        {
            try
            {
                _aboutService.TInsert(About);
                return Ok();
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }
        [HttpDelete]
        public IActionResult DeleteAbout(int id)
        {
            try
            {
                var data = _aboutService.TGetById(id);
                _aboutService.TDelete(data);
                return Ok();
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }
        [HttpPut]
        public IActionResult UpdateAbout(AboutU About)
        {
            try
            {
                _aboutService.TUpdate(About);
                return Ok();
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }

        }
        [HttpGet("{id}")] // bu httpGet dışarıdan bi id parametresi alıcak.
        public IActionResult GetAbout(int id)
        {
            try
            {
                var data = _aboutService.TGetById(id);
                return Ok(data);
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);

            }
        }
    }
}
