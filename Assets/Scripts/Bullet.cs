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
        rb = GetComponent<Rigidbody2D>();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("virus") || collision.gameObject.CompareTag("vaccine"))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
