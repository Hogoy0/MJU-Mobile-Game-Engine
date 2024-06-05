using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class poison2 : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        // 충돌한 오브젝트의 이름에서 "(Clone)"을 제거하고 앞뒤 공백을 제거
        string objectName = collision.gameObject.name.Replace("(Clone)", "").Trim();

        // 이름이 "SlimeMedium2"인지 확인
        if (objectName == "SlimeSmall3")
        {
            // 특정 이름의 오브젝트는 통과할 수 있으므로 아무 동작도 하지 않음
        }
        else
        {
            Debug.Log("죽음! SlimeSmall3가 아닌 오브젝트가 독바닥에 닿았습니다.");
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
