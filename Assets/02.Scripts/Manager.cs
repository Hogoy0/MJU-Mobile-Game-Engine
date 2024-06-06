using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
// using static UnityEditor.PlayerSettings;

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
    public int DropCounting = 0;
    Vector3 pos;
    Vector3 offset = new Vector3(0.5f, 0f, 0f);

    public AudioSource MurgeSound;
    public AudioSource SplitSound;
    void Start()
    {
        
        select1();
        SelectedSlimeSize = slimelist[0].GetComponent<Character>().SlimeSize;
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
            // ���ο� ���� ������Ʈ ���� ��ġ ���
            Vector3 spawnPosition = new Vector3(spawnX, 0f, 0f);

            // ���ο� ���� ������Ʈ ����
            slimelist[counting] = Instantiate(SlimePrefebList[0], spawnPosition, Quaternion.identity);

            // x ��ǥ ����
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
                SplitSound.Play();
            }
        }
    }

    public void UIButtonMurge()
    {
        CheckSelectedSlimeSize();
        murge();
        MurgeSound.Play();
    }

    public void UIButtonSlimeSelectionChanger()
    {
        int originalIndex = selectedIndex;


        do
        {
            selectedIndex = (selectedIndex + 1) % slimelist.Length;

        }
        while (slimelist[selectedIndex] == null && selectedIndex != originalIndex);


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

    void setseletion() //i��° slimelist�� Null���� ���� Ȯ���ϰ�, �ƴ϶�� i�� playerinput�� ���� ������ Selected�� true ����.
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
        splitcounting += 1; //�п��� �� ���� 1�� ���ϱ�
        pos = slimelist[playerinput].transform.position; //���� ������ �������� ��ġ ����

        if (slimelist[playerinput] != null) //���� ������ ��ȣ�� ������ ����Ʈ�� ������� �ʴٸ�
        {
            Destroy(slimelist[playerinput]); //���� ���� ������ �ı�
            slimelist[playerinput] = null; //�׸��� �ı��� �������� �ִ� ������ �ı�
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
            if (slimelist[i] == null) // �����Ӹ���Ʈ �迭�� 0����3���� ���鼭, ���� ����ִ� �迭�� ã����
            {
                slimelist[i] = Instantiate(CreationSlime, pos - offset, Quaternion.identity);  //�п��ϱ� �� �������� ���� x��ǥ - 1�� ������ ����
                slimelist[i].GetComponent<Character>().ListNumber = i; //�п��� �������� �����Ӹ���Ʈ�� ���° �迭�� ������ ������ ������ ��ũ��Ʈ�� �����س���
                slimelist[i].GetComponent<Character>().SlimeSize = SelectedSlimeSize - 1;
                AutoSelection(i);
                break;                                                 //for�� Ż��
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
            GameObject WillMurgeSlime = slimelist[playerinput].GetComponent<Character>().rayhit.collider.gameObject; // �ε��� ������Ʈ�� ������ �޾ƿ�
            if (SelectedSlimeSize == WillMurgeSlime.GetComponent<Character>().SlimeSize)
            {
                pos = WillMurgeSlime.transform.position + slimelist[playerinput].transform.position; // �����ϴ� �����Ӱ� �ε��� ������ �߰� �Ÿ��� ����ؼ� MiddlePos�� �������
                pos = pos / 2;                                                                               
                int WillDesNum1 = slimelist[playerinput].GetComponent<Character>().ListNumber;          //�÷��̾ �����ϰ� �ִ� �������� �����Ӹ���Ʈ�� ���° �迭�� �� �ִ��� ������ ����
                int WillDesNum2 = WillMurgeSlime.GetComponent<Character>().ListNumber;                  //�÷��̾ �����ϰ� �ִ� �����Ӱ� �ε��� �������� �����Ӹ���Ʈ�� ���° �迭�� �� �ִ��� ������ ����
                Destroy(slimelist[playerinput].GetComponent<Character>().rayhit.collider.gameObject);   //�����ϴ� �����Ӱ� �ε��� ������ �ı�
                slimelist[WillDesNum2] = null;                                                          //��� �ı��� �������� �� �־��� �����Ӹ���Ʈ�� �迭�� null�� �ʱ�ȭ
                Destroy(slimelist[playerinput]);                                                        //�����ϰ� �ִ� ������ �ı�
                slimelist[WillDesNum1] = null;                                                          //�����ϰ� �ִ� �������� �� �־��� �����Ӹ���Ʈ�� �迭�� null�� �ʱ�ȭ
                if (SelectedSlimeSize == 1)
                {
                    MurgeSlimeCreate(SlimePrefebList[1]);

                }
                if (SelectedSlimeSize == 2)
                {
                    MurgeSlimeCreate(SlimePrefebList[0]);

                }

            }


            splitcounting -= 1;
            pos = Vector3.zero; // ������ �ʱ�ȭ
        }
    }
    
    void MurgeSlimeCreate(GameObject CreationSlime)
    {
        for (int i = 0; i < 4; i++)
        {
            if (slimelist[i] == null)
            {
                slimelist[i] = Instantiate(CreationSlime, pos, Quaternion.identity);             //�����Ӹ���Ʈ�� 0���� 3���� ���鼭 null�� �迭�� ������ �� �迭�� MiddlePos ��ǥ�� �� ������ �����ϰ�
                slimelist[i].GetComponent<Character>().ListNumber = i;                         //�� �������� �����Ӹ���Ʈ�� ���° �迭�� ������ ����
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



   


