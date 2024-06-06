using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIFuncion : MonoBehaviour
{
    public GameObject PauseUI;
    public static bool GameIsPaused = false;
    public AudioSource IngameBGM;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PauseUIActive()
    {
        PauseUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume()
    {
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

    }

    public void Retry()
    {
        Scene CurrentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(CurrentScene.name);
        Time.timeScale = 1f;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Tomain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LobbyScene");
    }

    public void ToChapSelect()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("ChapterSelectScene");

    }

    public void Mute()
    {
        IngameBGM.Stop();
    }

    public void CancelMute()
    {
        IngameBGM.Play();
    }
}
