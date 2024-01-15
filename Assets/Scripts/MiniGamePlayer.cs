using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class MiniGamePlayer : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sp;
    Animator animator;
    BoxCollider2D attackRange;

    public GameObject PlayerSpawnps;
    public GameObject AttackRange;
    public float JumpPower;
    public bool isAttack = false;
    public float speed;
    public bool isJumping = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        attackRange = GetComponent<BoxCollider2D>();
        AttackRange.SetActive(false);
    }

    void FixedUpdate()
    {
        
    }

    void Update()
    {
        if (!MiniGameManager.instance.isStun)
        {
            if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
            {
                Debug.Log("sdsd");
                isJumping = true;
                PlayerJump();

            }
            if (Input.GetKeyDown(KeyCode.F) && isAttack == false)
            {
                //attackRange.enabled = true;
                isAttack = true;
                AttackRange.SetActive(true);
                Invoke("IsAttack", 1f);
                animator.SetTrigger("Attack");

            }
            PlayerMove();
        }
        else if(MiniGameManager.instance.isStun)
        {
            Invoke("StunEnd", MiniGameManager.instance.StunTime);
        }
    }

    void PlayerMove()
    {
        float h = Input.GetAxis("Horizontal");

        if (Input.GetAxis("Horizontal") > 0)
        {
            sp.flipX = false;
            AttackRange.transform.localScale = new Vector3(1, 1, 1);
            //transform.localScale = new Vector3(-1, 1, 1);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            sp.flipX = true;
            AttackRange.transform.localScale = new Vector3(-1, 1, 1);

            //transform.localScale = new Vector3(1, 1, 1);
        }
        transform.Translate(new Vector3(h, 0, 0) * speed * Time.deltaTime);
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position); //캐릭터의 월드 좌표를 뷰포트 좌표계로 변환해준다.
        viewPos.x = Mathf.Clamp01(viewPos.x); //x값을 0이상, 1이하로 제한한다.
        viewPos.y = Mathf.Clamp01(viewPos.y); //y값을 0이상, 1이하로 제한한다.
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos); //다시 월드 좌표로 변환한다.
        transform.position = worldPos; //좌표를 적용한다.

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
    private void IsAttack()
    {
        isAttack = false;

        AttackRange.SetActive(false);
    }
    public void StunEnd()
    {
        Debug.Log("응애");
        MiniGameManager.instance.isStun = false;
    }
    private void OnBecameInvisible()
    {
        transform.position = PlayerSpawnps.transform.position;
    }
}
