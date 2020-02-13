using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Gameplay.BallMovement;

public class VerticalLine : MonoBehaviour
{
    [SerializeField] private int lineIndex;
    [SerializeField] private Transform start = null;
    [SerializeField] private Transform end = null;

    [SerializeField] private LineItem lineItem = null;

    private BallHorizontalMover horizontalMover = null;
    private BallVerticalMover verticalMover = null;

    private LineItemPool objectPool;

    private List<LineItem> lineItems;

    private LineItem currentItem;

    private bool yellowBall;

    public float SpawnYPosition
    {
        get
        {
            if (lineItems.Count == 0)
                return StartYPosition;

            LineItem lineItem = lineItems[lineItems.Count - 1];
            return lineItem.transform.position.y - lineItem.transform.localScale.y / 2;
        }
    }

    public float EndYPosition => end.position.y;

    public float StartYPosition => start.position.y;
    void Start()
    {

        lineItems = new List<LineItem>();
        objectPool = new LineItemPool(this, horizontalMover, lineItem, 10);
        AddLine();
    }

    public void AddLine()
    {
        lineItems.Add(objectPool.GetObject());
        if (currentItem == null)
        {
            currentItem = lineItems[0];
        }
    }

    public void ReturnToPool(LineItem lineItem)
    {
        lineItems.Remove(lineItem);
        objectPool.ReturnObject(lineItem);
        lineItem.Initialize(objectPool.GetNewParametrs());
    }

    private void Update()
    {
        float delta = currentItem.transform.localScale.y / 2;
        if (Mathf.Abs(horizontalMover.transform.position.y - currentItem.transform.position.y) > delta)
            GetCurrentItem();

        AccelerationEffect();
    }

    private void GetCurrentItem()
    {
        int currentId = 0;
        if(currentItem!=null)
            currentId = currentItem.Id;
        currentItem = lineItems.Find(item => item.transform.localScale.y / 2 >= Mathf.Abs(horizontalMover.transform.position.y - item.transform.position.y));
        if (currentId == 2 && currentItem != null && currentItem.Id != 2)
            yellowBall = true;
    }

    public void AccelerationEffect()
    {
        if (horizontalMover.CurrentPositionIndex == lineIndex && currentItem!=null)
        {
            if (yellowBall)
                horizontalMover.MoveToNeighbor();
            else
            verticalMover.SetAcceceleration(currentItem.GetAcceleration());
        }
        yellowBall = false;
    }

    public void SetBallComponent(BallHorizontalMover ballHorizontalMover, BallVerticalMover ballVerticalMover)
    {
        horizontalMover = ballHorizontalMover;
        verticalMover = ballVerticalMover;
    } 

}
