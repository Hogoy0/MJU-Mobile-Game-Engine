using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFlatform2 : MonoBehaviour
{
    public Transform startPos;
    public Transform endPos;
    public Transform desPos;
    public float speed;
    private bool isActive = false; // 활성화 상태를 나타내는 변수

    [SerializeField]
    GameObject o_trigger;
    Lever_and_Button Trigger;

    void Start()
    {
        transform.position = startPos.position;
        desPos = endPos;
        Trigger = o_trigger.GetComponent<Lever_and_Button>();
    }

    void FixedUpdate()
    {
        if (!isActive) return; // 비활성화 상태이면 업데이트하지 않음

        transform.position = Vector2.MoveTowards(transform.position, desPos.position, Time.deltaTime * speed);
        if (Vector2.Distance(transform.position, desPos.position) <= 0.05f)
        {
            desPos = desPos == endPos ? startPos : endPos;
        }
    }

    void Update()
    {
        if (Trigger != null && Trigger.Active)
        {
            ActivatePlatform();
        }
    }

    public void ActivatePlatform()
    {
        isActive = true; // 플랫폼 활성화
    }
}
