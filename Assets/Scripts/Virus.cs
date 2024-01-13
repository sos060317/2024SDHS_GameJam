using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : MonoBehaviour
{
    public float GravitySc;
    public float MaxGravitySc;
    public float MinGravitySc;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        GravitySc = Random.Range(MinGravitySc, MaxGravitySc);
    }
    void Start()
    {
        rb.gravityScale = GravitySc;
    }

    
    void Update()
    {
        
    }
}
