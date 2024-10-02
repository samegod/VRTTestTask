using System;
using System.Net.NetworkInformation;
using UnityEngine;
using VehiclePhysics;

namespace Vehicle
{
    public class VehicleMetrics : MonoBehaviour
    {
        [SerializeField] private VPVehicleController vehicleController;
        [SerializeField] private float velocity;
        [SerializeField] private int engineRotations;
        [SerializeField] private int engineStatus;
        [SerializeField] private int activeGearPositon;
        [SerializeField] private VehiclePhysics.Gearbox.Type transmissionOperatingMode;

        private const float UPSTOKMPHMODIFIER = 3.6f;
        
        private void Update()
        {
            velocity = UPSToKmPH(vehicleController.speed);
            engineRotations = (int)(vehicleController.data.Get(Channel.Vehicle, VehicleData.EngineRpm) / 1000f);
            engineStatus = vehicleController.data.Get(Channel.Vehicle, VehicleData.EngineWorking);
            activeGearPositon = vehicleController.data.Get(Channel.Vehicle, VehicleData.GearboxGear);
            transmissionOperatingMode = vehicleController.gearbox.type;
        }

        //Units per second to kilometers per hour
        private float UPSToKmPH(float unitsPerSecond)
        {
            return unitsPerSecond * UPSTOKMPHMODIFIER;
        }
    }
}
