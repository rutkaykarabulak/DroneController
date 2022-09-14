using Microsoft.EntityFrameworkCore;
using Musala.Utils;
using Musala.DbModels;
using Musala.EFModels;
using static Musala.Utils.CommonTypes;

namespace Musala.Api.Services
{
    public class DroneService : IDroneService
    {
        #region Properties
        private PostgreSQLDbContext _postgreDbContext;
        #endregion

        public DroneService(PostgreSQLDbContext postgreSQLDbContext)
        {
            _postgreDbContext = postgreSQLDbContext;
        }
        public IEnumerable<DroneEntity> GetAllDrones()
        {
            List<DroneEntity> result = new();
            List<Drone> dataList = _postgreDbContext.Drones.ToList();

            dataList.ForEach(row => result.Add(new DroneEntity()
            {
                Id = row.Id,
                SerialNumber = row.SerialNumber,
                Model = row.Model,
                BatteryCapacity = row.BatteryCapacity,
                Weight = row.Weight,
                WeightLimit = row.WeightLimit
            }));
            return result;
        }
        public async Task<DroneEntity>? GetDrone(int id)
        {
 
            Drone? droneData = await _postgreDbContext.Drones.FindAsync(id);

            if(droneData == null)
            {
                return null;
            }

            return new DroneEntity()
            {
                Id = droneData.Id,
                SerialNumber = droneData.SerialNumber,
                Model = droneData.Model,
                BatteryCapacity = droneData.BatteryCapacity,
                Weight = droneData.Weight,
                WeightLimit = droneData.WeightLimit
            };
        }
        public IEnumerable<DroneEntity> CheckAvailableDrones()
        {
            List<DroneEntity> result = new();

            List<Drone> dataList = _postgreDbContext.Drones.Where(d => d.State == DroneState.IDLE).ToList();

            dataList.ForEach(row => result.Add(new DroneEntity()
            {
                Id = row.Id,
                SerialNumber = row.SerialNumber,
                Model = row.Model,
                BatteryCapacity = row.BatteryCapacity,
                Weight = row.Weight,
                WeightLimit = row.WeightLimit
            }));

            return result;
        }

        public async Task<float> CheckDroneBattery(int droneId)
        {
            float batteryLevel = 0;
            DroneEntity drone = await GetDrone(droneId);

            if (drone == null)
            {
                string errMessage = "There is no drone with given id.";
                throw new Exception(errMessage);
            }
            batteryLevel = drone.BatteryCapacity;
            return batteryLevel;
        }

        public IEnumerable<MedicationEntity> CheckLoadedDrone(int droneId)
        {
            List<MedicationEntity> result = new();


            throw new NotImplementedException();
        }

        public void Create(DroneEntity drone)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> LoadDrone(DroneEntity drone, MedicationEntity medication)
        {
            float totalWeight = drone.Weight + medication.Weight;

            bool isDroneLoadable = (
                totalWeight < drone.WeightLimit
                && (drone.State == DroneState.IDLE)
                && drone.BatteryCapacity < Constants.criticBatteryLevel);

            if(!isDroneLoadable)
            {
                return false;
            }
            Random r = new();
            DroneLoad droneLoad = new()
            {
                Id = r.Next(0, 100),
                DroneId = drone.Id,
                MedicationId = medication.Id
            };
            _postgreDbContext.DroneLoads.Add(droneLoad);

            // update the drone's state
            Drone droneData = await _postgreDbContext.Drones.FindAsync(drone.Id);
            droneData.State = DroneState.LOADED;
            droneData.Weight = totalWeight;

            _postgreDbContext.SaveChanges();

            return true;
        }

        public Task<bool> Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task<DroneEntity> Update()
        {
            throw new NotImplementedException();
        }
    }
}
