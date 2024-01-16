using EasyTransition;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    [SerializeField] private TransitionSettings transition;

    private void Update()
    {
        if(Input.anyKeyDown)
        {
            LoadScene("InGame");
        }
    }

    public void LoadScene(string sceneName)
    {
        TransitionManager.Instance().Transition(sceneName, transition, 0f);
    }
}
