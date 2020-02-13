using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Gameplay.BallMovement;

public class LineItem : PoolingObject
{
    private VerticalLine verticalLine;
    [SerializeField] private MeshRenderer meshRenderer = null;

    private bool spawn = false;

    private float length;
    private int id;

    public void Initialize(VerticalLine verticalLine, BallHorizontalMover ballHorizontalMover, LineItemParametrs parametrs)
    {
        this.verticalLine = verticalLine;
        Initialize(parametrs);
    }

    public void Initialize(LineItemParametrs parametrs)
    {
        meshRenderer.material.color = parametrs.color;
        length = parametrs.length;
        id = parametrs.id;
    }

    private void SetTransformParametrs()
    {
        transform.localScale = new Vector3(2F, length);
        transform.position = new Vector3(transform.position.x, verticalLine.SpawnYPosition - transform.localScale.y / 2);
    }

    private void Update()
    {
        if(!spawn)
            CheckLowerEdge();
        CheckHightEdge();
    }

    private void CheckLowerEdge()
    {
        if(transform.position.y - transform.localScale.y/2 > verticalLine.EndYPosition)
        {
            verticalLine.AddLine();
            spawn = true;
        }
    }

    private void CheckHightEdge()
    {
        if (transform.position.y - transform.localScale.y > verticalLine.StartYPosition)
        {
            verticalLine.ReturnToPool(this);
        }
    }

    public float GetAcceleration()
    {
        if(id == 0)
        {
            return -0.2F;
        }
        if(id == 1)
        {
            return 0.2F;
        }
        return 0;
    }

    public override void ReturnToPool()
    {
        base.ReturnToPool();
        spawn = false;
    }

    public override void GetFromPool()
    {
        base.GetFromPool();
        SetTransformParametrs();
    }
}
