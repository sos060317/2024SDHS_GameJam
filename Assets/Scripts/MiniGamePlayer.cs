using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGamePlayer : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sp;
    public float Speed;
    public float JumpPower;

    public bool isJumping = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            Debug.Log("sdsd");
            isJumping = true;
            PlayerJump();

        }

        PlayerMove();
    }

    void PlayerMove()
    {
        float h = Input.GetAxis("Horizontal");

        if (Input.GetAxis("Horizontal") > 0)
        {
            sp.flipX = false;
            //transform.localScale = new Vector3(-1, 1, 1);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            sp.flipX = true;
            //transform.localScale = new Vector3(1, 1, 1);
        }
        transform.Translate(new Vector3(h, 0, 0) * Speed * Time.deltaTime);

    }
    void PlayerJump()
    {
        rb.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground")){
            isJumping = false;
        }
    }
}
