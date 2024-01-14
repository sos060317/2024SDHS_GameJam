using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    public IObjectPool<GameObject> Pool { get; set; }
    public float speed = 5f;
    Rigidbody2D rb;
    public Vector3 dir;

    private void Start()
    {
        Collider collider = GetComponent<Collider>();
        rb = GetComponent<Rigidbody2D>();
        if (collider != null)
        {
            collider.isTrigger = true;
        }
    }

    void Update()
    {
        //// �Ѿ��� ���� ���󰡸� ���� ���ֱ�
        //if (this.transform.position.y > 5)
        //{
        //    // ���� �ڽ��� Destroy�� ���� �ʴ´�.
        //    //Destroy(this.gameObject);

        //    // ������Ʈ Ǯ�� ��ȯ
        //}

        rb.velocity = dir * speed;


    }

    void OnTriggerEnter2D(Collider2D o)
    {
        if (o.gameObject.tag == ("Wound"))
        {
            Destroy(o.gameObject);
            gameObject.SetActive(false);
            Debug.Log("asdsa");
        }
        else if (o.gameObject.tag == ("Thread"))
        {
            Debug.Log("asdsa");

            Destroy(o.gameObject);
            gameObject.SetActive(false);
        }
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);

    }
}
