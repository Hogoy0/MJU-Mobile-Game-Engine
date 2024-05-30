using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    Rigidbody2D rbody;
    public GameObject clonePrefab; // 분열된 캐릭터 프리팹
    private GameObject clone1;
    private GameObject clone2;
    float axisH = 0.0f;
    public float jumpForce = 2.0f; 
    public float maxJumpTime = 0.2f;
    private float jumpTimeCounter;
    private bool isJumping;
    private bool isSplit = false; // 분열인쥐 아닌쥐

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        axisH = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.Q) && !isSplit)
        {
            Split();
        }

        if (Input.GetKeyDown(KeyCode.E) && isSplit)
        {
            Merge();
        }

        if (isJumping)
        {
            if (Input.GetKey(KeyCode.Space) && jumpTimeCounter > 0)
            {
                rbody.velocity = new Vector2(rbody.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
    }

    void FixedUpdate()
    {
        rbody.velocity = new Vector2(axisH * 3.0f, rbody.velocity.y);
    }

    void Jump()
    {
        if (Mathf.Abs(rbody.velocity.y) < 0.001f)
        {
            rbody.velocity = new Vector2(rbody.velocity.x, jumpForce);
            jumpTimeCounter = maxJumpTime;
            isJumping = true;
        }
    }

    void Split()
    {
       
        clone1 = Instantiate(clonePrefab, transform.position + new Vector3(-1.0f, 0.0f, 0.0f), Quaternion.identity);
        clone2 = Instantiate(clonePrefab, transform.position + new Vector3(1.0f, 0.0f, 0.0f), Quaternion.identity);

       
        isSplit = true;

        
        gameObject.SetActive(false);
    }

    void Merge()
    {
        
        if (isSplit)
        {
            // 복제된 캐릭터들 컷컷컷
            Destroy(clone1);
            Destroy(clone2);

            // 분열 상태 해제
            isSplit = false;

            // 현재 캐릭터 활성화 // 아니 이건 왜 안되냐고;;;;
            gameObject.SetActive(true);
        }
    }
}