using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    public IObjectPool<GameObject> Pool { get; set; }
    public float speed = 5f;

    void Update()
    {
        //// �Ѿ��� ���� ���󰡸� ���� ���ֱ�
        //if (this.transform.position.y > 5)
        //{
        //    // ���� �ڽ��� Destroy�� ���� �ʴ´�.
        //    //Destroy(this.gameObject);

        //    // ������Ʈ Ǯ�� ��ȯ
        //}
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
