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
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position); //ĳ������ ���� ��ǥ�� ����Ʈ ��ǥ��� ��ȯ���ش�.
        viewPos.x = Mathf.Clamp01(viewPos.x); //x���� 0�̻�, 1���Ϸ� �����Ѵ�.
        viewPos.y = Mathf.Clamp01(viewPos.y); //y���� 0�̻�, 1���Ϸ� �����Ѵ�.
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos); //�ٽ� ���� ��ǥ�� ��ȯ�Ѵ�.
        transform.position = worldPos; //��ǥ�� �����Ѵ�.

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
        Debug.Log("����");
        MiniGameManager.instance.isStun = false;
    }
    private void OnBecameInvisible()
    {
        transform.position = PlayerSpawnps.transform.position;
    }
}
