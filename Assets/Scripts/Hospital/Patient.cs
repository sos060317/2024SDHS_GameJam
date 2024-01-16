using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Patient : MonoBehaviour
{
    private enum PatientStatess
    {
        cut = 0, 
        tear,
        Coronavirus
    }
    private PatientStatess patientStatess;

    [SerializeField] private float moveSpeed;
    [SerializeField] private Image clearTimeRing;
    [SerializeField] private Image stateIcon;
    [SerializeField] private Sprite[] stateSprite;
    [SerializeField] private Button startMiniGame;

    [SerializeField] private float clearTime;

    [HideInInspector] public Transform doorPosition;

    private void Start()
    {
        SetUpClearTime();
        stateIcon.fillAmount = 1;
        clearTimeRing.color = Color.green;
        startMiniGame.enabled = false;
        SetUpPatientState();
        StartCoroutine(GoDoor());
    }

    private void Update()
    {
        ClearTimeDown();
    }

    private void SetUpClearTime()
    {
        clearTime = Random.Range(6, 9) - GameManager.Instance.clearPatient;
    }

    private void ClearTimeDown()
    {
        if (!startMiniGame.enabled)
            return;

        clearTimeRing.fillAmount -= 1 / clearTime * Time.deltaTime;

        if(clearTimeRing.fillAmount <= 0.3f)
        {
            clearTimeRing.color = Color.red;
        }
        else if(clearTimeRing.fillAmount <= 0.7f)
        {
            clearTimeRing.color = Color.yellow;
        }


        if (clearTimeRing.fillAmount <= 0 )
        {
            clearTimeRing.fillAmount = 0;
            GameManager.Instance.currentMoney -= 10 - GameManager.Instance.clearPatient;
            Destroy(gameObject);
        }
    }

    private void SetUpPatientState()
    {
        int randomState = Random.Range(0, System.Enum.GetValues(typeof(PatientStatess)).Length);

        patientStatess = (PatientStatess)randomState;
        stateIcon.sprite = stateSprite[randomState];
    }

    public void StartMiniGame()
    {
        //GameManager.Instance.isGameStart = false;
        GameManager.Instance.fadeBackground.gameObject.SetActive(true);
        GameManager.Instance.FadeINOUTStart((int)patientStatess);
    }

    IEnumerator GoDoor()
    {
        BedsChecker targetBedFloor = BedsManager.Instance.CheckFloorPoint();
        while (transform.position.y >= targetBedFloor.transform.position.y)
        {
            transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);

            yield return null;
        }

        if (!targetBedFloor.beds[0].isFull)
        {
            while(transform.position.x >= targetBedFloor.beds[0].transform.position.x)
            {
                transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

                yield return null;
            }
        }
        else if(!targetBedFloor.beds[1].isFull)
        {
            while (transform.position.x <= targetBedFloor.beds[1].transform.position.x)
            {
                transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

                yield return null;
            }
        }

        startMiniGame.enabled = true;

        yield break;
    }
}
