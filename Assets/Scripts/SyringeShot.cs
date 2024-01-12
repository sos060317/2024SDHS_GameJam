using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SyringeShot : MonoBehaviour
{
    public float speed = 1f;
    public Transform ShotPs;
    public float angle;
    public Vector2 Syringe, mouse;
    Quaternion rot;

    private void Start()
    {
        Syringe = transform.position;
    }

    void Update()
    {
        SeeMouse();
        this.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);


        if (Input.GetMouseButtonDown(0))
        {
            // �Ѿ˻����� �÷��̾ ���� �ʴ´�.
            //var bulletGo = Instantiate(bulletPrefab);

            // ������ƮǮ ���� ��������
            var bulletGo = PoolManager.instance.Pool.Get();

            bulletGo.transform.position = this.ShotPs.position;
        }
    }



        private void SeeMouse()
        {
            mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            angle = Mathf.Atan2(mouse.y - Syringe.y, mouse.x - Syringe.x) * Mathf.Rad2Deg;
            //Quaternion rot = Quaternion.Euler(0, 0, angle);

            //return rot;
        }
    }
