
using Microsoft.AspNetCore.Mvc;
using FluentValidations.API.Requests;

namespace FluentValidations.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FVController : ControllerBase
    {
        public FVController()
        {
        }

        [HttpGet]
        public IActionResult Get([FromQuery] RequestToValidate request)
        {
            return Ok();
        }
    }
}
