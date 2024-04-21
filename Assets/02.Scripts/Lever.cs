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

        // Ÿ�� ���̾� �ٲٱ�
        // ��ư�� �ݶ��̴� �ΰ� �ֱ�
        // �ݶ��̴� �� �ϳ��� is trigger üũ

        if (leverActive)
        {
            //transform.Rotate(Vector3.right, 60f * Time.deltaTime);
        }

    }

    /*public float targetZRotation = 45f; // ��ǥ z ȸ����
    public float rotationSpeed = 1f; // ȸ�� �ӵ�

    private Quaternion initialRotation; // �ʱ� ȸ����
    private Quaternion targetRotation; // ��ǥ ȸ����

    void Start()
    {
        // �ʱ� ȸ���� ����
        initialRotation = transform.rotation;

        // ��ǥ ȸ���� ����
        Vector3 targetEulerAngles = initialRotation.eulerAngles;
        targetEulerAngles.z = targetZRotation;
        targetRotation = Quaternion.Euler(targetEulerAngles);
    }

    void Update()
    {
        // ȸ���� ������ �����ϱ� ���� Lerp ���
        float t = Mathf.PingPong(Time.time * rotationSpeed, 1f); // ȸ�� �ӵ��� ���� ������ ���
        transform.rotation = Quaternion.Lerp(initialRotation, targetRotation, t);
    }*/
}
