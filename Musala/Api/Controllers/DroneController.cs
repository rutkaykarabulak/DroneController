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
        private IMedicationService medicationService;
        #endregion
        #region Actions
        [HttpGet]
        public  IActionResult Get()
        {

            return Ok("test");
        }

        [HttpPost]
        public IActionResult Post([FromBody] DroneEntity drone)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Drone droneData = droneService.Create(drone);

            return Ok(droneData);
        }

        [HttpPost("LoadDrone")]
        public async Task<IActionResult> Post([FromQuery] int droneId, int medicationId)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            MedicationEntity? medication = await medicationService.GetMedication(medicationId);
            DroneEntity? drone = await droneService.GetDrone(droneId);

            if (drone == null)
            {
                return NotFound("There is no drone with the given id");
            }

            if (medication == null)
            {
                return NotFound("There is no medication with given id");
            }

            DroneLoad droneLoad = await droneService.LoadDrone(drone, medication);
            if (droneLoad == null)
            {
                return NotFound("Drone is not loadable");
            }
            return Ok(droneLoad);
        }

        [HttpGet("CheckBattery")]
        public async Task<IActionResult> Get([FromQuery]int droneId)
        {
            if (!ModelState.IsValid)
            {
                return NotFound(ModelState);
            }

            float? batteryLevel = await droneService.CheckDroneBattery(droneId);
            if (batteryLevel == null)
            {
                return NotFound("There is no drone with the given id");
            }

            string batteryInPercentage = String.Format("{0:0.##\\%}", batteryLevel);

            return Ok(batteryInPercentage);
        }
        #endregion

        public DroneController(PostgreSQLDbContext postgreSQLDbContext)
        {
            droneService = new DroneService(postgreSQLDbContext);
            medicationService = new MedicationService(postgreSQLDbContext); 
        }
    }
}
