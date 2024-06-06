using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Door_and_Pump : MonoBehaviour
{
    [SerializeField]
    GameObject o_trigger1;
    [SerializeField]
    GameObject o_trigger2;

    Lever_and_Button Trigger1;
    Lever_and_Button Trigger2;

    [SerializeField]
    private float moveSpeed = 1f;
    [SerializeField]
    float maxMove = 0;
    private Vector3 initialPosition;


    // 움직임 방향 정의
    public enum MoveDirection
    {
        Right,
        Left,
        Up,
        Down
    }

    // 인스펙터 창에서 선택할 수 있는 옵션
    [SerializeField]
    private MoveDirection moveDirection;

    void Start()
    {
        Trigger1 = o_trigger1.GetComponent<Lever_and_Button>();
        Trigger2 = o_trigger2.GetComponent<Lever_and_Button>();

        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        if (moveDirection == MoveDirection.Left)
        {
            if (Trigger1.Active || Trigger2.Active)
            {
                if (transform.position.x > initialPosition.x - maxMove)
                {
                    position.x -= moveSpeed * Time.deltaTime;
                }
            }
            else if (transform.position.x < initialPosition.x)
            {
                position.x += moveSpeed * Time.deltaTime;
            }
        }
        else if (moveDirection == MoveDirection.Right)
        {
            if (Trigger1.Active || Trigger2.Active)
            {
                if (transform.position.x < initialPosition.x + maxMove)
                {
                    position.x += moveSpeed * Time.deltaTime;
                }
            }
            else if (transform.position.x > initialPosition.x)
            {
                position.x -= moveSpeed * Time.deltaTime;
            }
        }
        else if (moveDirection == MoveDirection.Down)
        {
            if (Trigger1.Active || Trigger2.Active)
            {
                if (transform.position.y > initialPosition.y - maxMove)
                {
                    position.y -= moveSpeed * Time.deltaTime;
                }
            }
            else if (transform.position.y < initialPosition.y)
            {
                position.y += moveSpeed * Time.deltaTime;
            }
        }
        else if (moveDirection == MoveDirection.Up)
        {
            if (Trigger1.Active || Trigger2.Active)
            {
                if (transform.position.y < initialPosition.y + maxMove)
                {
                    position.y += moveSpeed * Time.deltaTime;

                }
            }
            else if (transform.position.y > initialPosition.y)
            {
                position.y -= moveSpeed * Time.deltaTime;
            }
        }
        transform.position = position;
    }
}
