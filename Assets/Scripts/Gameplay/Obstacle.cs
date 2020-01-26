using Gameplay.BallMovement;
using UnityEngine;

namespace Gameplay
{
    public class Obstacle : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            var ballMover = other.gameObject.GetComponentInChildren<BallVerticalMover>();
            if (ballMover == null)
                return;
            
            ballMover.DropSpeed();
            
            Destroy(gameObject);
        }
    }
}