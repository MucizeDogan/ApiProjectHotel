using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public IActionResult RoomList()
        {
            try
            {
                var data = _roomService.TGetList();
                return Ok(data);
            }
            catch (Exception exp)
            {

                return BadRequest(exp.Message);
            }
        }
        [HttpPost]
        public IActionResult AddRoom(Room room)
        {
            try
            {
                _roomService.TInsert(room);
                return Ok();
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }
        [HttpDelete]
        public IActionResult DeleteRoom(int id)
        {
            try
            {
                var data = _roomService.TGetById(id);
                _roomService.TDelete(data);
                return Ok();
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }
        [HttpPut]
        public IActionResult UpdateRoom(Room room)
        {
            try
            {
                _roomService.TUpdate(room);
                return Ok();
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }

        }
        [HttpGet("{id}")] // bu httpGet dışarıdan bi id parametresi alıcak.
        public IActionResult GetRoom(int id)
        {
            try
            {
                var data = _roomService.TGetById(id);
                return Ok(data);
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);

            }
        }
    }
}
