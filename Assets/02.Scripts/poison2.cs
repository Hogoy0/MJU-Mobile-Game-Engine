using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            RestartScene();
        }
    }

    void RestartScene()
    {
        // 현재 씬을 다시 로드
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // 타임 스케일을 1로 설정하여 게임이 정상 속도로 진행되도록 함
        Time.timeScale = 1f;
    }
}
