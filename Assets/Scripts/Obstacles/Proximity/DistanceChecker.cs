using System.Collections.Generic;
using Obstacles.Core;
using UnityEngine;
using UnityEngine.Serialization;

namespace Obstacles.Proximity
{
    [RequireComponent(typeof(Collider))]
    public class DistanceChecker : MonoBehaviour
    {
        [FormerlySerializedAs("checkingVehicle")] [SerializeField] private Obstacle checkingObstacle;

        private float _distanceToClosestCar;

        private readonly List<IObstacle> _vehiclesInZone = new();

        public float DistanceToClosestCar => _distanceToClosestCar;

        private void OnTriggerEnter(Collider other)
        {
            IObstacle newObstacle = other.gameObject.GetComponent<IObstacle>();

            if (newObstacle != null)
            {
                _vehiclesInZone.Add(newObstacle);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            IObstacle obstacle = other.gameObject.GetComponent<IObstacle>();

            if (obstacle != null)
            {
                if (_vehiclesInZone.Contains(obstacle))
                {
                    _vehiclesInZone.Remove(obstacle);
                }
            }
        }

        private void FixedUpdate()
        {
            CalculateDistanceToClosestCar();
        }

        private void CalculateDistanceToClosestCar()
        {
            if (_vehiclesInZone.Count == 0)
            {
                _distanceToClosestCar = -1;
                return;
            }

            IObstacle closestObstacle = null;
            float closestDistance = 9999999;

            foreach (var vehicle in _vehiclesInZone)
            {
                if (vehicle.GetVisible())
                {
                    float closestCollidersDistance =
                        GetDistanceBetweenColliders(checkingObstacle.GetCollider(), vehicle.GetCollider());

                    if (closestCollidersDistance < closestDistance)
                    {
                        closestDistance = closestCollidersDistance;
                        closestObstacle = vehicle;
                    }
                }

                if (closestObstacle != null)
                {
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
            //closest point on player's car collider to obstacle
            Vector3 closestPointB = targetCollider.ClosestPoint(checkerCollider.transform.position);
            //closest point to obstacle's collider
            Vector3 closestPointA = checkerCollider.ClosestPoint(closestPointB);

            //distance between this points
            float closestCollidersDistance = Vector3.Distance(closestPointA, closestPointB);
            return closestCollidersDistance;
        }
    }
}