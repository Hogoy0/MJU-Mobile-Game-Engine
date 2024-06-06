using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Poison_and_ColorWater : MonoBehaviour
{    void RestartScene()
    {
        // 현재 씬을 다시 로드
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // 타임 스케일을 1로 설정하여 게임이 정상 속도로 진행되도록 함
        Time.timeScale = 1f;
    }

    void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Collision.gameObject.tag == "Poison")
        {
            Debug.Log("독바닥에 닿았습니다. 게임 오버!");
            RestartScene();
        }

        else if (Collision.gameObject.tag == "ColorWater")
        {
            string objectName = Collision.gameObject.name;
            string myName = this.name.Replace("(Clone)", "").Trim();
            int otherLastInt = int.Parse(objectName[objectName.Length - 1].ToString());
            int myLastInt = int.Parse(myName[myName.Length - 1].ToString());

            if (otherLastInt != myLastInt)
            {
                RestartScene();
            }
        }
        
        
    }
}
