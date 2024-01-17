using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Camera camera;

    [SerializeField] private GameObject restartMenu;

    [SerializeField] private GameObject[] miniGames;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] public int scoreNumber = 0;

    [SerializeField] private Image moneyBar;
    [SerializeField] private float maxMoney;
    [HideInInspector] public float currentMoney;

    public Image fadeBackground;
    private Color fadeColor;

    [HideInInspector] public float clearPatient = 0;

    [HideInInspector] public bool isGameStart = false;

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

    private void Start()
    {
        currentMoney = maxMoney;
        scoreText.text = scoreNumber.ToString();
    }

    private void Update()
    {
        MoneyBar();
        scoreText.text = scoreNumber.ToString();
    }

    private void MoneyBar()
    {
        moneyBar.fillAmount = Mathf.Lerp(moneyBar.fillAmount,
            currentMoney / maxMoney, 10 * Time.deltaTime);

        if(moneyBar.fillAmount < 0.1)
        {
            isGameStart = false;
            restartMenu.gameObject.SetActive(true);
        }
    }

    private void StartMiniGame(int cameraFloor)
    {
        camera.transform.position = new Vector3(miniGames[cameraFloor].transform.position.x,
            miniGames[cameraFloor].transform.position.y, -10);
        
        miniGames[cameraFloor].gameObject.SetActive(true);

        MiniGameManager.miniGamesNumber = cameraFloor;
    }

    public void FadeINOUTStart(int anyPatient)
    {
        StartCoroutine(FadeINOUT(anyPatient));
    }

    public IEnumerator FadeINOUT(int anyPatient)
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

        StartMiniGame(anyPatient);

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
