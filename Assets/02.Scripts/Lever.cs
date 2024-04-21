using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    private Vector3 initialPosition;
    private Vector3 movedPosition;
    public bool leverActive = false;
    public float rayDrawX = 0f;
    public float rayDrawY = 0f;

    void Start()
    {
        initialPosition = transform.position;
    }
    void Update()
    {
        Debug.DrawRay(new Vector3(this.transform.position.x - 1f, this.transform.position.y + 1f, 0), Vector3.right, new Color(0, 1, 0));
        //RaycastHit2D Rayhit = Physics2D.Raycast(new Vector3(this.transform.position.x - rayDrawX, this.transform.position.y, 0), this.transform.rotation.eulerAngles, 0.1f, LayerMask.GetMask("Default"));

        // 타일 레이어 바꾸기
        // 버튼에 콜라이더 두개 넣기
        // 콜라이더 중 하나는 is trigger 체크

        if (leverActive)
        {
            //transform.Rotate(Vector3.right, 60f * Time.deltaTime);
        }

    }

    /*public float targetZRotation = 45f; // 목표 z 회전값
    public float rotationSpeed = 1f; // 회전 속도

    private Quaternion initialRotation; // 초기 회전값
    private Quaternion targetRotation; // 목표 회전값

    void Start()
    {
        // 초기 회전값 저장
        initialRotation = transform.rotation;

        // 목표 회전값 생성
        Vector3 targetEulerAngles = initialRotation.eulerAngles;
        targetEulerAngles.z = targetZRotation;
        targetRotation = Quaternion.Euler(targetEulerAngles);
    }

    void Update()
    {
        // 회전을 서서히 변경하기 위해 Lerp 사용
        float t = Mathf.PingPong(Time.time * rotationSpeed, 1f); // 회전 속도에 따른 보간값 계산
        transform.rotation = Quaternion.Lerp(initialRotation, targetRotation, t);
    }*/
}
