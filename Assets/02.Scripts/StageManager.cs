using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;

public class StageManager : MonoBehaviour
{
    string CurrentChap;
    string number;
    string Key;
    [SerializeField]
    private GameObject[] dim;


    void Start()
    {
        PlayerPrefs.SetInt("Chap2_stage5", 1);

        CurrentChap = SceneManager.GetActiveScene().name;
        number = Regex.Match(CurrentChap, @"\d+").Value;
        Debug.Log(number);
        Key = "Chap" + number + "_stage";
        Debug.Log(Key);

        CheckPreviousChap();

        for (int i = 1; i < 5; i++)
        {
            int stageNum = i;
            Debug.Log(stageNum);
            Debug.Log(Key + stageNum);
            int stageClearInfo = PlayerPrefs.GetInt(Key + stageNum, 0);
            Debug.Log(stageClearInfo);
            if (stageClearInfo == 1)
            {
                dim[i].SetActive(false);
            }
        }



    }


    void CheckPreviousChap()
    {
        int PrevChap = int.Parse(number);
        PrevChap -= 1;

        if(PrevChap != 0)
        {
            int PrevChapClearInfo = PlayerPrefs.GetInt("Chap" + PrevChap + "_stage5", 0);
            if (PrevChapClearInfo == 1)
            {
                dim[0].SetActive(false);
            }

        }

        
        
    }
}
