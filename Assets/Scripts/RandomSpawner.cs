using UnityEngine;
using UnityEngine.AI;

public class RandomSpawner : MonoBehaviour
{
    public GameObject Thread; // ù ��° ������
    public GameObject Wound; // �� ��° ������

    //�̰� ���� ���� ���� �ٲ�� - ������
    public float minX = -108f;    // �ּ� x ��
    public float maxX = -92f;    // �ִ� x ��
    public float minTime;
    public float maxTime;
    public float retuneTime;

    private void OnEnable()
    {
        //Debug.Log("dadf" + MiniGameManager.instance.ThreadCount);
        MiniGameManager.instance.ThreadCount = Random.Range(5, 10);
        SpawnObject();
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