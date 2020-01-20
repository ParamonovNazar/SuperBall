using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct LineItemParametrs
{
    public float length;
    public Color color;
    

    public LineItemParametrs(float length, int id)
    {
        color = GetColorById(id);
        this.length = length;
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
                return Color.blue;
            default:
                return Color.yellow;
        }
    }
}
