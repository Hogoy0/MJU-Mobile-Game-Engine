using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever_and_Button : MonoBehaviour
{
    public bool Active = false;

    //레버
    private Vector3 initialRotation;
    private Vector3 movedRotation;
    Rigidbody2D rigidbody = null;

    //버튼
    private Vector3 initialPosition;
    [SerializeField]
    float maxMove = 0;
    [SerializeField]
    GameObject o_ButtonPlatform;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name.StartsWith("L"))
        {
            rigidbody = GetComponent<Rigidbody2D>();
            initialRotation = transform.eulerAngles;
            // 콜라이더 두개 넣고 하나는 is trigger 체크
        }
        else if (gameObject.name.StartsWith("B"))
        {
            initialPosition = o_ButtonPlatform.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name.StartsWith("L"))
        {
            movedRotation = transform.eulerAngles;
            float interval = Mathf.Abs(initialRotation.z - movedRotation.z);

            if (interval >= 70 && Active == false)
            {
                Active = true;
            }
            else if (interval <= 20 && Active == true)
            {
                Active = false;
            }
        }
        else if (gameObject.name.StartsWith("B"))
        {
            if (Active && o_ButtonPlatform.transform.position.y >= initialPosition.y - maxMove)
            {
                ButtonMoveDown();
            }
            else if (o_ButtonPlatform.transform.position.y < initialPosition.y)
            {
                ButtonMoveUp();
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        string objectName = other.gameObject.name.Replace("(Clone)", "").Trim();



        int otherLastInt = int.Parse(objectName[objectName.Length - 1].ToString());
        int myLastInt = int.Parse(this.name[this.name.Length - 1].ToString());

        if (otherLastInt <= myLastInt)
        {
            if (gameObject.name.StartsWith("L"))
            {
                rigidbody.constraints = RigidbodyConstraints2D.None;
            }
            else if (gameObject.name.StartsWith("B"))
            {
                Active = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        string objectName = other.gameObject.name.Replace("(Clone)", "").Trim();
        int otherLastInt = int.Parse(objectName[objectName.Length - 1].ToString());
        int myLastInt = int.Parse(this.name[this.name.Length - 1].ToString());

        if (otherLastInt <= myLastInt)
        {
            if (gameObject.name.StartsWith("L"))
            {
                rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
            else if (gameObject.name.StartsWith("B"))
            {
                Active = false;
            }
        }
    }

    void ButtonMoveDown()
    {
        o_ButtonPlatform.transform.Translate(Vector3.down * 0.6f * Time.deltaTime);
    }

    void ButtonMoveUp()
    {
        o_ButtonPlatform.transform.Translate(Vector3.up * 0.6f * Time.deltaTime);
    }
}
