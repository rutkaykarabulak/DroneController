using static Musala.Utils.CommonTypes;

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
        public string SerialNumber { get; set; } = string.Empty;
        /// <summary>
        /// Model of the drone.
        /// </summary>
        public DroneModel Model { get; set; }
        /// <summary>
        /// Weight limit of the drone. (500 gr max)
        /// </summary>
        public double WeightLimit { get; set; }

        /// <summary>
        /// Battery level of drone.
        /// </summary>
        public double BatteryCapacity { get; set; }
        /// <summary>
        /// State of the drone.
        /// </summary>
        public DroneState State { get; set; }
    }
}
