using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Banditnumtext : MonoBehaviour
{
    public TextMeshProUGUI resourceText;

    void Start()
    {
        resourceText.text = "���� ��ó " + MiniGameManager.instance.BanditCount + "��";
    }

    void Update()
    {
        SetText();
    }
    public void SetText()
    {
        resourceText.text = "���� ��ó " + MiniGameManager.instance.BanditCount + "��";
        if (MiniGameManager.instance.BanditCount == 0)
        {
            StartCoroutine(MiniGameManager.instance.ReturnCamera(GameManager.Instance.camera));
            GameManager.Instance.scoreNumber += 10;
            resourceText.text = "ġ�� ����!!!";
            resourceText.color = Color.green;
            MiniGameManager.instance.BanditCount = -1;
        }
    }
}
