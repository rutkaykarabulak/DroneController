using System.ComponentModel;

namespace Musala.Utils
{
    public interface CommonTypes
    {
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
}
