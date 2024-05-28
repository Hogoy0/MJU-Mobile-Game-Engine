using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    // Start is called before the first frame update
    int stage_clear = 0;
    public GameObject stage2active;
    public GameObject stage2unactive;
    void Start()
    {
        stage_clear = PlayerPrefs.GetInt("Stage_2_clear");
        if (stage_clear == 1 )
        {
            stage2active.SetActive(true);
            stage2unactive.SetActive(false);
            Debug.Log(stage_clear);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void stage_1_load()
    {
        SceneManager.LoadScene("Chap1_stage1");
    }
}
