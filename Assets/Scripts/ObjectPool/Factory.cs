using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Factory<T> where T : PoolingObject
{
    public List<T> GetItems(int count)
    {
        List<T> lineItems = new List<T>();
        for (int i = 0; i < count; i++)
        {
            lineItems.Add(CreateItem());
        }

        return lineItems;
    }

    public abstract T CreateItem();

}
