using Musala.DbModels;

namespace Musala.Api.Services
{
    public interface IDroneService
    {
        /// <summary>
        /// Gets all drone records in database.
        /// </summary>
        /// <returns>All drones recorded in database.</returns>
        public abstract IEnumerable<DroneEntity> GetAllDrones();

        /// <summary>
        /// Gets the drone with given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Drone with given id if it exists in database, null otherwise.</returns>
        public abstract Task<DroneEntity>? GetDrone(int id);

        /// <summary>
        /// Inserts a new drone to the database
        /// </summary>
        /// <param name="drone"></param>
        public abstract void Create(DroneEntity drone);

        /// <summary>
        /// Removes the drone with given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True if removal is successfull, false otherwise.</returns>
        public abstract Task<bool> Remove(int id);

        /// <summary>
        /// Updates the drone with given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Updated drone model</returns>
        public abstract Task<DroneEntity> Update(); // todo

        /// <summary>
        /// Loads the drone with given medication.
        /// </summary>
        /// <param name="drone"></param>
        /// <param name="medication"></param>
        /// <returns>True if loading opeartion is successfull, false otherwise.</returns>
        public abstract Task<bool> LoadDrone(DroneEntity drone, MedicationEntity medication);

        /// <summary>
        /// Checks the medications in given drone.
        /// </summary>
        /// <param name="medication"></param>
        /// <returns>List of medication items in drone if it has any, null otherwise.</returns>
        public abstract IEnumerable<MedicationEntity> CheckLoadedDrone(int droneId);

        /// <summary>
        /// Checks available drones for loading.
        /// </summary>
        /// <returns>List of available drones</returns>
        public abstract IEnumerable<DroneEntity> CheckAvailableDrones();

        /// <summary>
        /// Checks the battery level of given drone id.
        /// </summary>
        /// <param name="droneId"></param>
        /// <returns>Battery level of drone if drone exists, null otherwise.</returns>
        public abstract Task<float> CheckDroneBattery(int droneId);
    }
}
