using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class StateMedicine : MonoBehaviour
{
    public bool Md;
    public bool As;
    public bool Fz;
    public int WhatState;
    public int thisMedicineState;
    public GameObject effect;
    public GameObject healeffect;
    
    void Start()
    {
        WhatState = MiniGameManager.instance.stateMedicine;
        if (Md)
        {
            thisMedicineState = 1;
        }
        else if (As)
        {
            thisMedicineState = 2;
        }
        else if(Fz)
        {
            thisMedicineState = 3;
        }
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == ("Player"))
        {
            if(thisMedicineState == WhatState)
            {
                MiniGameManager.instance.MedicineCount--;
                Instantiate(healeffect, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
            else
            {
                MiniGameManager.instance.isStun = true;
                Instantiate(effect,transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
        else if(other.gameObject.tag == ("PlayerRange"))
        {
            if (thisMedicineState == WhatState)
            {
                MiniGameManager.instance.isStun = true;
            }
            else
            {
                Instantiate(effect, transform.position, Quaternion.identity);
                Destroy(this.gameObject);   
            }
        }
    }
}
