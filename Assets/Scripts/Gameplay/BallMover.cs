using System.Collections.Generic;
using DG.Tweening;
using Lean.Touch;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class BallMover : MonoBehaviour
    {
        private List<float> _defaultPosition;
        private int curPositionIndex = 1;

        [Inject]
        private void Constructor(List<float> verticalsPositions)
        {
            _defaultPosition = verticalsPositions;
        }

        private void Awake()
        {
            LeanTouch.OnFingerSwipe += OnFingerSwipe;
        }

        private void OnFingerSwipe(LeanFinger finger)
        {
            var newPosition = IsSwipeToRight(finger) ? curPositionIndex + 1 : curPositionIndex - 1;
            MoveTo(newPosition);
        }

        private void MoveTo(int newPositionIndex)
        {
            if (newPositionIndex >= _defaultPosition.Count)
                newPositionIndex = 0;

            if (newPositionIndex < 0)
                newPositionIndex = _defaultPosition.Count - 1;

            curPositionIndex = newPositionIndex;
        
            var position = transform.position;
            var newPosition = new Vector3(_defaultPosition[curPositionIndex], position.y, position.z);
            SmoothMove(newPosition);
        }

        private void SmoothMove(Vector3 targetPosition)
        {
            transform.DOMove(targetPosition,0.3f).SetEase(Ease.InOutQuad);
        }

        private bool IsSwipeToRight(LeanFinger finger)
        {
            return finger.SwipeScreenDelta.x > 0;
        }
    
        private void OnDestroy()
        {
            LeanTouch.OnFingerSwipe -= OnFingerSwipe;
        }
    }
}