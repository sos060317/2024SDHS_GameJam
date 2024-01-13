using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealShot : MonoBehaviour
{
    public GameObject bulletPos;
    public GameObject preFabBullet;
    float bulletSpeed = 5;
    Vector3 dir;
    Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        
    }
    void Shoot()
    {
        if(Input.GetMouseButton(0))
        {
            GameObject bullet = Instantiate(preFabBullet);
            bullet.transform.position = bullet.transform.position;
            bullet.gameObject.GetComponent<Rigidbody2D>().AddForce(dir * bulletSpeed,ForceMode2D.Impulse);
        }
    }
}
