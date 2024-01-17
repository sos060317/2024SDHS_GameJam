using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeText : MonoBehaviour
{
    public TextMeshProUGUI resourceText;

    void Start()
    {
        
        
    }

    void Update()
    {
        if (MiniGameManager.stateMedicine == 1)
        {
            resourceText.text = "����� " + MiniGameManager.instance.MedicineCount + "��";
            resourceText.color = Color.green;
        }
        else if (MiniGameManager.stateMedicine == 2)
        {
            resourceText.text = "�ƽ�Ʈ������ī " + MiniGameManager.instance.MedicineCount + "��";
            resourceText.color = Color.yellow;
        }
        else if (MiniGameManager.stateMedicine == 3)
        {
            resourceText.text = "ȭ���� " + MiniGameManager.instance.MedicineCount + "��";
            resourceText.color = Color.blue;
        }
        if(MiniGameManager.instance.MedicineCount == 0)
        {
            StartCoroutine(MiniGameManager.instance.ReturnCamera(GameManager.Instance.camera));
            GameManager.Instance.scoreNumber += 10;
            resourceText.text = "ġ�Ἲ��!!!";
            resourceText.color = Color.green;
            MiniGameManager.instance.MedicineCount = -1;
        }
    }
}
