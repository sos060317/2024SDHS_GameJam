using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour
{
    [HideInInspector] public bool isFull = false;

    private void EnterPatient(Collider2D Patient)
    {
        if(Patient.CompareTag("Patient"))
        {
            isFull = true;
        }
    }

    private void ExitPatient(Collider2D Patient)
    {
        if (Patient.CompareTag("Patient"))
        {
            isFull = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnterPatient(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ExitPatient(collision);
    }
}
