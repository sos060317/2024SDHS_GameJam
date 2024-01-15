using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGamePlayer : MonoBehaviour
{
    Rigidbody2D rb;
    public float Speed;
    public float JumpPower;

    public bool isJumping = false;


    void Start()
    {

    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space)) { PlayerJump(); }

        PlayerMove();
    }

    void Update()
    {

    }

    void PlayerMove()
    {
        Vector2 moveVelocity = Vector2.zero;

        if (Input.GetAxis("Horizontal") < 0)
        {
            moveVelocity = Vector3.left;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            moveVelocity = Vector3.left;
        }


        transform.position = moveVelocity * Speed * Time.deltaTime;
    }
    void PlayerJump()
    {

        rb.velocity = Vector2.zero;

        Vector2 jumpVelocity = new Vector2(0, JumpPower);
        rb.AddForce(jumpVelocity, ForceMode2D.Impulse);

        isJumping = false;
    }
}
