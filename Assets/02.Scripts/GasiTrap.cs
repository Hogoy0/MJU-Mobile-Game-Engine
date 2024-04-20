using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasiTrap : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private bool isTransparent = true; // 초기에 투명한 상태로 설정
    private Color originalColor; //원래 색깔 저장

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); //스프라이트 불러오고
        originalColor = spriteRenderer.color; //원래색 저장
        SetTransparency(true); // 초기에 투명하게 설정
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SetTransparency(false); // 캐릭터와 충돌 시 다시 원래대로 돌아오게 설정
            Debug.Log("크크루삥뽕"); // 충돌 발생 메시지!!
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) //태그 비교
        {
            SetTransparency(true); // 캐릭터와 충돌이 끝나면 다시 투명하게 설정
        }
    }

    void SetTransparency(bool transparent)
    {
        if (transparent)
        {
            spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f); // 투명한 색으로 변경
        }
        else
        {
            spriteRenderer.color = originalColor; // 원래의 색으로 복원
        }

        isTransparent = transparent;
    }
}
