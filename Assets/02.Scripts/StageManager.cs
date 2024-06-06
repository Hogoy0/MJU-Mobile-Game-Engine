using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // 여기에 추가
using UnityEngine.Windows;


[System.Serializable] //반드시 필요
public class DropObject //행에 해당되는 이름
{
    public GameObject[] Drop;
}

public class StageManager : MonoBehaviour
{
    string CurrentChap;
    string number;
    string Key;
    public Sprite DropOriginal;
    public Sprite DropSprite;
    [SerializeField]
    public GameObject[] dim;
    public DropObject[] DropIndex;


    void Start()
    {
        PlayerPrefs.SetInt("Chap3_stage3Drop", 3);

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
            if (stageClearInfo == 1)
            {
                dim[i].SetActive(false);
            }
        }

        for (int j = 0; j < 5; j++)
        {
            Image Dropimg1 = DropIndex[j].Drop[0].GetComponent<Image>();
            Image Dropimg2 = DropIndex[j].Drop[1].GetComponent<Image>();
            Image Dropimg3 = DropIndex[j].Drop[2].GetComponent<Image>();
            Dropimg1.sprite = DropOriginal;
            Dropimg2.sprite = DropOriginal;
            Dropimg3.sprite = DropOriginal;

            int stagenum = j + 1;

            int stageDropInfo = PlayerPrefs.GetInt(Key + stagenum + "Drop", 0);
            Debug.Log("먹은 눈물 개수는~ " + stageDropInfo);

            if (stageDropInfo == 1)
            {
                Dropimg1.sprite = DropSprite;
                Dropimg2.sprite = DropSprite;
            }
            else if (stageDropInfo == 2)
            {
                Dropimg2.sprite = DropSprite;
                Dropimg2.sprite = DropSprite;
            }
            else if (stageDropInfo == 3)
            {
                Dropimg1.sprite = DropSprite;
                Dropimg2.sprite = DropSprite;
                Dropimg3.sprite = DropSprite;
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
                int PrevChapClearInfo_Drop = PlayerPrefs.GetInt("Chap" + PrevChap + "_stage5" + "Drop");

            }

        }

        
        
    }
}
