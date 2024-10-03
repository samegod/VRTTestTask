using UnityEngine;

namespace Obstacles.Core
{
    public class Obstacle : MonoBehaviour, IObstacle
    {
        [SerializeField] private Renderer mainRenderer;
        [SerializeField] private Collider mainCollider;
        
        public bool GetVisible() => mainRenderer.isVisible;
        public Collider GetCollider() => mainCollider;

        public Transform GetTransform() => transform;
    }
}
