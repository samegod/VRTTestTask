using Core;
using UnityEngine;
using Vehicle;

namespace UI
{
    public class MetricsPanel : MonoBehaviour
    {
        [SerializeField] private MetricsLine speedLine;
        [SerializeField] private MetricsLine rotationsLine;
        [SerializeField] private MetricsLine engineStatusLine;
        [SerializeField] private MetricsLine gearPositionLine;
        [SerializeField] private MetricsLine transmissionModeLine;
        [SerializeField] private MetricsLine distanceLine;

        private void FixedUpdate()
        {
            VehicleMetrics playerMetrics = PlayerCarMetricsProvider.PlayerVehicleMetrics;
            if (!playerMetrics)
                return;
            
            speedLine.SetValue(playerMetrics.Velocity.ToString("0"));
            rotationsLine.SetValue(playerMetrics.EngineRotations.ToString());
            engineStatusLine.SetValue(playerMetrics.EngineStatus.ToString());
            gearPositionLine.SetValue(playerMetrics.ActiveGearPosition.ToString());
            transmissionModeLine.SetValue(playerMetrics.TransmissionOperatingMode.ToString());
            distanceLine.SetValue(playerMetrics.DistanceToTheCar.ToString("0.00"));
        }
    }
}
