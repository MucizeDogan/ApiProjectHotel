using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.Dtos.RoomDto;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Room2Controller : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;

        public Room2Controller(IRoomService roomService, IMapper mapper)
        {
            _roomService = roomService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Index()
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
        public IActionResult AddRoom(RoomAddDto roomAddDto)
        {
            try
            {
                var data = _mapper.Map<Room>(roomAddDto);
                _roomService.TInsert(data);
                return Ok(roomAddDto);
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateRoom(RoomUpdateDto model)
        {
            try
            {
                var data = _mapper.Map<Room>(model);
                _roomService.TUpdate(data);
                return Ok(model);
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }
    }
}
