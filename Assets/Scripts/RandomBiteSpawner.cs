using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class RandomBiteSpawner : MonoBehaviour
{
    public GameObject knife;
    public GameObject bandage;

    public float minX = -5f;   // 최소 x 값
    public float maxX = 5f;    // 최대 x 값
    public float minTime;
    public float maxTime;
    public float retuneTime;
    public int MaxTime;
    public int MinTime;

    public GameObject Spawnpoint;
    private void OnEnable()
    {
        
    }

    void Start()
    {
        MiniGameManager.instance.BanditCount = Random.Range(MinTime, MaxTime);
        SpawnObject();
    }

    void Update()
    {
        
    }

    void SpawnObject()
    {
        // 프리팹 배열을 만들고 랜덤하게 선택
        GameObject[] Objcets = { knife, bandage };
        GameObject selectedObjcet = Objcets[Random.Range(0, Objcets.Length)];
        retuneTime = Random.Range(minTime, maxTime);
        // 랜덤한 위치에 오브젝트 생성
        Instantiate(selectedObjcet, Spawnpoint.transform.position , Quaternion.identity);

        if (MiniGameManager.instance.BanditCount > 0) Invoke("SpawnObject", retuneTime);
    }

}
