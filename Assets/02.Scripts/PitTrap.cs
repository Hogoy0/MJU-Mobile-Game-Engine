using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitTrap : MonoBehaviour
{
    public float fallDelay = 1f; // 발판이 떨어지기까지의 지연 시간

    private bool isFalling = false; // 발판이 떨어지는지 여부를 나타내는 플래그

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 충돌한 오브젝트가 플레이어인 경우
        if (collision.gameObject.CompareTag("Player"))
        {
            // 일정 시간 후에 발판을 떨어뜨림
            Invoke("Fall", fallDelay);
        }
    }

    void Fall()
    {
        // 발판을 떨어뜨리기 위해 Rigidbody2D를 활성화하고, 중력을 적용함
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = false;
        rb.gravityScale = 1f;

        // 발판이 떨어진 후에는 다시 충돌을 감지하지 않도록 Collider2D를 비활성화함
        GetComponent<Collider2D>().enabled = false;

        // 발판 오브젝트를 파괴하거나 재활용할 수 있도록 일정 시간 후에 파괴함
        Destroy(gameObject, 2f);
    }
}
