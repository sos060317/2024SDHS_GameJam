using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Banditnumtext : MonoBehaviour
{
    public TextMeshProUGUI resourceText;

    void Start()
    {

    }

    void Update()
    {
        resourceText.text = "���� ��ó " + MiniGameManager.instance.BanditCount + "��";
        if(MiniGameManager.instance.BanditCount <= 0)
        {
            resourceText.text = "ġ�� ����!!!";
            resourceText.color = Color.green;
        }
    }
}
