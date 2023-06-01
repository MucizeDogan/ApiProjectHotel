using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebApi.Response;
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
        public ApiResponse RoomList()
        {
            try
            {
                var data = _roomService.TGetList();
                return new ApiResponse { IsSuccessful = true, Message = "Successful", Set = data };
            }
            catch (Exception exp)
            {

                return new ApiResponse { IsSuccessful = false, Message = "Error", Set = exp.StackTrace };
            }
        }
        [HttpPost]
        public ApiResponse AddStaff(Room room)
        {
            try
            {
                _roomService.TInsert(room);
                return new ApiResponse { IsSuccessful = true, Message = "Successfully Added", Set = room };
            }
            catch (Exception exp)
            {
                return new ApiResponse { IsSuccessful = false, Message = "Error", Set = exp.StackTrace };
            }
        }
        [HttpDelete]
        public ApiResponse DeleteStaff(int id)
        {
            try
            {
                var data = _roomService.TGetById(id);
                _roomService.TDelete(data);
                return new ApiResponse { IsSuccessful = true, Message = "Successfully Deleted", Set = data };
            }
            catch (Exception exp)
            {
                return new ApiResponse { IsSuccessful = false, Message = "Error", Set = exp.Message };
            }
        }
        [HttpPut]
        public ApiResponse UpdateStaff(Room room)
        {
            try
            {
                _roomService.TUpdate(room);
                return new ApiResponse { IsSuccessful = true, Message = "Successfully Updated", Set = room };
            }
            catch (Exception exp)
            {
                return new ApiResponse { IsSuccessful = false, Message = "Error", Set = exp.StackTrace };
            }

        }
        [HttpGet("{id}")] // bu httpGet dışarıdan bi id parametresi alıcak.
        public ApiResponse GetStaff(int id)
        {
            try
            {
                var data = _roomService.TGetById(id);
                return new ApiResponse { IsSuccessful = true, Message = "Successfully Get", Set = data };
            }
            catch (Exception exp)
            {
                return new ApiResponse { IsSuccessful = false, Message = "Error", Set = exp.StackTrace };
            }

        }
    }
}
