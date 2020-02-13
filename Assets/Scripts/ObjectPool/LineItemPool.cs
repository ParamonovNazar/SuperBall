using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay.BallMovement;

public class LineItemPool : ObjectPool<LineItem>
{
    public LineItemPool(VerticalLine parent, BallHorizontalMover horizontalMover, LineItem prefab, int count)
    {
        factory = new PlatformsFactory(parent, horizontalMover, prefab);
        Initialize(count);
    }

    public LineItemParametrs GetNewParametrs()
    {
        return (factory as PlatformsFactory).GetRandomParametrs();
    }
}
