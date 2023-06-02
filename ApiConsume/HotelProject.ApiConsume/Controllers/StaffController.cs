using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpGet]
        public IActionResult StaffList()
        {
            try
            {
                var data = _staffService.TGetList();
                return Ok(data);
            }
            catch (Exception exp)
            {

               return BadRequest(exp.Message);
            }
        }
        [HttpPost]
        public IActionResult AddStaff(Staff staff)
        {
            try
            {
                _staffService.TInsert(staff);
                return Ok();
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteStaff(int id)
        {
            try
            {
                var data = _staffService.TGetById(id);
                _staffService.TDelete(data);
                return Ok();
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }
        [HttpPut]
        public IActionResult UpdateStaff(Staff staff)
        {
            try
            {
                _staffService.TUpdate(staff);
                return Ok();
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
           
        }
        [HttpGet("{id}")] // bu httpGet dışarıdan bi id parametresi alıcak.
        public IActionResult GetStaff(int id)
        {
            try
            {
                var data = _staffService.TGetById(id);
                return Ok(data);
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
            
        }
    }
}
