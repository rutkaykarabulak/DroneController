using Microsoft.AspNetCore.Mvc;
using Musala.Api.Services;
using Musala.DbModels;
using Musala.EFModels;

namespace Musala.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicationController: ControllerBase
    {
        #region Properties
        private IMedicationService medicationService;
        #endregion
        [HttpGet("GetAllMedications")]
        public IActionResult GetAllDrones()
        {
            List<MedicationEntity> medications = medicationService.GetAllMedications().ToList();

            if(medications.Count == 0)
            {
                return NotFound("There is no medication in database");
            }

            return Ok(medications);
        }
        public MedicationController(PostgreSQLDbContext postgreSQLDbContext)
        {
            medicationService = new MedicationService(postgreSQLDbContext);
        }
    }
}
