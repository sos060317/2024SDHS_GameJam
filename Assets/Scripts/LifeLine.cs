using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeLine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Collider collider = GetComponent<Collider>();
        if (collider != null)
        {
            collider.isTrigger = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D o)
    {
        if (o.gameObject.tag == ("Wound"))
        {
            Destroy(o.gameObject);
            MiniGameManager.instance.ThreadCount += 1;
        }
        else if (o.gameObject.tag == ("Thread"))
        {
            Destroy(o.gameObject);
            MiniGameManager.instance.ThreadCount -= 1;

        }
    }
}
