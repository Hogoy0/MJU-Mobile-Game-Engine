using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactorcontrol : MonoBehaviour
{
    public float moveSpeed = 5f; // 이동 속도
    public float jumpForce = 10f; // 점프 힘
    public LayerMask groundLayer; // 바닥 레이어
    private Rigidbody2D rb;
    private Break currentPlatform; // 현재 접하는 발판

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            Jump();
            if (currentPlatform != null)
            {
                currentPlatform.PlayerLanded(); // 플레이어가 착지했음을 알림
            }
        }
    }

    private void Move()
    {
        float moveInput = Input.GetAxisRaw("Horizontal"); // 좌우 화살표 키 입력 감지
        Vector2 moveVelocity = new Vector2(moveInput * moveSpeed, rb.velocity.y); // 이동 속도 설정
        rb.velocity = moveVelocity; // Rigidbody에 이동 속도 적용
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce); // 점프 힘 설정
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, groundLayer);
        return hit.collider != null; // 바닥에 닿았는지 여부 반환
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Break"))
        {
            currentPlatform = collision.gameObject.GetComponent<Break>();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Break"))
        {
            currentPlatform = null;
        }
    }
}
