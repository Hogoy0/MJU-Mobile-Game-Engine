using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColorWater : MonoBehaviour
{
    void RestartScene()
    {
        // 현재 씬을 다시 로드
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // 타임 스케일을 1로 설정하여 게임이 정상 속도로 진행되도록 함
        Time.timeScale = 1f;
    }

    void OnTriggerEnter2D(Collider2D Collision)
    {
        string objectName = Collision.gameObject.name.Replace("(Clone)", "").Trim();
        int otherLastInt = int.Parse(objectName[objectName.Length - 1].ToString());
        int myLastInt = int.Parse(this.name[this.name.Length - 1].ToString());

        if (Collision.gameObject.tag == "ColorWater")
        {
            if (otherLastInt == myLastInt)
            {
                RestartScene();
            }
        }
    }
}