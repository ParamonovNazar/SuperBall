using System.Collections.Generic;
using DG.Tweening;
using Lean.Touch;
using UnityEngine;
using Zenject;

namespace Gameplay.BallMovement
{
    public class BallHorizontalMover : MonoBehaviour
    {
        private List<float> _defaultPosition;
        private int _curPositionIndex = 1;

        public int CurrentPositionIndex { get { return _curPositionIndex; } } 

        [Inject]
        private void Constructor(VerticalsSystem verticalsSystem)
        {
            _defaultPosition = verticalsSystem.GetVerticalCentres();
        }

        private void Awake()
        {
            LeanTouch.OnFingerSwipe += OnFingerSwipe;
        }

        private void OnFingerSwipe(LeanFinger finger)
        {
            var newPosition = IsSwipeToRight(finger) ? _curPositionIndex + 1 : _curPositionIndex - 1;
            MoveTo(newPosition);
        }

        private void MoveTo(int newPositionIndex)
        {
            if (newPositionIndex >= _defaultPosition.Count)
                newPositionIndex = 0;

            if (newPositionIndex < 0)
                newPositionIndex = _defaultPosition.Count - 1;

            _curPositionIndex = newPositionIndex;
        
            var position = transform.position;
            var newPosition = new Vector3(_defaultPosition[_curPositionIndex], position.y, position.z);
            SmoothMove(newPosition);
        }

        private void SmoothMove(Vector3 targetPosition)
        {
            transform.DOMoveX(targetPosition.x,0.3f).SetEase(Ease.InOutQuad);
        }

        private bool IsSwipeToRight(LeanFinger finger)
        {
            return finger.SwipeScreenDelta.x > 0;
        }
    
        private void OnDestroy()
        {
            LeanTouch.OnFingerSwipe -= OnFingerSwipe;
        }

        public void MoveToNeighbor()
        {
            int newPositionIndex = Random.Range(0, 2) == 0 ? -1 : 1;
            MoveTo(_curPositionIndex + newPositionIndex);
        }
    }
}