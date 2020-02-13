using System;
using Gameplay.BallMovement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LineRoot : MonoBehaviour
{
    [SerializeField] private List<VerticalLine> verticalLines = null;

    private BallHorizontalMover horizontalMover;
    private BallVerticalMover verticalMover;

    [Inject]
    private void Constructor(BallHorizontalMover horizontalMover, BallVerticalMover verticalMover)
    {
        this.horizontalMover = horizontalMover;
        this.verticalMover = verticalMover;
    }

    private void Start()
    {
        for (int i = 0; i < verticalLines.Count; i++)
            verticalLines[i].SetBallComponent(horizontalMover, verticalMover);
    }
}