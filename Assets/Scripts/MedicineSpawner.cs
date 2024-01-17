using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private GameObject Pfizer;
    [SerializeField] private GameObject Astrozeneca;
    [SerializeField] private GameObject Moderna;

    private int index;
    private int prefabIndex;
    private bool spawnPointnotnull = false;
    private int count = 1;
    List<int> SpawnPointList = new List<int>();
    [SerializeField] GameObject[] SpawnPoint;
    private Transform SpPoint;

    private void OnEnable()
    {
        //MiniGameManager.instance.ThreadCount = Random.Range(MiniGameManager.instance.MinThreadCount, MiniGameManager.instance.MaxThreadCount);
        MiniGameManager.stateMedicine = Random.Range(1, 3);
        AddOnjectSppoint();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void AddOnjectSppoint()
    {
        
        int currentIndex = Random.Range(0, 8);
        int MedicineCount = 0;

        for (int i = 0; i <= 8;)
        {
            if (SpawnPointList.Contains(currentIndex))
            {
                currentIndex = Random.Range(0, 9);
                
            }
            else
            {
                
                SpawnPointList.Add(currentIndex);
                
                i++;
                SpPoint = SpawnPoint[currentIndex].transform;
                if (MedicineCount < 3)
                {
                    Instantiate(Pfizer, SpawnPoint[currentIndex].transform.position, Quaternion.identity);
                }
                else if (MedicineCount < 6)
                {
                    Instantiate(Astrozeneca, SpawnPoint[currentIndex].transform.position, Quaternion.identity);
                }
                else if (MedicineCount < 8)
                {
                    Instantiate(Moderna, SpawnPoint[currentIndex].transform.position, Quaternion.identity);
                }
                else if (MedicineCount < 9)
                {
                    Instantiate(Moderna, SpawnPoint[currentIndex].transform.position, Quaternion.identity);
                    return;
                }
                MedicineCount++;

            }
        }
    }
}
