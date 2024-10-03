using UnityEngine;

namespace Obstacles.Core
{
    public interface IObstacle
    {
        bool GetVisible();
        Collider GetCollider();
        Transform GetTransform();
    }
}