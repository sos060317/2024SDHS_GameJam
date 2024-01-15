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
            resourceText.text = "모더나";
            resourceText.color = Color.green;
        }
        else if (MiniGameManager.instance.WhatMedicine == 2){
            resourceText.text = "아스트로제네카";
            resourceText.color = Color.yellow;
        }
        else if (MiniGameManager.instance.WhatMedicine == 3)
        {
            resourceText.text = "화이자";
            resourceText.color = Color.blue;
        }
    }

    void Update()
    {
        
    }
}
