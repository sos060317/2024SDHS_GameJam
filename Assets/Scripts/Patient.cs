using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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

    [HideInInspector] public Transform doorPosition;

    private bool isClear;
    private bool isCheck;

    private void Start()
    {


        StartCoroutine(GoDoor());
    }

    private void SetUpPatientState()
    {
         int randomState = Random.Range(0, System.Enum.GetValues(typeof(PatientStatess)).Length);

        //patientStatess = randomState;
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

        yield break;
    }
}
