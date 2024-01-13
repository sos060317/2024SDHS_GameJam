using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    public IObjectPool<GameObject> Pool { get; set; }
    public float speed = 5f;

    void Update()
    {
        //// 총알이 많이 날라가면 삭제 해주기
        //if (this.transform.position.y > 5)
        //{
        //    // 이제 자신이 Destroy를 하지 않는다.
        //    //Destroy(this.gameObject);

        //    // 오브젝트 풀에 반환
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
