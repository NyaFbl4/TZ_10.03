using UnityEngine;

namespace Testovoe
{
    public class CameraController : MonoBehaviour
    {
        private float _xMove;
        private float _yMove;
        private float _xRotation;

        [SerializeField] private Transform _playerBody;

        [SerializeField] private float _maxX;
        [SerializeField] private float _minX;
        
        private Vector2 _lockAxis;
        public Vector2 LockAxis
        {
            get => _lockAxis;
            set => _lockAxis = value;
        }

        private void Update()
        {
            _xMove = _lockAxis.x;
            _yMove = _lockAxis.y;
            _xRotation -= _yMove;
            _xRotation = Mathf.Clamp(_xRotation, _minX, _maxX);

            transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);
            _playerBody.Rotate(Vector3.up * _xMove);
        }
    }
}