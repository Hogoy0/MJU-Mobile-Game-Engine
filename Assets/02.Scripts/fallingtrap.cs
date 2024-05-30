using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingtrap : MonoBehaviour
{
   public float fallDelay = 1f; // 함정 대기 시간
    public float fallSpeed = 5f; // 떨어지는 속도 영상이나 이런거 보면 보통 5로 하길래ㅎㅎ

    private bool isFallen = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isFallen)
        {
            // 함정이 작동하기 전의 대기 시간 후 함정을 작동시킴
            Invoke("ActivateTrap", fallDelay);
        }
    }

    void ActivateTrap()
    {
        // 함정이 작동되면 Rigidbody2D를 활성화하여 함정이 떨어지도록 함
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.isKinematic = false;
            rb.velocity = Vector2.down * fallSpeed;
        }
        // 함정이 작동된 후 다시 함정이 작동하지 않도록 플래그 설정
        isFallen = true;
    }
}
