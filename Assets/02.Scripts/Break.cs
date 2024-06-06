using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    public int landLimit = 5; // 부서지기 전에 필요한 착지 횟수
    private int landCount = 0; // 플레이어의 착지 횟수

    public Sprite[] sprites; // 최대 5개의 스프라이트를 설정할 수 있는 배열
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // SpriteRenderer 가져오기
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer가 없습니다. SpriteRenderer 컴포넌트를 추가하세요.");
        }

        if (sprites.Length == 0)
        {
            Debug.LogError("sprites 배열이 비어 있습니다. Inspector 창에서 스프라이트를 설정하세요.");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player landed on the platform");
            PlayerLanded();
        }
    }

    public void PlayerLanded()
    {
        // 플레이어가 착지할 때 호출되는 함수
        landCount++;
        Debug.Log("Land count: " + landCount);
        if (landCount >= landLimit)
        {
            BreakPlatform();
        }
        else
        {
            UpdateSprite(); // 착지 카운트가 증가할 때마다 스프라이트 업데이트
        }
    }

    private void BreakPlatform()
    {
        // 발판을 부수는 함수 (애니메이션 재생 또는 부서진 그래픽 처리)
        // 이후 발판을 비활성화하거나 제거하는 등의 추가 작업을 수행할 수 있습니다.
        Debug.Log("Platform is breaking");
        gameObject.SetActive(false); // 발판 비활성화
    }

    private void UpdateSprite()
    {
        if (landCount - 1 < sprites.Length) // landCount는 1부터 시작하므로 인덱스 조정
        {
            Debug.Log($"Updating sprite to index: {landCount - 1}"); // 디버그 로그 추가
            spriteRenderer.sprite = sprites[landCount - 1]; // 스프라이트 변경
            Debug.Log($"New sprite set: {spriteRenderer.sprite.name}"); // 스프라이트 이름 로그
        }
        else
        {
            Debug.LogWarning("스프라이트 배열의 길이를 초과했습니다. 스프라이트를 설정할 수 없습니다.");
        }
    }
}
