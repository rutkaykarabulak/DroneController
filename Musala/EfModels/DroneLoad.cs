using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Musala.Utils;

namespace Musala.EFModels
{
    [Table(Constants.droneLoad)]
    public class DroneLoad
    {
        [Key, Required]
        public int Id { get; set; }

        [Required]
        public int DroneId { get; set; }

        [Required]
        public int MedicationId { get; set; }
    }
}
