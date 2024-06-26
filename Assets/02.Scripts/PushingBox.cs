using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushingBox : MonoBehaviour
{
    public string pushableTag = "Player"; // 밀 수 있는 태그
    private Rigidbody2D rb;
    private bool isBeingPushed;
    private Collider2D pushingCharacter;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = false; // 초기 상태에서 박스가 중력의 영향을 받음
    }

    void FixedUpdate()
    {
        if (isBeingPushed && pushingCharacter != null)
        {
            Vector2 pushDirection = GetPushDirection(pushingCharacter);
            if (pushDirection != Vector2.zero)
            {
                rb.velocity = pushDirection * 5f; // 속도 조절 가능
            }
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y); // 상자가 밀리지 않을 때 수평 속도를 0으로 설정
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(pushableTag))
        {
            isBeingPushed = true;
            pushingCharacter = collision.collider;
            rb.isKinematic = false; // 밀리는 동안 박스를 물리적으로 이동 가능하게 설정
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider == pushingCharacter)
        {
            isBeingPushed = false;
            pushingCharacter = null;
            rb.velocity = Vector2.zero; // 밀림이 멈췄을 때 속도 초기화
        }
    }

    Vector2 GetPushDirection(Collider2D character)
    {
        float horizontal = Input.GetAxis("Horizontal");
        return new Vector2(horizontal, 0).normalized; // 수평 방향만 반환
    }

    void OnDrawGizmos()
    {
        // 편집 모드에서 OverlapBox 영역을 시각적으로 확인
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }
}