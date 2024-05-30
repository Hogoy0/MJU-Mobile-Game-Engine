using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBox : MonoBehaviour
{
    public LayerMask pushableLayer; // 밀 수 있는 레이어 마스크
    public LayerMask nonPushableLayer1; // 밀 수 없는 첫 번째 레이어 마스크
    public LayerMask nonPushableLayer2; // 밀 수 없는 두 번째 레이어 마스크
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
        else if (!isBeingPushed)
        {
            rb.velocity = new Vector2(0, rb.velocity.y); // 상자가 밀리지 않을 때 수평 속도를 0으로 설정
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & pushableLayer) != 0 && collision.gameObject.CompareTag("Player"))
        {
            isBeingPushed = true;
            pushingCharacter = collision.collider;
            rb.isKinematic = false; // 밀리는 동안 박스를 물리적으로 이동 가능하게 설정
        }
        else if (((1 << collision.gameObject.layer) & nonPushableLayer1) != 0 || ((1 << collision.gameObject.layer) & nonPushableLayer2) != 0)
        {
            rb.isKinematic = true; // 밀 수 없는 레이어와 접촉 시 박스를 고정
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
