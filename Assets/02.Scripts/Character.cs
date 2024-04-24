using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Character : MonoBehaviour
{
    public float moveSpeed = 5f; // 이동 속도
    public bool Selected = false;
    float JumpPower = 7;
    bool isJump = false;
    Vector2 playerDir;
    Vector3 Rayposition = new Vector3 (2, 0, 0);
    public bool SlimeRaycast = false;
    public RaycastHit2D rayhit;
    public int ListNumber = 10;
    public int SlimeSize = 0;
    Rigidbody2D rigid;
    SpriteRenderer spriterenderer; 

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();        
        spriterenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {        
    }
    void Update()
    {
        if (Selected == true)
        {
            Jump();
            Move();
        }
    }

    void FixedUpdate()
    {
        if (Selected == true)
        {
            Debug.DrawRay(transform.position, playerDir * 1, Color.red);
            rayhit = Physics2D.Raycast(transform.position, playerDir, 1, LayerMask.GetMask("Slime"));
            if (rayhit.collider != null)
            {
                Debug.Log("감지되는중");
            }
        }

    }



    void Move()
    {
        // 수평 이동 입력
        float moveInput = Input.GetAxis("Horizontal");

        // 이동 벡터 계산
        Vector3 movement = new Vector3(moveInput, 0f, 0f) * moveSpeed * Time.deltaTime;

        if(moveInput < 0f)
        {
            playerDir = Vector2.left;
            spriterenderer.flipX = true;
        }

        else if (moveInput > 0f)
        {
            playerDir = Vector2.right;
            spriterenderer.flipX = false;
        }
        // 이동 적용
        transform.Translate(movement);

        
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (isJump == false)
            {
                rigid.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
            }
            isJump = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform")) 
        {
            Debug.Log("플랫폼과 충돌!");
            isJump = false;
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("슬라임과 충돌!");
            isJump = false;
        }
    }



}
