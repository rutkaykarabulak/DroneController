using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Musala.EFModels
{
    [Table("DroneLoad")]
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
