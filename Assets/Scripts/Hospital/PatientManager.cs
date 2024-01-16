using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PatientManager : MonoBehaviour
{
    [SerializeField] private int maxPatient;
    [SerializeField] private Patient patientPrefab;
    [SerializeField] private Transform doorPosition;

    [SerializeField] private float maxSpawnTime;
    [SerializeField] private float currentSpawnTime;

    private void Start()
    {
        currentSpawnTime = maxSpawnTime;
    }

    private void Update()
    {
        CheckEmptyBed();
    }

    private void CheckEmptyBed()
    {
        currentSpawnTime += Time.deltaTime;

        if (maxSpawnTime > currentSpawnTime)
            return;

        currentSpawnTime = 0;

        if (BedsManager.Instance.CheckFloorPoint() == null)
            return;

        SetUpPatient();
    }

    private void SetUpPatient()
    {
        if (BedsManager.Instance.bedsCheckers[2].CheckBedIsFull())
        {
            var patient = Instantiate(patientPrefab, transform.position, Quaternion.identity);

            patient.doorPosition = doorPosition;
        }
        else if (BedsManager.Instance.bedsCheckers[1].CheckBedIsFull())
        {
            var patient = Instantiate(patientPrefab, transform.position, Quaternion.identity);

            patient.doorPosition = doorPosition;
        }
        else if (BedsManager.Instance.bedsCheckers[0].CheckBedIsFull())
        {
            var patient = Instantiate(patientPrefab, transform.position, Quaternion.identity);

            patient.doorPosition = doorPosition;
        }

        //if (!BedsManager.Instance.bedsCheckers[2].CheckBedIsFull())
        //{
        //    return;
        //}
        //var patient = Instantiate(patientPrefab, transform.position, Quaternion.identity);

        //patient.doorPosition = doorPosition;
    }

    //IEnumerator SetUpPatient()
    //{
    //    for(int i = 0; i < maxPatient; i++)
    //    {
    //        if (!BedsManager.Instance.bedsCheckers[^1].CheckBedIsFull())
    //        {
    //            yield break;
    //        }

    //        var patient = Instantiate(patientPrefab, transform.position, Quaternion.identity);

    //        patient.doorPosition = doorPosition;

    //        yield return new WaitForSeconds(5.0f);
    //    }
    //}
}
