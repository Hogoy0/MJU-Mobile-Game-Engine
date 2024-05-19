using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using static UnityEditor.PlayerSettings;

public class Manager : MonoBehaviour
{
    public GameObject[] slimelist = new GameObject[4];
    public GameObject slime;
    public GameObject[] SlimePrefebList = new GameObject[3];
    private Character UICharacterController;
    float spawnX = -4f;
    public int counting = 0;
    public int playerinput = 0;
    public int splitcounting = 0;
    public int SelectedSlimeSize = 0;
    public int selectedIndex = 0;
    Vector3 pos;
    Vector3 offset = new Vector3(1f, 0f, 0f);
    void Start()
    {
        spawn();
        select1();
        slimelist[0].GetComponent<Character>().SlimeSize = 3;
        UICharacterController = slimelist[0].GetComponent<Character>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.J))
        {
            CheckSelectedSlimeSize();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            CheckSelectedSlimeSize();
            murge();
        } 
        

        if (Input.GetKeyDown(KeyCode.T))
        {
            spawn();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            CheckSelectedSlimeSize();
            if (splitcounting < 3 && playerinput < 5)
            {
                if(SelectedSlimeSize > 1)
                {
                    Split();
                }
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

    public void UIButtonLeftmove()
    {
        UICharacterController.MoveLeft = true;
    }

    public void UIButtonLeftmoveEnd()
    {
        UICharacterController.MoveLeft = false;
    }

    public void UIButtonRightmove()
    {
        UICharacterController.MoveRight = true;
    }
    public void UIButtonRightmoveEnd()
    {
        UICharacterController.MoveRight = false;
    }

    public void UIButtonJump()
    {
        UICharacterController.UIJump();
    }


    public void UIButtonSplit()
    {
        CheckSelectedSlimeSize();
        if (splitcounting < 3 && playerinput < 5)
        {
            if (SelectedSlimeSize > 1)
            {
                Split();
            }
        }
    }

    public void UIButtonMurge()
    {
        CheckSelectedSlimeSize();
        murge();
    }

    public void UIButtonSlimeSelectionChanger()
    {
        int originalIndex = selectedIndex;

        // 다음 인덱스를 찾음
        do
        {
            selectedIndex = (selectedIndex + 1) % slimelist.Length;
            Debug.Log(slimelist.Length);
        }
        while (slimelist[selectedIndex] == null && selectedIndex != originalIndex);

        // 다음 캐릭터 선택
        if (slimelist[selectedIndex] != null)
        {
            SelectCharacter(selectedIndex);


        }
    }

    void SelectCharacter(int index)
    {

        if (index == 0)
        {
            select1();
            UICharacterController = slimelist[0].GetComponent<Character>();
        }

        else if (index == 1)
        {
            select2();
            UICharacterController = slimelist[1].GetComponent<Character>();
        }
        else if (index == 2)
        {
            select3();
            UICharacterController = slimelist[2].GetComponent<Character>();
        }
        else if (index == 3)
        {
            select4();
            UICharacterController = slimelist[3].GetComponent<Character>();
        }

    }






    void select1()
    {
        playerinput = 0;
        selectedIndex = 0;
        if (slimelist[0] != null)
        {
            setseletion();
        }

    }

    void select2()
    {
        playerinput = 1;
        selectedIndex = 1;
        if (slimelist[1] != null)
        {
            setseletion();
        }

    }

    void select3()
    {
        playerinput = 2;
        selectedIndex = 2;

        if (slimelist[2] != null)
        {
            setseletion();
        }
    }

    void select4()
    {
        playerinput = 3;
        selectedIndex = 3;

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
                AutoSelection(i);
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
                slimelist[i].gameObject.layer = 7;
                break;
            }
        }
    }

    void AutoSelection(int WillSelectNumber)
    {
        if (WillSelectNumber == 0)
        {
            select1();
            UICharacterController = slimelist[0].GetComponent<Character>();
        }
        else if (WillSelectNumber == 1)
        {
            select2();
            UICharacterController = slimelist[1].GetComponent<Character>();
        }
        else if (WillSelectNumber == 2)
        {
            select3();
            UICharacterController = slimelist[2].GetComponent<Character>();
        }
        else if (WillSelectNumber == 3)
        {
            select4();
            UICharacterController = slimelist[3].GetComponent<Character>();
        }
        selectedIndex = WillSelectNumber;
    }
    
    
    void murge()
    {
        if (slimelist[playerinput].GetComponent<Character>().rayhit.collider != null)   
        {
            Debug.Log("합체!!");
            GameObject WillMurgeSlime = slimelist[playerinput].GetComponent<Character>().rayhit.collider.gameObject; // 부딪힌 오브젝트의 정보를 받아옴
            if (SelectedSlimeSize == WillMurgeSlime.GetComponent<Character>().SlimeSize)
            {
                Debug.Log(WillMurgeSlime.GetComponent<Character>().SlimeSize);
                pos = WillMurgeSlime.transform.position + slimelist[playerinput].transform.position; // 조종하는 슬라임과 부딪힌 슬라임 중간 거리를 계산해서 MiddlePos에 집어넣음
                pos = pos / 2;
                Debug.Log(pos);                                                                                   
                int WillDesNum1 = slimelist[playerinput].GetComponent<Character>().ListNumber;          //플레이어가 조종하고 있는 슬라임이 슬라임리스트의 몇번째 배열에 들어가 있는지 정보를 저장
                int WillDesNum2 = WillMurgeSlime.GetComponent<Character>().ListNumber;                  //플레이어가 조종하고 있는 슬라임과 부딪힌 슬라임이 슬라임리스트의 몇번째 배열에 들어가 있는지 정보를 저장
                Destroy(slimelist[playerinput].GetComponent<Character>().rayhit.collider.gameObject);   //조종하는 슬라임과 부딪힌 슬라임 파괴
                slimelist[WillDesNum2] = null;                                                          //방금 파괴한 슬라임이 들어가 있었던 슬라임리스트의 배열을 null로 초기화
                Destroy(slimelist[playerinput]);                                                        //조종하고 있는 슬라임 파괴
                slimelist[WillDesNum1] = null;                                                          //조종하고 있던 슬라임이 들어가 있었던 슬라임리스트의 배열을 null로 초기화
                Debug.Log("합치기 전 selectedslimesize값");
                Debug.Log(SelectedSlimeSize);
                if (SelectedSlimeSize == 1)
                {
                    MurgeSlimeCreate(SlimePrefebList[1]);
                    Debug.Log("제일 작은 슬라임 합쳐짐");
                    Debug.Log(SelectedSlimeSize);
                }
                if (SelectedSlimeSize == 2)
                {
                    MurgeSlimeCreate(SlimePrefebList[0]);
                    Debug.Log("중간 슬라임 합쳐짐");
                    Debug.Log(SelectedSlimeSize);
                }

            }


            splitcounting -= 1;
            pos = Vector3.zero; // 변수들 초기화
        }
    }
    
    void MurgeSlimeCreate(GameObject CreationSlime)
    {
        for (int i = 0; i < 4; i++)
        {
            if (slimelist[i] == null)
            {
                slimelist[i] = Instantiate(CreationSlime, pos, Quaternion.identity);             //슬라임리스트를 0부터 3까지 돌면서 null인 배열이 있으면 그 배열에 MiddlePos 좌표로 새 슬라임 생성하고
                slimelist[i].GetComponent<Character>().ListNumber = i;                         //그 슬라임이 슬라임리스트의 몇번째 배열에 들어갔는지 저장
                slimelist[i].GetComponent<Character>().SlimeSize = SelectedSlimeSize + 1;
                AutoSelection(i);
                break;
            }
        }
    }

    void pung()
    {
        Destroy(slimelist[playerinput]);
    }

    void CheckSelectedSlimeSize()
    {
        SelectedSlimeSize = slimelist[playerinput].GetComponent<Character>().SlimeSize;
    }


    

}



   


