using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_and_Pump : MonoBehaviour
{
    [SerializeField]
    GameObject o_trigger;
    Lever_and_Button Trigger;

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
        Trigger = o_trigger.GetComponent<Lever_and_Button>();
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveDirection == MoveDirection.Left)
        {
            if (Trigger.Active && transform.position.x > initialPosition.x - maxMove)
            {
                transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            }
            else if (transform.position.x < initialPosition.x)
            {
                transform.Translate(Vector3.left * moveSpeed * Time.deltaTime * -1);
            }
        }
        else if (moveDirection == MoveDirection.Right)
        {
            if (Trigger.Active && transform.position.x < initialPosition.x + maxMove)
            {
                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            }
            else if (transform.position.x > initialPosition.x)
            {
                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime * -1);
            }
        }
        else if (moveDirection == MoveDirection.Down)
        {
            if (Trigger.Active && transform.position.y > initialPosition.y - maxMove)
            {
                transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
            }
            else if (transform.position.y < initialPosition.y)
            {
                transform.Translate(Vector3.down * moveSpeed * Time.deltaTime * -1);
            }
        }
        else if (moveDirection == MoveDirection.Up)
        {
            if (Trigger.Active && transform.position.y < initialPosition.y + maxMove)
            {
                transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
            }
            else if (transform.position.y > initialPosition.y)
            {
                transform.Translate(Vector3.up * moveSpeed * Time.deltaTime * -1);
            }
        }

    }
}
