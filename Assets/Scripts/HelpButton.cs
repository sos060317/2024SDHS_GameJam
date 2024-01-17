using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HelpButton : MonoBehaviour
{
    public GameObject[] Helppannel;
    public int index;
    public TextMeshProUGUI Buttontex;

    void Start()
    {
        Helppannel[index].SetActive(true);
    }

    void Update()
    {
        
    }

    public void NextHelp()
    {
        if (index < Helppannel.Length -1)
        {
            Helppannel[index].SetActive(false);
            index++;
            Helppannel[index].SetActive(true);
        }
        else if (index < Helppannel.Length)
        {
            SceneManager.LoadScene("InGame");
        }
        if (index >= 2)
        {
            Buttontex.text = "게임시작!!";
        }
    }
}
