using UnityEngine;

namespace Gameplay.BallMovement
{
    public class BallVerticalMover : MonoBehaviour
    {
        [SerializeField] private float _maxSpeed = 3f;
        [SerializeField] private float _currentSpeed = 0f;
        [SerializeField] private float _acceleration = 1f;
        
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
    }
}