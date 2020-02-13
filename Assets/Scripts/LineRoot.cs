using Gameplay.BallMovement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LineRoot : MonoBehaviour
{
    [SerializeField] private List<VerticalLine> verticalLines = null;

    [Inject] private BallHorizontalMover horizontalMover;
    [Inject] private BallVerticalMover verticalMover;

    private void Start()
    {
        for (int i = 0; i < verticalLines.Count; i++)
            verticalLines[i].SetBallComponent(horizontalMover, verticalMover);
    }
}
