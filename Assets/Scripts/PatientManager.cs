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

    private void Start()
    {
        StartCoroutine(SetUpPatient());
    }

    IEnumerator SetUpPatient()
    {
        for(int i = 0; i < maxPatient; i++)
        {
            if (!BedsManager.Instance.bedsCheckers[^1].CheckBedIsFull())
            {
                yield break;
            }

            var patient = Instantiate(patientPrefab, transform.position, Quaternion.identity);

            patient.doorPosition = doorPosition;

            yield return new WaitForSeconds(5.0f);
        }
    }
}
