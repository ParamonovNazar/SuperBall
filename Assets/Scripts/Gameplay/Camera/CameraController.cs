using UnityEngine;

namespace Gameplay.Camera
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private float _yOffset;
        private Transform _target;

        public Transform Target
        {
            get => _target;
            set => _target = value;
        }

        private void LateUpdate()
        {
            var curPosition = transform.position;
            transform.position = new Vector3(curPosition.x, _target.position.y + _yOffset, curPosition.z);
        }
    }
}