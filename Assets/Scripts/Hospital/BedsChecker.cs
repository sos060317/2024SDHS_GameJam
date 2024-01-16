using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedsChecker : MonoBehaviour
{
    public Bed[] beds;

    private List<Bed> isEmptyList = new List<Bed>();

    private bool isEmptyBed = false;

    private void Start()
    {
        CheckBedIsFull();
    }

    public bool CheckBedIsFull()
    {
        if (!beds[0].isFull)
        {
            isEmptyList.Add(beds[0]);

            isEmptyBed = true;

            return isEmptyBed;
        }

        if (!beds[1].isFull)
        {
            isEmptyList.Add(beds[1]);

            isEmptyBed = true;

            return isEmptyBed;
        }

        return false;
    }
}
