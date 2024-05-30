using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poison2 : MonoBehaviour
{
    private Collider2D floorCollider;

    void Start()
    {
        floorCollider = GetComponent<Collider2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // 플레이어는 통과할 수 있으므로 아무 동작도 하지 않음
        }
        else
        {
            Debug.Log("게임 오버! 플레이어가 아닌 캐릭터가 바닥에 닿았음.");
        }
    }
}
