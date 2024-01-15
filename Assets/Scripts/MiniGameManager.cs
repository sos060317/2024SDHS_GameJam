using System.Collections;
using System.Collections.Generic;
using UnityEditor.Purchasing;
using UnityEngine;
using UnityEngine.Pool;

public class MiniGameManager : MonoBehaviour
{
    public static MiniGameManager instance;

    public IObjectPool<GameObject> Pool { get; private set; }

    private List<GameObject> pooledObjects = new List<GameObject>();
    private int amountToPool = 20;

    public bool isStun = false;
    public float StunTime;

    public int ThreadCount;
    public int MaxThreadCount;
    public int MinThreadCount;
    public int stateMedicine;
    public int MedicineCount = 3;

    
    [SerializeField] private GameObject bulletPrefab;

    private void Awake()
    {

        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    void Start()
    {
        ThreadCount = Random.Range(MinThreadCount, MaxThreadCount);
        stateMedicine = Random.Range(1, 3);

        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(bulletPrefab);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼 클릭 감지
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
        }
        if(ThreadCount <= 0)
        {
            ThreadCount = 0;
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        return null;
    }
    
}
