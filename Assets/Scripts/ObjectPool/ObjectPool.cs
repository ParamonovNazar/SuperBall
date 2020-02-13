using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool<T> where T : PoolingObject
{
    protected List<T> objects;
    public List<T> Objects => objects;
    protected Factory<T> factory;

    protected void Initialize(int count)
    {
        objects = factory.GetItems(count);
    }

    public virtual T GetObject()
    {
        if(objects.Count == 0)
        {
            objects.Add(factory.CreateItem());
        }

        T obj = objects[0];
        objects.RemoveAt(0);
        obj.GetFromPool();
        return obj;
    }

    public void ReturnObject(T obj)
    {
        objects.Add(obj);
        obj.ReturnToPool();
    }
}
