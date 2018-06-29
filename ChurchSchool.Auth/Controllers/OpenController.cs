using Microsoft.AspNetCore.Mvc;

namespace ChurchSchool.Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult("Open!");
        }
    }
}