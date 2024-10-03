using System.Collections.Generic;
using UnityEngine;
using Vehicles.Core;

namespace Vehicles.Proximity
{
    [RequireComponent(typeof(Collider))]
    public class DistanceChecker : MonoBehaviour
    {
        [SerializeField] private Vehicle checkingVehicle;

        private float _distanceToClosestCar;

        private readonly List<IVehicle> _vehiclesInZone = new();

        public float DistanceToClosestCar => _distanceToClosestCar;

        private void OnTriggerEnter(Collider other)
        {
            IVehicle newVehicle = other.gameObject.GetComponent<IVehicle>();

            if (newVehicle != null)
            {
                _vehiclesInZone.Add(newVehicle);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            IVehicle vehicle = other.gameObject.GetComponent<IVehicle>();

            if (vehicle != null)
            {
                if (_vehiclesInZone.Contains(vehicle))
                {
                    _vehiclesInZone.Remove(vehicle);
                }
            }
        }

        private void FixedUpdate()
        {
            if (_vehiclesInZone.Count == 0)
            {
                _distanceToClosestCar = -1;
                return;
            }

            IVehicle closestVehicle = null;
            float closestDistance = 9999999;

            foreach (var vehicle in _vehiclesInZone)
            {
                if (vehicle.GetVisible())
                {
                    float closestCollidersDistance =
                        GetDistanceBetweenColliders(checkingVehicle.GetCollider(), vehicle.GetCollider());

                    if (closestCollidersDistance < closestDistance)
                    {
                        closestDistance = closestCollidersDistance;
                        closestVehicle = vehicle;
                    }
                }

                if (closestVehicle != null)
                {
                    Debug.Log("Distance " + closestDistance);
                    _distanceToClosestCar = closestDistance;
                }
                else
                {
                    _distanceToClosestCar = -1;
                }
            }
        }

        private float GetDistanceBetweenColliders(Collider checkerCollider, Collider targetCollider)
        {
            Physics.ComputePenetration(
                checkerCollider, checkerCollider.transform.position, checkerCollider.transform.rotation,
                targetCollider, targetCollider.transform.position, targetCollider.transform.rotation,
                out _, out _
            );
                    
            Vector3 closestPointB = targetCollider.ClosestPoint(checkerCollider.transform.position);
            Vector3 closestPointA = checkerCollider.ClosestPoint(closestPointB);

            float closestCollidersDistance = Vector3.Distance(closestPointA, closestPointB);
            return closestCollidersDistance;
        }
    }
}