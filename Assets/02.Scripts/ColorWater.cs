using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColorWater : MonoBehaviour
{
    void RestartScene()
    {
        // ���� ���� �ٽ� �ε�
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // Ÿ�� �������� 1�� �����Ͽ� ������ ���� �ӵ��� ����ǵ��� ��
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