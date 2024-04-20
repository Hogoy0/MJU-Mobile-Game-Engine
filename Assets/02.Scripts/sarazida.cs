using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private SpriteRenderer spriteRenderer; // 이미지 스프라이트 렌더링
    private bool isVisible = true; // 초기에 보이는 상태로 설정, 인비저블썸띵
    private Color originalColor; // 원래 색깔 저장

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // 스프라이트 불러오고
        originalColor = spriteRenderer.color; // 원래색을 저장한다
    }

    void OnTriggerEnter2D(Collider2D collision) //이 가시가 다른 친구랑 서로 충돌할때
    {
        if (collision.gameObject.CompareTag("Player")) //충돌한 친구가 플레이어 태그가 붙었나 비교
        {
            SetObjectVisibility(false); // 캐릭터와 충돌했을 시 오브젝트를 보이지 않게 설정
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SetObjectVisibility(true); // 캐릭터와 충돌이 끝나면 다시 보이게 설정
        }
    }

    void SetObjectVisibility(bool visible) //오브젝트의 가시성: 보일까 안보일까(여긴 뭔지 모르겠다)
    {
        if (visible)
        {
            spriteRenderer.color = originalColor; // 오브젝트를 보이게 설정
        }
        else
        {
            spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f); // 오브젝트를 숨김
        }

        isVisible = visible;
    }
}
