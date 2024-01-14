using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedsManager : MonoBehaviour
{
    [SerializeField] private BedsChecker[] bedsCheckers;

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

    private BedsChecker CheckFloorPoint()
    {
        for(int i = 0; i < bedsCheckers.Length; i++)
        {
            if (!bedsCheckers[i].isEmptyBed)
                continue;

            return bedsCheckers[i];
        }

        return null;
    }
}
