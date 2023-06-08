using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiJWT.Models;

namespace WebApiJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        //Token üretimi deneme 
        [HttpGet("[action]")]
        public IActionResult Test()
        {
            return Ok(new CreateToken().CreateJWToken());
        }

        [HttpGet("[action]")]
        public IActionResult AdminToken()
        {
            return Ok(new CreateToken().CreateTokenforAdmin()); // Admin kontrollü olan metot
        }

        [Authorize]
        [HttpGet("[action]")]
        public IActionResult Test2()
        {
            return Ok("Welcome body");
        }

        [Authorize(Roles ="Admin,Visitor")]
        [HttpGet("[action]")]
        public IActionResult AdminTokenTest()
        {
            return Ok(" Admin or Visitor  ");
        }
    }
}
