using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class VerticalLine : MonoBehaviour
{
    [SerializeField] private Transform start = null;
    [SerializeField] private Transform end = null;

    [SerializeField] private LineItem lineItem = null;

    public float SpawnYPosition
    {
        get
        {
            if (lineItems.Count == 0)
                return start.position.y;

            LineItem lineItem = lineItems.Dequeue();
            return lineItem.transform.position.y - lineItem.transform.localScale.y/2;
        }
    }

    public float EndYPosition
    {
        get
        {
            return end.position.y;
        }
    }
    public float StartYPosition
    {
        get
        {
            return start.position.y;
        }
    }

    private Queue<LineItem> lineItems;
    void Start()
    {
        lineItems = new Queue<LineItem>();
        AddLine();
    }

    public void AddLine()
    {
        LineItem lineItem = Instantiate(this.lineItem, transform);
        lineItem.Initialize(this, new LineItemParametrs(Random.Range(2F, 4F), Random.Range(1,5)));
        lineItems.Enqueue(lineItem);
    }

}
