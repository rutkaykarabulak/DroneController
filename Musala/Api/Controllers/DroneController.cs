using Microsoft.AspNetCore.Mvc;
using Musala.Api.Services;
using Musala.DbModels;
using Musala.EFModels;

namespace Musala.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DroneController : ControllerBase
    {
        #region Properties
        private IDroneService droneService;
        #endregion
        #region Actions
        [HttpGet]
        public IActionResult Get()
        {
            var list = droneService.GetAllDrones();
            return Ok(list);
        }
        #endregion

        public DroneController(PostgreSQLDbContext postgreSQLDbContext)
        {
            droneService = new DroneService(postgreSQLDbContext);
        }
    }
}
