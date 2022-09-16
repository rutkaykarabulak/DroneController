using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Musala.Utils;

namespace Musala.EFModels
{
    [Table(Constants.droneLoad)]
    public class DroneLoad
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }

        [Required]
        public int DroneId { get; set; }

        [Required]
        public int MedicationId { get; set; }
    }
}
