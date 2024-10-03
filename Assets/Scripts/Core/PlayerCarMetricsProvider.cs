using UnityEngine;
using Vehicle;

namespace Core
{
    public class PlayerCarMetricsProvider : MonoBehaviour
    {
        public static VehicleMetrics PlayerVehicleMetrics;

        [SerializeField] private VehicleMetrics playerVehicleMetrics;

        private void Awake()
        {
            PlayerVehicleMetrics = playerVehicleMetrics;
        }

        public void SetNewMetrics(VehicleMetrics newMetrics)
        {
            PlayerVehicleMetrics = newMetrics;
            playerVehicleMetrics = newMetrics;
        }
    }
}
