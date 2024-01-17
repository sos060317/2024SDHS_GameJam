using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Banditnumtext : MonoBehaviour
{
    public TextMeshProUGUI resourceText;

    void Start()
    {
        resourceText.text = "남은 상처 " + MiniGameManager.instance.BanditCount + "개";
    }

    void Update()
    {
        SetText();
    }
    public void SetText()
    {
        resourceText.text = "남은 상처 " + MiniGameManager.instance.BanditCount + "개";
        if (MiniGameManager.instance.BanditCount == 0)
        {
            StartCoroutine(MiniGameManager.instance.ReturnCamera(GameManager.Instance.camera));
            GameManager.Instance.scoreNumber += 10;
            resourceText.text = "치료 성공!!!";
            resourceText.color = Color.green;
            MiniGameManager.instance.BanditCount = -1;
        }
    }
}
