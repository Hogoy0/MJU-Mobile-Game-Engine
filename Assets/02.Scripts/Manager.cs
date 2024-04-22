using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Manager : MonoBehaviour
{
    public GameObject[] slimelist = new GameObject[4];
    public GameObject slime;
    public GameObject[] SlimePrefebList = new GameObject[3];
    float spawnX = -4f;
    public int counting = 0;
    public int playerinput = 0;
    public int splitcounting = 0;
    int SelectedSlimeSize = 0;
    Vector3 pos;
    Vector3 offset = new Vector3(1f, 0f, 0f);
    void Start()
    {
        spawn();
        select1();
        slimelist[0].GetComponent<Character>().SlimeSize = 3;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.J))
        {
            pung();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            murge();
        } 
        

        if (Input.GetKeyDown(KeyCode.T))
        {
            spawn();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (splitcounting < 3 && playerinput < 5)
            {
                CheckSplitSlimeSize();
                Split();
            }

        }

        CheckPlyaerSelectInput();

    }

    void CheckPlyaerSelectInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            select1();
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            select2();
        }

        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            select3();
        }

        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            select4();
        }

    }

    void spawn()
    {
        if (counting < 4)
        {
            // 새로운 게임 오브젝트 생성 위치 계산
            Vector3 spawnPosition = new Vector3(spawnX, 0f, 0f);

            // 새로운 게임 오브젝트 생성
            slimelist[counting] = Instantiate(SlimePrefebList[0], spawnPosition, Quaternion.identity);

            // x 좌표 증가
            spawnX += 4f;
            counting += 1;
        }


    }



    void select1()
    {
        playerinput = 0;
        if (slimelist[0] != null)
        {
            setseletion();
        }

    }

    void select2()
    {
        playerinput = 1;
        if (slimelist[1] != null)
        {
            setseletion();
        }

    }

    void select3()
    {
        playerinput = 2;
        if (slimelist[2] != null)
        {
            setseletion();
        }
    }

    void select4()
    {
        playerinput = 3;
        if (slimelist[3] != null)
        {
            setseletion();
        }
    }

    void setseletion() //i번째 slimelist가 Null인지 먼저 확인하고, 아니라면 i와 playerinput과 비교해 같으면 Selected에 true 대입.
    {
        for (int i = 0; i < 4; i++)
        {
            if (slimelist[i] != null)
            {
                if (i == playerinput)
                {
                    slimelist[i].GetComponent<Character>().Selected = true;
                    slimelist[i].gameObject.layer = 6;
                }
                else 
                { 
                    slimelist[i].GetComponent<Character>().Selected = false;
                    slimelist[i].gameObject.layer = 7;
                }
            }
        }
    }
    void Split()
    {
        splitcounting += 1; //분열할 때 마다 1씩 더하기
        Vector3 pos; 
        Vector3 offset = new Vector3(1f, 0f, 0f);
        pos = slimelist[playerinput].transform.position; //현재 선택한 슬라임의 위치 저장

        if (slimelist[playerinput] != null) //만약 선택한 번호의 슬라임 리스트가 비어있지 않다면
        {
            Destroy(slimelist[playerinput]); //현재 고른 슬라임 파괴
            slimelist[playerinput] = null; //그리고 파괴한 슬라임이 있던 프리펩 파괴
        }

        if (SelectedSlimeSize == 3)
        {
            SplitSlimeCreate(SlimePrefebList[1]);
        }
        if (SelectedSlimeSize == 2)
        {
            SplitSlimeCreate(SlimePrefebList[2]);
        }
        playerinput = 5;
        

    }

    void SplitSlimeCreate(GameObject CreationSlime)
    {
        for (int i = 0; i < 4; i++)
        {
            if (slimelist[i] == null) // 슬라임리스트 배열을 0부터3까지 돌면서, 만약 비어있는 배열을 찾으면
            {
                slimelist[i] = Instantiate(CreationSlime, pos - offset, Quaternion.identity);  //분열하기 전 슬라임의 왼쪽 x좌표 - 1에 슬라임 생성
                slimelist[i].GetComponent<Character>().ListNumber = i; //분열한 슬라임이 슬라임리스트의 몇번째 배열이 들어갔는지 슬라임 프리펩 스크립트에 저장해놓음
                slimelist[i].GetComponent<Character>().SlimeSize = SelectedSlimeSize - 1;
                break;                                                 //for문 탈출
            }
        }
        for (int i = 0; i < 4; i++)
        {
            if (slimelist[i] == null)
            {
                slimelist[i] = Instantiate(CreationSlime, pos + offset, Quaternion.identity);
                slimelist[i].GetComponent<Character>().ListNumber = i;
                slimelist[i].GetComponent<Character>().SlimeSize = SelectedSlimeSize - 1;
                break;
            }
        }
    }

    
    
    void murge()
    {
        if (slimelist[playerinput].GetComponent<Character>().rayhit.collider != null)   
        {
            GameObject WillMurgeSlime = slimelist[playerinput].GetComponent<Character>().rayhit.collider.gameObject; // 부딪힌 오브젝트의 정보를 받아옴
            Vector3 MiddlePos = WillMurgeSlime.transform.position + slimelist[playerinput].transform.position; // 조종하는 슬라임과 부딪힌 슬라임 중간 거리를 계산해서 MiddlePos에 집어넣음
            MiddlePos = MiddlePos / 2;
            Debug.Log(MiddlePos);                                                                                   
            int WillDesNum1 = slimelist[playerinput].GetComponent<Character>().ListNumber;          //플레이어가 조종하고 있는 슬라임이 슬라임리스트의 몇번째 배열에 들어가 있는지 정보를 저장
            int WillDesNum2 = WillMurgeSlime.GetComponent<Character>().ListNumber;                  //플레이어가 조종하고 있는 슬라임과 부딪힌 슬라임이 슬라임리스트의 몇번째 배열에 들어가 있는지 정보를 저장
            Destroy(slimelist[playerinput].GetComponent<Character>().rayhit.collider.gameObject);   //조종하는 슬라임과 부딪힌 슬라임 파괴
            slimelist[WillDesNum2] = null;                                                          //방금 파괴한 슬라임이 들어가 있었던 슬라임리스트의 배열을 null로 초기화
            Destroy(slimelist[playerinput]);                                                        //조종하고 있는 슬라임 파괴
            slimelist[WillDesNum1] = null;                                                          //조종하고 있던 슬라임이 들어가 있었던 슬라임리스트의 배열을 null로 초기화

            for (int i = 0; i < 4; i++)
            {
                if (slimelist[i] == null)
                {
                    slimelist[i] = Instantiate(slime, MiddlePos, Quaternion.identity);             //슬라임리스트를 0부터 3까지 돌면서 null인 배열이 있으면 그 배열에 MiddlePos 좌표로 새 슬라임 생성하고
                    slimelist[i].GetComponent<Character>().ListNumber = i;                         //그 슬라임이 슬라임리스트의 몇번째 배열에 들어갔는지 저장
                    break;
                }
            }
            splitcounting -= 1;
        }

        
    }
    
    void pung()
    {
        Destroy(slimelist[playerinput]);
    }

    void CheckSplitSlimeSize()
    {
        SelectedSlimeSize = slimelist[playerinput].GetComponent<Character>().SlimeSize;
    }
}

   


