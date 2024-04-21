using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Character : MonoBehaviour
{
    public float moveSpeed = 5f; // �̵� �ӵ�
    public bool Selected = false;
    Vector2 playerDir;
    Vector3 Rayposition = new Vector3 (2, 0, 0);
    public bool SlimeRaycast = false;
    public RaycastHit2D rayhit;
    public int ListNumber = 10;
    void Start()
    {        
    }
    void Update()
    {
        if (Selected == true)
        {
            Move();
        }
    }

    void FixedUpdate()
    {
        if (Selected == true)
        {
            Debug.DrawRay(transform.position, playerDir * 2, Color.red);
            rayhit = Physics2D.Raycast(transform.position, playerDir, 2, LayerMask.GetMask("Slime"));
            if (rayhit.collider != null)
            {
                Debug.Log("�����Ǵ���");
            }
        }

    }



    void Move()
    {
        // ���� �̵� �Է�
        float moveInput = Input.GetAxis("Horizontal");

        // �̵� ���� ���
        Vector3 movement = new Vector3(moveInput, 0f, 0f) * moveSpeed * Time.deltaTime;

        if(moveInput < 0f)
        {
            playerDir = Vector2.left;
        }

        else if (moveInput > 0f)
        {
            playerDir = Vector2.right;
        }
        // �̵� ����
        transform.Translate(movement);

        
    }
}
