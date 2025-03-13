using UnityEngine;

namespace Testovoe
{
    public interface IMovementController
    {
        void Move(Vector3 direction);
        void UpdateGravity();
    }
}