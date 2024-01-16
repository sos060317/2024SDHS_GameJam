using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedsManager : MonoBehaviour
{
    public BedsChecker[] bedsCheckers;

    private static BedsManager instance = null;

    public static BedsManager Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }

            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public BedsChecker CheckFloorPoint()
    {
        for (int i = 0; i < bedsCheckers.Length; i++)
        {
            if (!bedsCheckers[i].CheckBedIsFull())
            {
                continue;
            }

            return bedsCheckers[i];
        }

        return null;
    }

    //public Vector2 CheckFloorPoint()
    //{
    //    for(int i = 0; i < bedsCheckers.Length; i++)
    //    {
    //        if (!bedsCheckers[i].CheckBedIsFull())
    //        {
    //            continue;
    //        }

    //        return bedsCheckers[i].transform.position;
    //    }

    //    return Vector2.zero;
    //}
}
