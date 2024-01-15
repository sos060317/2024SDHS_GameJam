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
    [SerializeField] private Image stateIcon;
    [SerializeField] private Sprite[] stateSprite;
    [SerializeField] private Button startMiniGame;

    [HideInInspector] public Transform doorPosition;

    private void Start()
    {
        startMiniGame.enabled = false;
        SetUpPatientState();
        StartCoroutine(GoDoor());
    }

    private void SetUpPatientState()
    {
        int randomState = Random.Range(0, System.Enum.GetValues(typeof(PatientStatess)).Length);

        patientStatess = (PatientStatess)randomState;
        stateIcon.sprite = stateSprite[randomState];
    }

    public void StartMiniGame()
    {
        Debug.Log("a;skdfj");
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
