using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Manager : MonoBehaviour
{
    public GameObject[] slimelist;
    public GameObject slime;
    public GameObject[] SlimePrefebList;
    float spawnX = -4f;
    public int counting = 0;
    public int playerinput = 0;
    public int splitcounting = 0;
    void Start()
    {
        SlimePrefebList = new GameObject[3];
        slimelist = new GameObject[4];
        spawn();
        select1();

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
            if (splitcounting < 3)
            {
                Split();
            }

        }

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
            slimelist[counting] = Instantiate(slime, spawnPosition, Quaternion.identity);

            // x ��ǥ ����
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
        Vector3 pos; 
        Vector3 offset = new Vector3(1f, 0f, 0f);
        pos = slimelist[playerinput].transform.position; //���� ������ �������� ��ġ ����
        if (slimelist[playerinput] != null) //���� ������ ��ȣ�� ������ ����Ʈ�� ������� �ʴٸ�
        {
            Destroy(slimelist[playerinput]); //���� �� ������ �ı�
            slimelist[playerinput] = null; //�׸��� �ı��� �������� �ִ� ������ �ı�
        }
        for (int i = 0; i < 4; i++)
        {
            if (slimelist[i] == null)
            {
                slimelist[i] = Instantiate(slime, pos - offset, Quaternion.identity);
                slimelist[i].GetComponent<Character>().ListNumber = i; 
                break;
            }
        }
        for (int i = 0; i < 4; i++)
        {
            if (slimelist[i] == null)
            {
                slimelist[i] = Instantiate(slime, pos + offset, Quaternion.identity);
                slimelist[i].GetComponent<Character>().ListNumber = i;
                break;
            }
        }
    }
    
    void murge()
    {
        if (slimelist[playerinput].GetComponent<Character>().rayhit.collider != null)   
        {
            GameObject WillMurgeSlime = slimelist[playerinput].GetComponent<Character>().rayhit.collider.gameObject; // �ε��� ������Ʈ�� ������ �޾ƿ�
            Vector3 MiddlePos = WillMurgeSlime.transform.position + slimelist[playerinput].transform.position; // �����ϴ� �����Ӱ� �ε��� ������ �߰� �Ÿ��� ����ؼ� MiddlePos�� �������
            MiddlePos = MiddlePos / 2;
            Debug.Log(MiddlePos);                                                                                   
            int WillDesNum1 = slimelist[playerinput].GetComponent<Character>().ListNumber;          //�÷��̾ �����ϰ� �ִ� �������� �����Ӹ���Ʈ�� ���° �迭�� �� �ִ��� ������ ����
            int WillDesNum2 = WillMurgeSlime.GetComponent<Character>().ListNumber;                  //�÷��̾ �����ϰ� �ִ� �����Ӱ� �ε��� �������� �����Ӹ���Ʈ�� ���° �迭�� �� �ִ��� ������ ����
            Destroy(slimelist[playerinput].GetComponent<Character>().rayhit.collider.gameObject);   //�����ϴ� �����Ӱ� �ε��� ������ �ı�
            slimelist[WillDesNum2] = null;                                                          //��� �ı��� �������� �� �־��� �����Ӹ���Ʈ�� �迭�� null�� �ʱ�ȭ
            Destroy(slimelist[playerinput]);                                                        //�����ϰ� �ִ� ������ �ı�
            slimelist[WillDesNum1] = null;                                                          //�����ϰ� �ִ� �������� �� �־��� �����Ӹ���Ʈ�� �迭�� null�� �ʱ�ȭ

            for (int i = 0; i < 4; i++)
            {
                if (slimelist[i] == null)
                {
                    slimelist[i] = Instantiate(slime, MiddlePos, Quaternion.identity);             //�����Ӹ���Ʈ�� 0���� 3���� ���鼭 null�� �迭�� ������ �� �迭�� MiddlePos ��ǥ�� �� ������ �����ϰ�
                    slimelist[i].GetComponent<Character>().ListNumber = i;                         //�� �������� �����Ӹ���Ʈ�� ���° �迭�� ������ ����
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
}

   


