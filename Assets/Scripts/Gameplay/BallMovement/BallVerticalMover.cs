using UnityEngine;

namespace Gameplay.BallMovement
{
    public class BallVerticalMover : MonoBehaviour
    {
        [SerializeField] private float _maxSpeed = 3f;
        [SerializeField] private float _currentSpeed = 0f;
        [SerializeField] private float _defaultAcceleration = 1f;

        private float _acceleration;

        private void Start()
        {
            _acceleration = _defaultAcceleration;
        }

        private void Update()
        {
            var curPosition = transform.position;
            _currentSpeed = Mathf.Clamp(_currentSpeed + Time.deltaTime * _acceleration, _currentSpeed, _maxSpeed);
            transform.position = curPosition + _currentSpeed * Time.deltaTime * Vector3.down;
        }

        public void DropSpeed()
        {
            _currentSpeed = 0.5f;
        }

        public void SetAcceceleration(float value)
        {
            _acceleration = _defaultAcceleration + value;
        }
    }
}