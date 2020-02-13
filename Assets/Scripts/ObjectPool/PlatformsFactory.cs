using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay.BallMovement;

public class PlatformsFactory : Factory<LineItem>
{
    private VerticalLine parent;
    private LineItem prefab;
    private BallHorizontalMover horizontalMover;

    public PlatformsFactory(VerticalLine parent, BallHorizontalMover horizontalMover, LineItem prefab)
    {
        this.parent = parent;
        this.prefab = prefab;
        this.horizontalMover = horizontalMover;
    }

    public override LineItem CreateItem()
    {
        LineItem lineItem = GameObject.Instantiate(prefab, parent.transform);
        lineItem.Initialize(parent, horizontalMover, GetRandomParametrs());
        return lineItem;
    }

    public LineItemParametrs GetRandomParametrs()
    {
        float lenght = Random.Range(4F, 8F);
        int colorId = Random.Range(0, 4);
        LineItemParametrs lineItem = new LineItemParametrs(lenght, colorId);

        return lineItem;
    }

}
