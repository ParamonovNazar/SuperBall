using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingObject : MonoBehaviour
{
    public virtual void ReturnToPool()
    {
        gameObject.SetActive(false);
    }

    public virtual void GetFromPool()
    {
        gameObject.SetActive(true);
    }
}
