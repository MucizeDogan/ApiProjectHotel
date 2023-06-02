using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;

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
        public IActionResult SubscribeList()
        {
            try
            {
                var data = _subscribeService.TGetList();
                return Ok(data);
            }
            catch (Exception exp)
            {

                return BadRequest(exp.Message);
            }
        }
        [HttpPost]
        public IActionResult AddSubscribe(Subscribe subscribe)
        {
            try
            {
                _subscribeService.TInsert(subscribe);
                return Ok();
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }
        [HttpDelete]
        public IActionResult DeleteSubscribe(int id)
        {
            try
            {
                var data = _subscribeService.TGetById(id);
                _subscribeService.TDelete(data);
                return Ok();
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }
        [HttpPut]
        public IActionResult UpdateSubscribe(Subscribe subscribe)
        {
            try
            {
                _subscribeService.TUpdate(subscribe);
                return Ok();
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }

        }
        [HttpGet("{id}")] // bu httpGet dışarıdan bi id parametresi alıcak.
        public IActionResult GetSubscribe(int id)
        {
            try
            {
                var data = _subscribeService.TGetById(id);
                return Ok(data);
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }

        }
    }
}
