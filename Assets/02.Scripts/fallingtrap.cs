using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fallingtrap : MonoBehaviour
{
   private SpriteRenderer spriteRenderer;
    private bool isTransparent = true; // 초기에 투명한 상태로 설정
    private Color originalColor; //원래 색깔 저장
    private Rigidbody2D rb;
    public Vector2 moveDirection = Vector2.down; // 기본 이동 방향은 아래로
    public float moveSpeed = 5f; // 이동 속도 설정

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // 스프라이트 불러오고
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D 불러오기
        originalColor = spriteRenderer.color; // 원래색 저장
        SetTransparency(true); // 초기에 투명하게 설정
        rb.isKinematic = true; // 초기에는 물리적인 힘을 받지 않도록 설정
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SetTransparency(false); // 캐릭터와 충돌 시 다시 원래대로 돌아오게 설정
            Debug.Log("크크루삥뽕"); // 충돌 발생 메시지!!
            rb.isKinematic = false; // 물리적인 힘을 받도록 설정
            rb.velocity = moveDirection.normalized * moveSpeed; // 지정된 방향으로 이동 시작
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // 태그 비교
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

    void RestartScene()
    {
        // 현재 씬을 다시 로드
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // 타임 스케일을 1로 설정하여 게임이 정상 속도로 진행되도록 함
        Time.timeScale = 1f;
    }
}
