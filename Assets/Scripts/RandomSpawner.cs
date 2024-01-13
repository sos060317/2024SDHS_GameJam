using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;  // ������ ������Ʈ
    public float minSpawnInterval;  // �ּ� ���� ����
    public float maxSpawnInterval;  // �ִ� ���� ����
    public float spawnRangeX;    // ������ ��ġ�� X ����

    void Start()
    {
        // ���� ���� ȣ��
        SpawnObject();
    }

    void SpawnObject()
    {
        // ������ X ��ġ ���
        float spawnPositionX = Random.Range(-spawnRangeX, spawnRangeX);

        // ������Ʈ ����
        Instantiate(objectToSpawn, new Vector3(spawnPositionX, 5, 0), Quaternion.identity);

        // ���� ȣ�� ������ �������� ����
        float nextSpawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
        Invoke("SpawnObject", nextSpawnInterval);
    }

}