using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebApi.Response;
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
        public ApiResponse StaffList()
        {
            try
            {
                var data = _staffService.TGetList();
                return new ApiResponse { IsSuccessful = true, Message = "Successful", Set = data };
            }
            catch (Exception exp)
            {

                return new ApiResponse { IsSuccessful = false, Message = "Error", Set = exp.StackTrace };
            }
        }
        [HttpPost]
        public ApiResponse AddStaff(Staff staff)
        {
            try
            {
                _staffService.TInsert(staff);
                return new ApiResponse { IsSuccessful = true, Message = "Successfully Added", Set = staff };
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
                var data = _staffService.TGetById(id);
                _staffService.TDelete(data);
                return new ApiResponse { IsSuccessful = true, Message = "Successfully Deleted", Set = data };
            }
            catch (Exception exp)
            {
                return new ApiResponse { IsSuccessful = false, Message = "Error", Set = exp.Message };
            }
        }
        [HttpPut]
        public ApiResponse UpdateStaff(Staff staff)
        {
            try
            {
                _staffService.TUpdate(staff);
                return new ApiResponse { IsSuccessful = true, Message = "Successfully Updated", Set = staff };
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
                var data = _staffService.TGetById(id);
                return new ApiResponse { IsSuccessful = true, Message = "Successfully Get", Set = data };
            }
            catch (Exception exp)
            {
                return new ApiResponse { IsSuccessful = false, Message = "Error", Set = exp.StackTrace };
            }
            
        }
    }
}
