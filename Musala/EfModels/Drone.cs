using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Musala.Utils;
namespace Musala.EFModels
{
    [Table(Constants.drone)]
    public class Drone
    {
        [Key, Required]
        public int Id { get; set; }

        [MaxLength(Constants.maxCharacterLength), Required]
        public string SerialNumber { get; set; } = string.Empty;

        [Required]
        public DroneModel Model { get; set; }

        [Required, Range(Constants.weightLimitMin,Constants.weightLimitMax)]
        public float Weight { get; set; }

        [Required, Range(Constants.batteryLevelMin, Constants.batteryLevelMax)]
        [DefaultValue(Constants.batteryLevelMax)]
        public float BatteryCapacity { get; set; }

        [Required]
        [DefaultValue(DroneState.IDLE)]
        public DroneState State { get; set; }

        [DefaultValue(0)]
        public float WeightLimit { get; set; }
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
