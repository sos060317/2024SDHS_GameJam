using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour
{
    [HideInInspector] public bool isFull = false;

    private void TouchPatient(Collider2D Patient)
    {
        if(Patient.CompareTag("Patient"))
        {
            isFull = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TouchPatient(collision);
    }
}
