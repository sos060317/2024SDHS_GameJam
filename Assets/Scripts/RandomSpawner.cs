using UnityEngine;
using UnityEngine.AI;

public class RandomSpawner : MonoBehaviour
{
    public GameObject Thread; // 첫 번째 프리팹
    public GameObject Wound; // 두 번째 프리팹

    //이거 변수 값좀 내가 바꿔다 - 우지원
    public float minX = -108f;    // 최소 x 값
    public float maxX = -92f;    // 최대 x 값
    public float minTime;
    public float maxTime;
    public float retuneTime;

    private void OnEnable()
    {
    }

    void Start()
    {
        //이것도 내가 OnEnable에 있던거 위치 바꿨어 이유 궁금하면 내일 물어봐 - 우지원
        MiniGameManager.instance.ThreadCount = Random.Range(5, 10);
        SpawnObject();
    }

    void SpawnObject()
    {
        // 프리팹 배열을 만들고 랜덤하게 선택
        GameObject[] Objcets = { Thread, Wound , Wound};
        GameObject selectedObjcet = Objcets[Random.Range(0, Objcets.Length)];
        retuneTime = Random.Range(minTime, maxTime);

        // 랜덤한 x, y, z 좌표 생성
        float randomX = Random.Range(minX, maxX);


        // 랜덤한 위치에 오브젝트 생성
        Vector3 spawnPosition = new Vector2(randomX, 8);
        Instantiate(selectedObjcet, spawnPosition, Quaternion.identity);

        if(MiniGameManager.instance.ThreadCount > 0) Invoke("SpawnObject", retuneTime);
    }
}