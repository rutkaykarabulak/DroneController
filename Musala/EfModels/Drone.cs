using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Musala.EFModels
{
    [Table("Drone")]
    public class Drone
    {
        [Key, Required]
        public int Id { get; set; }

        [MaxLength(100), Required]
        public string SerialNumber { get; set; } = string.Empty;

        [Required]
        public DroneModel Model { get; set; }

        [Required]
        public double WeightLimit { get; set; }

        [Required]
        public double BatteryCapacity { get; set; }

        [Required]
        public DroneState State { get; set; }
    }

    public enum DroneModel
    {
        Lightweight, // 0
        Middleweight, // 1
        Cruiserweight, // 2
        Heavyweight // 3

    }

    public enum DroneState
    {
        IDLE, // 0
        LOADING, // 1
        LOADED, // 2
        DELIVERING, // 3
        DELIVERED, // 4
        RETURNING // 5
    }
}
