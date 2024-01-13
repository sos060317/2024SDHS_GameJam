using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

public class SyringeShot : MonoBehaviour
{
    public float speed = 1f;
    public Transform ShotPs;
    public float angle;
    public Vector2 Syringe, mouse;
    Vector3 dir;
    Camera cam;
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
            //// �Ѿ˻����� �÷��̾ ���� �ʴ´�.
            ////var bulletGo = Instantiate(bulletPrefab);

            //// ������ƮǮ ���� ��������
            //var bulletGo = PoolManager.instance.Pool.Get();

            //bulletGo.transform.position = this.ShotPs.position;
            Fire();
        }
    }

    private void Fire()
    {
        GameObject bullet = PoolManager.instance.GetPooledObject();

        if (bullet != null)
        {
            bullet.transform.position = ShotPs.position;
            bullet.GetComponent<Rigidbody2D>().AddForce(dir * speed, ForceMode2D.Impulse);
            bullet.SetActive(true);
        }
    }

    private void SeeMouse()
    {
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        angle = Mathf.Atan2(mouse.y - Syringe.y, mouse.x - Syringe.x) * Mathf.Rad2Deg;
        dir = (mouse - Syringe).normalized; // ���� ���� ��� �߰�
    }
}
