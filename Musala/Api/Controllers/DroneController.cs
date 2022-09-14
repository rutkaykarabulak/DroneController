using Microsoft.AspNetCore.Mvc;
using Musala.DbModels;

namespace Musala.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DroneController : ControllerBase
    {
        #region Actions
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Test");
        }
        #endregion
    }
}
