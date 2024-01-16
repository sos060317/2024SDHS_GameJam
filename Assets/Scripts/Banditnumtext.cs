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
        resourceText.text = "남은 상처 " + MiniGameManager.instance.BanditCount + "개";
        if(MiniGameManager.instance.BanditCount <= 0)
        {
            resourceText.text = "치료 성공!!!";
            resourceText.color = Color.green;
        }
    }
}
