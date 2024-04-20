using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMoving : MonoBehaviour
{
    public Transform target; // 카메라가 추적할 대상
    public float speed;

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime*speed);
        transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
      
    }
}
