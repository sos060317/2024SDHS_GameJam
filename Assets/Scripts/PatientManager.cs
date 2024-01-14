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
        StartCoroutine(AddPatient());
    }

    IEnumerator AddPatient()
    {
        while (true)
        {
            if(maxPatient >= patients.Count)
            {
                patients.Add(patientPrefab);
                Instantiate(patients[patients.Count -1].gameObject, transform.position, Quaternion.identity);
                Debug.Log(patients.Count);
            }
            
        }
        //yield return null;
    }
}
