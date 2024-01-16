using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBgm : MonoBehaviour
{
    public int Bgmnum;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.ChangeBGM(Bgmnum);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
