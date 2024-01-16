using UnityEngine;
using UnityEngine.AI;

public class RandomSpawner : MonoBehaviour
{
    public GameObject Thread; // ù ��° ������
    public GameObject Wound; // �� ��° ������

    public float minX = -5f;   // �ּ� x ��
    public float maxX = 5f;    // �ִ� x ��
    public float minTime;
    public float maxTime;
    public float retuneTime;

    private void OnEnable()
    {
        MiniGameManager.instance.ThreadCount = Random.Range(5, 10);
        SpawnObject();
    }

    void Start()
    {
       
    }

    void SpawnObject()
    {
        // ������ �迭�� ����� �����ϰ� ����
        GameObject[] Objcets = { Thread, Wound , Wound};
        GameObject selectedObjcet = Objcets[Random.Range(0, Objcets.Length)];
        retuneTime = Random.Range(minTime, maxTime);

        // ������ x, y, z ��ǥ ����
        float randomX = Random.Range(minX, maxX);


        // ������ ��ġ�� ������Ʈ ����
        Vector3 spawnPosition = new Vector2(randomX, 8);
        Instantiate(selectedObjcet, spawnPosition, Quaternion.identity);

        if(MiniGameManager.instance.ThreadCount > 0) Invoke("SpawnObject", retuneTime);
    }
}