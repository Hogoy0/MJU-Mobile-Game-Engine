using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPump : MonoBehaviour
{
    [SerializeField]
    GameObject o_Button_1;

    ButtonPlatform Button;
    private Vector3 initialPosition;
    private float moveSpeed = 0.5f;

    void Start()
    {
        Button = o_Button_1.GetComponent<ButtonPlatform>();
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Button.buttonActive && transform.position.y < -2)
        {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
        else if (transform.position.y > initialPosition.y)
        {
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        }
    }
}
