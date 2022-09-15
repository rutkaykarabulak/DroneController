using Microsoft.EntityFrameworkCore;
using Musala.Utils;
using Musala.DbModels;
using Musala.EFModels;
using static Musala.Utils.CommonTypes;
using System.Security.Cryptography;

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
                WeightLimit = row.WeightLimit,
                State = row.State
            }));
            return result;
        }
        public async Task<DroneEntity> GetDrone(int id)
        {
 
            Drone? droneData = await _postgreDbContext.Drones.FindAsync(id);

            if(droneData == null)
            {
                string errMessage = "There is no drone with given id.";
                throw new Exception(errMessage);
            }

            return new DroneEntity()
            {
                Id = droneData.Id,
                SerialNumber = droneData.SerialNumber,
                Model = droneData.Model,
                BatteryCapacity = droneData.BatteryCapacity,
                Weight = droneData.Weight,
                WeightLimit = droneData.WeightLimit,
                State = droneData.State
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

        public async Task<float?> CheckDroneBattery(int droneId)
        {
            float batteryLevel = 0;
            DroneEntity drone = await GetDrone(droneId);

            if (drone == null)
            {
                return null;
            }
            batteryLevel = drone.BatteryCapacity;
            return batteryLevel;
        }

        public IEnumerable<MedicationEntity>? CheckLoadedDrone(int droneId)
        {
            List<MedicationEntity> result = new();

            List<DroneLoad> dataListDroneLoad = _postgreDbContext.DroneLoads.Where(d => d.DroneId == droneId).ToList();
            if (dataListDroneLoad == null)
            {
                return null;
            }
            List<Medication> dataListMedication = _postgreDbContext.Medications.ToList();

            foreach(DroneLoad dl in dataListDroneLoad)
            {
                Medication? medication = dataListMedication.FirstOrDefault(m => m.Id == dl.MedicationId);
                if (medication != null)
                {
                    MedicationEntity medicationEntity = new()
                    {
                        Id = medication.Id,
                        Code = medication.Code,
                        Weight = medication.Weight,
                        Name = medication.Name
                    };
                    result.Add(medicationEntity);
                }

            }

            return result;
        }

        public Drone Create(DroneEntity drone)
        {
            Random r = new();
            float weightLimit = Helpers.GetEligibleWeightLimitForDrone(drone.Model);
            Drone droneData = new()
            {
                Id = r.Next(0, 100),
                Model = drone.Model,
                SerialNumber = drone.SerialNumber,
                State = drone.State,
                BatteryCapacity = drone.BatteryCapacity,
                Weight = drone.Weight,
                WeightLimit = weightLimit
            };

            _postgreDbContext.Drones.Add(droneData);
            _postgreDbContext.SaveChanges();

            return droneData;
        }

        public async Task<DroneLoad?> LoadDrone(DroneEntity drone, MedicationEntity medication)
        {
            float totalWeight = drone.Weight + medication.Weight;

            bool isDroneLoadable = (
                totalWeight < drone.WeightLimit
                && (drone.State == DroneState.IDLE)
                && drone.BatteryCapacity > Constants.criticBatteryLevel);

            if(!isDroneLoadable)
            {
                return null;
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

            return droneLoad;
        }
    }
}
