using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlatform : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    private Vector3 initialPosition;
    public bool buttonActive = false;
    public float rayDrawX = 0f;
    public float rayDrawY = 0f;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        //Debug.DrawRay(new Vector3(this.transform.position.x - rayDrawX, this.transform.position.y, 0), Vector2.up, new Color(0, 1, 0));
        //Debug.DrawRay(new Vector3(this.transform.position.x, this.transform.position.y + rayDrawY, 0), Vector2.up, new Color(0, 1, 0));
        //Debug.DrawRay(new Vector3(this.transform.position.x + rayDrawX, this.transform.position.y, 0), Vector2.up, new Color(0, 1, 0));
        RaycastHit2D Rayhit1 = Physics2D.Raycast(new Vector3(this.transform.position.x - rayDrawX, this.transform.position.y, 0), Vector2.up, 0.1f, LayerMask.GetMask("Default"));
        RaycastHit2D Rayhit2 = Physics2D.Raycast(new Vector3(this.transform.position.x, this.transform.position.y + rayDrawY, 0), Vector2.up, 0.1f, LayerMask.GetMask("Default"));
        RaycastHit2D Rayhit3 = Physics2D.Raycast(new Vector3(this.transform.position.x + rayDrawX, this.transform.position.y, 0), Vector2.up, 0.1f, LayerMask.GetMask("Default"));

        // 타일 레이어 바꾸기
        // 버튼에 콜라이더 두개 넣기
        // 콜라이더 중 하나는 is trigger 체크

        if (buttonActive)
        {
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        }
        else if (transform.position.y < initialPosition.y && Rayhit1.collider == null && Rayhit2.collider == null && Rayhit3.collider == null)
        {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
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
}