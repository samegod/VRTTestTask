using UnityEngine;

namespace Vehicles.Core
{
    public class Vehicle : MonoBehaviour, IVehicle
    {
        [SerializeField] private Renderer mainRenderer;
        [SerializeField] private Collider mainCollider;
        
        public bool GetVisible() => mainRenderer.isVisible;
        public Collider GetCollider() => mainCollider;

        public Transform GetTransform() => transform;
    }
}
