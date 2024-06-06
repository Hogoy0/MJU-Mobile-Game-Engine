using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Character : MonoBehaviour
{
    public float moveSpeed = 2f; // 이동 속도
    public bool Selected = false;
    public bool MoveLeft = false;
    public bool MoveRight = false;
    float JumpPower = 7;
    public bool isJump = false;
    Vector2 playerDir;
    Vector3 Rayposition = new Vector3 (2, 0, 0);
    public bool SlimeRaycast = false;
    public RaycastHit2D rayhit;
    public Vector2 boxCastSize = new Vector2(0.5f, 5f);
    public float boxCastDistance = 0.1f;
    public int ListNumber = 10;
    public int SlimeSize = 0;
    Rigidbody2D rigid;
    SpriteRenderer spriterenderer;
    AudioSource JumpSound;
    public AudioSource MurgeSound;


    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();        
        spriterenderer = GetComponent<SpriteRenderer>();
        JumpSound = GetComponent<AudioSource>();
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
        if (MoveLeft)
        {
            Vector3 movement = new Vector3(-1f, 0f, 0f) * moveSpeed * Time.deltaTime;
            playerDir = Vector2.left;
            spriterenderer.flipX = true;
            transform.Translate(movement);
        }
        if (MoveRight)
        {
            Vector3 movement = new Vector3(1f, 0f, 0f) * moveSpeed * Time.deltaTime;
            playerDir = Vector2.right;
            spriterenderer.flipX = false;
            transform.Translate(movement);
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
        CheckLanding();
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

    public void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (isJump == false)
            {
                rigid.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
                JumpSound.Play();

                isJump = true;
            }
        }
    }

    public void UIJump()
    {
        if (isJump == true)
        {
            Debug.DrawRay(transform.position, Vector2.down * 0.6f, Color.blue);
            RaycastHit2D LandingCheck;
            LandingCheck = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, LayerMask.GetMask("Tile"));

            if (LandingCheck.collider != null)
            {
                isJump = false;
                Debug.Log("isJump 수정");
            }

        }

        if (isJump == false)
        {
            rigid.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
            JumpSound.Play();
            isJump = true;
        }
        
    }

    public void UILeftMove()
    {
        Vector3 movement = new Vector3(-4f, 0f, 0f) * moveSpeed * Time.deltaTime;
        playerDir = Vector2.left;
        spriterenderer.flipX = true;
        transform.Translate(movement);
    }

    public void UIRightMove()
    {
        Vector3 movement = new Vector3(1f, 0f, 0f) * moveSpeed * Time.deltaTime;
        playerDir = Vector2.right;
        spriterenderer.flipX = false;
        transform.Translate(movement);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       /* if (collision.gameObject.CompareTag("Platform")) 
        {
            Debug.Log("플랫폼과 충돌!");
            isJump = false;
        }
       */
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("슬라임과 충돌!");
            isJump = false;
        }
    }

    private void CheckLanding()
    {
       
        if (rigid.velocity.y < 0)
        {
            Debug.DrawRay(transform.position, Vector2.down * 1.0f, Color.blue);
            RaycastHit2D LandingCheck;
            RaycastHit2D LandingCheck2;
            LandingCheck = Physics2D.Raycast(transform.position, Vector2.down, 1.0f, LayerMask.GetMask("Tile"));
            LandingCheck2 = Physics2D.Raycast(transform.position, Vector2.down, 1.0f, LayerMask.GetMask("Box"));

            if (LandingCheck.collider != null)
            {
                if (LandingCheck.distance < 0.5f)
                {
                    isJump = false;
                    Debug.Log("바닥 착지");
                }
            }

            if (LandingCheck2.collider != null)
            {
                if (LandingCheck2.distance < 0.5f)
                {
                    isJump = false;
                    Debug.Log("바닥 착지");
                }
            }


        }
    }

    void CheckJumpStatus()
    {
        // 박스캐스트의 시작 위치와 방향을 설정합니다.
        Vector2 origin = transform.position;
        Vector2 direction = Vector2.down;

        // 박스캐스트를 수행합니다.
        RaycastHit2D hit = Physics2D.BoxCast(origin, boxCastSize, 0, direction, boxCastDistance, LayerMask.GetMask("Tile"));
        if (hit.collider != null)
        {
            // 박스캐스트가 바닥에 닿았다면 착지 상태
            isJump = false;
        }

        // 디버그 박스 그리기 (필요 시)
        Debug.DrawRay(origin, direction * boxCastDistance, Color.red);
        Debug.DrawLine(origin - new Vector2(boxCastSize.x / 2, 0), origin + new Vector2(boxCastSize.x / 2, 0), Color.blue);
        Debug.DrawLine(origin - new Vector2(0, boxCastSize.y / 2), origin + new Vector2(0, boxCastSize.y / 2), Color.blue);
    }

}
