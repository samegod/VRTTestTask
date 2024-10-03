using System;
using UnityEngine;
using VehiclePhysics;
using Vehicles.Proximity;

namespace Vehicles
{
    public class VehicleMetrics : MonoBehaviour
    {
        [SerializeField] private VPVehicleController vehicleController;
        [SerializeField] private DistanceChecker distanceChecker; 
        [SerializeField] private float velocity;
        [SerializeField] private int engineRotations;
        [SerializeField] private int engineStatus;
        [SerializeField] private int activeGearPositon;
        [SerializeField] private Gearbox.Type transmissionOperatingMode;
        [SerializeField] private float distanceToTheCar;
        
        private const float UPSTOKMPHMODIFIER = 3.6f;

        public float Velocity => velocity;
        public int EngineRotations => engineRotations;
        public int EngineStatus => engineStatus;
        public int ActiveGearPositon => activeGearPositon;
        public Gearbox.Type TransmissionOperatingMode => transmissionOperatingMode;
        public float DistanceToTheCar => distanceToTheCar;

        private void Update()
        {
            velocity = UPSToKmPH(Mathf.Abs(vehicleController.speed));
            engineRotations = (int)(vehicleController.data.Get(Channel.Vehicle, VehicleData.EngineRpm) / 1000f);
            engineStatus = vehicleController.data.Get(Channel.Vehicle, VehicleData.EngineWorking);
            activeGearPositon = vehicleController.data.Get(Channel.Vehicle, VehicleData.GearboxGear);
            transmissionOperatingMode = vehicleController.gearbox.type;
            distanceToTheCar = distanceChecker.DistanceToClosestCar;
        }

        //Units per second to kilometers per hour
        private float UPSToKmPH(float unitsPerSecond)
        {
            return unitsPerSecond * UPSTOKMPHMODIFIER;
        }
    }
}
