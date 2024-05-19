using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    // Start is called before the first frame update
    public void GoSelectScene()
    {
        SceneManager.LoadScene("SelectScene");
    }
    public void GoTitleScene()
    {
        SceneManager.LoadScene("SeorinTest");
    }

    public void GoChapter1()
    {
        SceneManager.LoadScene("SeorinTest");
    }
}

