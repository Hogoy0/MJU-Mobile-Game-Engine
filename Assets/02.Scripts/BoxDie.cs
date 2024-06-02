using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoxDie : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        // 박스에 충돌하면 게임 오버 처리
        Debug.Log("박스에 충돌했습니다. 게임 오버!");
        RestartScene();
    }

    void RestartScene()
    {
        // 현재 씬을 다시 로드
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // 타임 스케일을 1로 설정하여 게임이 정상 속도로 진행되도록 함
        Time.timeScale = 1f;
    }
}
