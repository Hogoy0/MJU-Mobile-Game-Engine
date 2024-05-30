using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlatform : MonoBehaviour
{
    private float moveSpeed = 0.5f;
    private Vector3 initialPosition;
    public bool buttonActive = false;

    [SerializeField]
    float maxMove = 0;

    [SerializeField]
    GameObject o_ButtonPlatform;

    void Start()
    {
        initialPosition = o_ButtonPlatform.transform.position;
    }

    void Update()
    {

        if (buttonActive && o_ButtonPlatform.transform.position.y >= -maxMove)
        {
            ButtonMoveDown();
        }
        else if (o_ButtonPlatform.transform.position.y < initialPosition.y)
        {
            ButtonMoveUp();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        string objectName = other.gameObject.name;
        int otherLastInt = int.Parse(objectName[objectName.Length - 1].ToString());
        int myLastInt = int.Parse(this.name[this.name.Length - 1].ToString());

        if (otherLastInt <= myLastInt)
        {
            buttonActive = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        string objectName = other.gameObject.name;
        int otherLastInt = int.Parse(objectName[objectName.Length - 1].ToString());
        int myLastInt = int.Parse(this.name[this.name.Length - 1].ToString());

        if (otherLastInt <= myLastInt)
        {
            buttonActive = false;
        }
    }

    void ButtonMoveDown()
    {
        o_ButtonPlatform.transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
    }

    void ButtonMoveUp()
    {
        o_ButtonPlatform.transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
    }
}