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
    public int BanditCount;
    public int MaxThreadCount;
    public int MinThreadCount;
    public static int stateMedicine;
    public int MedicineCount = 3;

    
    [SerializeField] private GameObject bulletPrefab;

    public GameObject[] miniGames;
    public static int miniGamesNumber;

    private void Awake()
    {

        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    void Start()
    {
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
        if (Input.GetMouseButtonDown(0)) // ���콺 ���� ��ư Ŭ�� ����
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
        }
        if(ThreadCount <= 0)
        {
            ThreadCount = 0;
        }
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
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

    public IEnumerator ReturnCamera(Camera camera)
    {
        yield return new WaitForSeconds(2.5f);

        StartCoroutine(GameManager.Instance.FadeINOUT(0));

        miniGames[miniGamesNumber].gameObject.SetActive(false);
        camera.transform.position = new Vector3(0, 0, -10);

        yield break;
    }
}
