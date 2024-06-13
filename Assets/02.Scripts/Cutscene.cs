using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    public int GameClearInfo = 0;
    public int DropInfo = 0;
    public GameObject dim1;
    public GameObject NormalEnding;
    public GameObject dim2;
    public GameObject HiddenEnding;
    void Start()
    {
        ClearCheck();
        CheckDrop();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClearCheck()
    {
        GameClearInfo = PlayerPrefs.GetInt("Chap3_stage5", 0);
        if (GameClearInfo == 1)
        {
            dim1.SetActive(false);
            NormalEnding.SetActive(true);
        }


        
    }
    public void CheckDrop()
    {
        for (int Chap = 1; Chap < 4; Chap++)
        {
            for (int Stage = 1; Stage < 6; Stage++)
            {
                string Key = "Chap" + Chap + "_" + "stage" + Stage + "Drop";
                DropInfo = DropInfo + PlayerPrefs.GetInt(Key, 0);

            }
        }

        Debug.Log(DropInfo);

        if (DropInfo > 30)
        {
            dim2.SetActive(false);
            HiddenEnding.SetActive(true);
        }


    }
}
