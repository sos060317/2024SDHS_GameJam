using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public bool isBandit = false;
    public GameObject effect;

    void Start()
    {
        speed = Random.Range(4f, 5f);
    }

    void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0 ,0);
        if(MiniGameManager.instance.BanditCount <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(isBandit)
        {
            if(other.gameObject.tag == ("PlayerRange"))
            {
                Instantiate(effect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            if(other.gameObject.tag == ("Player"))
            {
                MiniGameManager.instance.BanditCount--;
                Destroy(gameObject);
            }
        }
        if (!isBandit)
        {
            if(other.gameObject.tag == ("Player"))
            {
                MiniGameManager.instance.BanditCount++;
                MiniGameManager.instance.isStun = true;
                Destroy(gameObject);
            }
            if (other.gameObject.tag == ("PlayerRange"))
            {
                Instantiate(effect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }



}
