using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // 문이 움직이는 방향을 설정하는 열거형
    public enum MoveDirection
    {
        Right,
        Left,
        Up,
        Down
    }

    // 문이 움직이는 방향을 설정하는 옵션
    [SerializeField]
    private MoveDirection moveDirection;

    void Start()
    {
        if (o_trigger1 != null)
            Trigger1 = o_trigger1.GetComponent<Lever_and_Button>();
        if (o_trigger2 != null)
            Trigger2 = o_trigger2.GetComponent<Lever_and_Button>();
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Trigger1과 Trigger2가 null이 아닌지 확인
        if ((Trigger1 != null && Trigger1.Active) || (Trigger2 != null && Trigger2.Active))
        {
            MoveDoor(true); // 문을 올림
        }
        else
        {
            MoveDoor(false); // 문을 내림
        }
    }

    void MoveDoor(bool moveUp)
    {
        Vector3 direction;

        if (moveDirection == MoveDirection.Left || moveDirection == MoveDirection.Right)
        {
            direction = (moveDirection == MoveDirection.Left) ? Vector3.left : Vector3.right;
        }
        else
        {
            direction = (moveDirection == MoveDirection.Up) ? Vector3.up : Vector3.down;
        }

        if (moveUp)
        {
            if (Vector3.Distance(transform.position, initialPosition + (direction * maxMove)) > 0.05f)
            {
                transform.Translate(direction * moveSpeed * Time.deltaTime);
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, initialPosition) > 0.05f)
            {
                transform.Translate(-direction * moveSpeed * Time.deltaTime);
            }
        }
    }
}
