using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    public Transform target; // 카메라가 추적할 대상
    public GameObject manager;
    public float speed;
    int CameraPlayerInput;

    private void Start()
    {
        speed = 4.0f;
    }
    void LateUpdate()
    {
        CameraPlayerInput = manager.GetComponent<Manager>().playerinput;
        if (manager.GetComponent<Manager>().slimelist[CameraPlayerInput].transform != null)
        {
            target = manager.GetComponent<Manager>().slimelist[CameraPlayerInput].transform;
            transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed);
            transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
        }

      
    }
}
