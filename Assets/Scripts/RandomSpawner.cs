using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;  // 생성할 오브젝트
    public float minSpawnInterval;  // 최소 생성 간격
    public float maxSpawnInterval;  // 최대 생성 간격
    public float spawnRangeX;    // 생성할 위치의 X 범위

    void Start()
    {
        // 최초 스폰 호출
        SpawnObject();
    }

    void SpawnObject()
    {
        // 랜덤한 X 위치 계산
        float spawnPositionX = Random.Range(-spawnRangeX, spawnRangeX);

        // 오브젝트 생성
        Instantiate(objectToSpawn, new Vector3(spawnPositionX, 5, 0), Quaternion.identity);

        // 다음 호출 간격을 랜덤으로 설정
        float nextSpawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
        Invoke("SpawnObject", nextSpawnInterval);
    }

}