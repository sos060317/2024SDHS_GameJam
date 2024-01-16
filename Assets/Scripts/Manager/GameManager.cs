using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Camera camera;

    public Image fadeBackground;
    private Color fadeColor;

    [HideInInspector] public bool isGameStart = true;

    [HideInInspector] public float clearTimeOffset = 0.0f;

    private static GameManager instance = null;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }

            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void FadeINOUTStart()
    {
        StartCoroutine(FadeINOUT());
    }

    IEnumerator FadeINOUT()
    {
        fadeColor.a = 0.0f;
        fadeBackground.color = fadeColor;

        while(fadeColor.a <= 1.0f)
        {
            fadeColor.a += 0.01f;
            fadeBackground.color = fadeColor;

            if (fadeColor.a >= 1.0f)
            {
                fadeColor.a = 1.0f;
                break;
            }

            yield return null;
        }

        yield return new WaitForSeconds(1.0f);

        while (fadeColor.a >= 0.0f)
        {
            fadeColor.a -= 0.01f;
            fadeBackground.color = fadeColor;

            if (fadeColor.a <= 0.0f)
            {
                fadeColor.a = 0.0f;
                break;
            }

            yield return null;
        }

        fadeBackground.gameObject.SetActive(false);
    }
}
