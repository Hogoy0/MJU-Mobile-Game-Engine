using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    private Vector3 initialRotation;
    private Vector3 movedRotation;
    public bool leverActive = false;
    Rigidbody2D rigidbody = null;

    void Start()
    {
        rigidbody= GetComponent<Rigidbody2D>();
        initialRotation = transform.eulerAngles;
        // �ݶ��̴� �ΰ� �ְ� �ϳ��� is trigger üũ
    }
    void Update()
    {
        movedRotation = transform.eulerAngles;
        float interval = Mathf.Abs(initialRotation.z - movedRotation.z);

        if (interval >= 70 && leverActive == false)
        {
            leverActive = true;
            Debug.Log("���� Ȱ��ȭ");
        }
        else if (interval <= 20 && leverActive == true)
        {
            leverActive = false;
            Debug.Log("���� ��Ȱ��ȭ");
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        string objectName = other.gameObject.name;
        int otherLastInt = int.Parse(objectName[objectName.Length - 1].ToString());
        int myLastInt = int.Parse(this.name[this.name.Length - 1].ToString());

        if (otherLastInt <= myLastInt)
        {
            rigidbody.constraints = RigidbodyConstraints2D.None;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        string objectName = other.gameObject.name;
        int otherLastInt = int.Parse(objectName[objectName.Length - 1].ToString());
        int myLastInt = int.Parse(this.name[this.name.Length - 1].ToString());

        if (otherLastInt <= myLastInt)
        {
            rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
 