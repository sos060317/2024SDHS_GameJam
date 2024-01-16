using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using TMPro;
using System.Resources;

public class WoundText : MonoBehaviour
{
    public TextMeshProUGUI Woundtext;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SetText();
    }

    public void SetText()
    {
        Woundtext.text = "���� ��ó " + MiniGameManager.instance.ThreadCount + "��";
        if(MiniGameManager.instance.ThreadCount <= 0)
        {
            Woundtext.text = "ġ�Ἲ��!!!";
            Woundtext.color = Color.green;
        }
    }

}
