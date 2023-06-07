using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.BookingDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
           _bookingService = bookingService;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            try
            {
                var data =_bookingService.TGetList();
                return Ok(data);
            }
            catch (Exception exp)
            {

                return BadRequest(exp.Message);
            }
        }
        [HttpPost]
        public IActionResult AddBooking(Booking booking)
        {
            try
            {
                _bookingService.TInsert(booking);
                return Ok();
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
            

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            try
            {
                var data =_bookingService.TGetById(id);
               _bookingService.TDelete(data);
                return Ok();
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }
        [HttpPut]
        public IActionResult UpdateBooking(Booking booking)
        {
            try
            {
               _bookingService.TUpdate(booking);
                return Ok();
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }

        [HttpGet("{id}")] // bu httpGet dışarıdan bi id parametresi alıcak.
        public IActionResult GetBooking(int id)
        {
            try
            {
                var data =_bookingService.TGetById(id);
                return Ok(data);
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }

        }
    }
}
