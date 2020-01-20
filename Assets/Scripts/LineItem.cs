using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LineItem : MonoBehaviour
{
    private VerticalLine verticalLine;
    [SerializeField] private MeshRenderer meshRenderer = null;

    private bool spawn = false;

    public void Initialize(VerticalLine verticalLine, LineItemParametrs parametrs)
    {
        this.verticalLine = verticalLine;
        transform.localScale = new Vector3(2F, parametrs.length);
        transform.position = new Vector3(transform.position.x, verticalLine.SpawnYPosition - transform.localScale.y / 2);
        meshRenderer.material.color = parametrs.color;
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
            Destroy(gameObject);
        }
    }
}
