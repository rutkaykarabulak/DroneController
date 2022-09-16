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
        /// <summary>
        /// Gets all drone from database
        /// </summary>
        /// <returns>List of all registered drones</returns>
        [HttpGet]
        public  IActionResult Get()
        {
            List<DroneEntity> drones = droneService.GetAllDrones().ToList();
            return Ok(drones);
        }

        [HttpPost("Register")]
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
                return NotFound($"Drone is not loadable due to its weight constraints." +
                    $" \nDrone weight limit: {drone.WeightLimit}, Drone + Medication weight: {drone.Weight + medication.Weight}");
            }
            return Ok(droneLoad);
        }

        [HttpGet("CheckBattery")]
        public async Task<IActionResult> CheckBattery([FromQuery]int droneId)
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

        [HttpGet("CheckLoadedDrone")]
        public IActionResult CheckLoadedDrone([FromQuery] int droneId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            List<MedicationEntity>? medications =  droneService.CheckLoadedDrone(droneId).ToList();
            if (medications == null)
            {
                return NotFound("There is no medications loaded in given drone");
            }

            return Ok(medications);
        }

        [HttpGet("CheckAvailableDrone")]
        public IActionResult CheckAvailableDrones()
        {
            List<DroneEntity> drones =   droneService.CheckAvailableDrones().ToList();

            if (drones == null)
            {
                return NotFound("There is no available drone");
            }

            return Ok(drones);
        }
        #endregion

        public DroneController(PostgreSQLDbContext postgreSQLDbContext)
        {
            droneService = new DroneService(postgreSQLDbContext);
            medicationService = new MedicationService(postgreSQLDbContext); 
        }
    }
}
