using UnityEngine;

namespace Vehicles.Core
{
    public interface IVehicle
    {
        bool GetVisible();
        Collider GetCollider();
        Transform GetTransform();
    }
}