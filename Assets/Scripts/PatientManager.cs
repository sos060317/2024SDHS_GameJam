using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientManager : MonoBehaviour
{
    [SerializeField] private int maxPatient;

    [SerializeField] GameObject patientPrefab;

    private List<GameObject> patients = new List<GameObject>();

    private void Start()
    {
        SetUpPatient();
    }

    private void SetUpPatient()
    {
        for(int i = 0; i < maxPatient; i++)
        {
            patients.Add(patientPrefab);
            Instantiate(patients[patients.Count - 1].gameObject, transform.position, Quaternion.identity);
        }
    }
}
