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
        if (MiniGameManager.instance.stateMedicine == 1)
        {
            resourceText.text = "모더나 " + MiniGameManager.instance.MedicineCount + "개";
            resourceText.color = Color.green;
        }
        else if (MiniGameManager.instance.stateMedicine == 2)
        {
            resourceText.text = "아스트로제네카 " + MiniGameManager.instance.MedicineCount + "개";
            resourceText.color = Color.yellow;
        }
        else if (MiniGameManager.instance.stateMedicine == 3)
        {
            resourceText.text = "화이자 " + MiniGameManager.instance.MedicineCount + "개";
            resourceText.color = Color.blue;
        }
        if(MiniGameManager.instance.MedicineCount <= 0)
        {
            resourceText.text = "치료성공!!!";
            resourceText.color = Color.green;
        }
    }
}
