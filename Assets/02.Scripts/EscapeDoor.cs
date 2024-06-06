using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeDoor : MonoBehaviour
{
    string sceneName;
    string SaveKey;
    string SaveDropKey;
    string[] parts;
    string LoadSceneName;
    public GameObject ClearUI;
    public int DropCounting = 0;
    string NextStage;

    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
        parts = sceneName.Split(new string[] { "Chap", "_stage" }, System.StringSplitOptions.RemoveEmptyEntries);
        Debug.Log(sceneName);
        Debug.Log(parts[0]);
        Debug.Log(parts[1]);
        NextStage = "Chap" + parts[0] + "_stage";
        Debug.Log("다음 스테이지는 " + NextStage);
        SaveKey = "Chap" + parts[0] + "_stage" + parts[1];
        SaveDropKey = "Chap" + parts[0] + "_stage" + parts[1] + "Drop";
        Debug.Log(SaveKey);
        GetLoadSceneName();
        Debug.Log(LoadSceneName);
    }




    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            float delay = 3.0f;
            Debug.Log("클리어");
            PlayerPrefs.SetInt(SaveKey, 1);
            PlayerPrefs.SetInt(SaveDropKey, DropCounting);
            PlayerPrefs.Save();
            ClearUI.SetActive(true);
        }
    }

    void LoadChapScene()
    {
        SceneManager.LoadScene(LoadSceneName);
    }
    void GetLoadSceneName()
    {

        int ChapNum = int.Parse(parts[0]);
        if (ChapNum == 1)
        {
            LoadSceneName = "Chap1Scene";
        }
        else if (ChapNum == 2)
        {
            LoadSceneName = "Chap2Scene";
        }

        else if (ChapNum == 3)
        {
            LoadSceneName = "Chap3Scene";
        }


    }

    public void ToNextStage()
    {
        int NextStageNum = int.Parse(parts[1]);
        NextStageNum += 1;
        if (NextStageNum < 6)
        {
            string NextStageStr = NextStageNum.ToString();
            string NextLoadScene = NextStage + NextStageStr;
            SceneManager.LoadScene(NextLoadScene);
        }

    }



}
