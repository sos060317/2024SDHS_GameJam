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
        
        if (MiniGameManager.instance.WhatMedicine == 1)
        {
            resourceText.text = "�����";
            resourceText.color = Color.green;
        }
        else if (MiniGameManager.instance.WhatMedicine == 2){
            resourceText.text = "�ƽ�Ʈ������ī";
            resourceText.color = Color.yellow;
        }
        else if (MiniGameManager.instance.WhatMedicine == 3)
        {
            resourceText.text = "ȭ����";
            resourceText.color = Color.blue;
        }
    }

    void Update()
    {
        
    }
}
