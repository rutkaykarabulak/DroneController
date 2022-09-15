using System.ComponentModel.DataAnnotations;
using static Musala.Utils.CommonTypes;
using Musala.Utils;
using System.ComponentModel;

namespace Musala.DbModels
{
    public class DroneEntity
    {
        /// <summary>
        /// Id of the Drone.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Serial number of the drone.
        /// </summary>
        [Required, MaxLength(Constants.maxCharacterLength)]
        public string SerialNumber { get; set; } = string.Empty;
        /// <summary>
        /// Model of the drone.
        /// </summary>
        [Required]
        public DroneModel Model { get; set; }
        /// <summary>
        /// Weight of the drone(total weight of the item it carries)
        /// </summary>
        [Range(Constants.weightLimitMin, Constants.weightLimitMax, ErrorMessage = Constants.droneWeightError)]
        [DefaultValue(0)]
        public float Weight{ get; set; }

        /// <summary>
        /// Maximum weight that drone can lift depending on its model.
        /// </summary>
        public float WeightLimit { get; set; }

        /// <summary>
        /// Battery level of drone.
        /// </summary>

        [DefaultValue(Constants.batteryLevelMax)]
        public float BatteryCapacity { get; set; } = Constants.batteryLevelMax;
        /// <summary>
        /// State of the drone.
        /// </summary>
        [Required]
        public DroneState State { get; set; }
    }
}
