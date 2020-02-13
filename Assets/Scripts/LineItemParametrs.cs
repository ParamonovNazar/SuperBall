using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct LineItemParametrs
{
    public float length;
    public Color color;
    public int id;
    

    public LineItemParametrs(float length, int id)
    {
        color = GetColorById(id);
        this.length = length;
        this.id = id;
    }

    private static Color GetColorById(int id)
    {
        switch(id)
        {
            case 1:
                return Color.red;
            case 2:
                return Color.green;
            case 3:
                return Color.yellow;
            default:
                return Color.blue;
        }
    }
}