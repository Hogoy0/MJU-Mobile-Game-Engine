using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeDoor : MonoBehaviour
{
    string sceneName;
    string SaveKey;
    string[] parts;
    string LoadSceneName;
    public GameObject ClearUI;

    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
        parts = sceneName.Split(new string[] { "Chap", "_stage" }, System.StringSplitOptions.RemoveEmptyEntries);
        Debug.Log(sceneName);
        Debug.Log(parts[0]);
        Debug.Log(parts[1]);
        SaveKey = "Chap" + parts[0] + "_stage" + parts[1];
        Debug.Log(SaveKey);
        GetLoadSceneName();
        Debug.Log(LoadSceneName);
    }




    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            float delay = 3.0f;
            Debug.Log("Å¬¸®¾î");
            PlayerPrefs.SetInt(SaveKey, 1);
            PlayerPrefs.Save();
            ClearUI.SetActive(true);
            Invoke("LoadChapScene", delay);
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



}
