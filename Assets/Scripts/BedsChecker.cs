using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedsChecker : MonoBehaviour
{
    [SerializeField] private Bed[] beds;

    private List<Bed> isEmptyList = new List<Bed>();

    [HideInInspector] public bool isEmptyBed;

    private void Start()
    {
        CheckBedIsFull();
        Debug.Log(isEmptyList.Count);
    }

    private List<Bed> CheckBedIsFull()
    {
        if (!beds[0].isFull)
        {
            isEmptyList.Add(beds[0]);

            isEmptyBed = true;

            return isEmptyList;
        }

        if (!beds[1].isFull)
        {
            isEmptyList.Add(beds[1]);

            isEmptyBed = true;

            return isEmptyList;
        }

        return isEmptyList;
    }
}
