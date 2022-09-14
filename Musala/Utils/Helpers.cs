using static Musala.Utils.CommonTypes;

namespace Musala.Utils
{
    public class Helpers
    {
        public float getEligibleWeightLimitForDrone(DroneModel droneModel)
        {
            float value = 0f;
            switch(droneModel)
            {
                case DroneModel.Lightweight:
                   value =  Constants.lightWeight;
                    break;
                case DroneModel.Middleweight:
                    value = Constants.middleWeight;
                    break;
                case DroneModel.Cruiserweight:
                    value = Constants.cruiserWeight;
                    break;
                case DroneModel.Heavyweight:
                    value = Constants.heavyWeight;
                    break;

                default:
                    break;
            }
            return value;
        }
    }
}
