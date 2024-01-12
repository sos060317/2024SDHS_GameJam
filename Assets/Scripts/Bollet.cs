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
        

        this.transform.Translate(Vector3.up * this.speed * Time.deltaTime);
    }
    private void OnBecameInvisible()
    {
        Pool.Release(this.gameObject);
    }
}
