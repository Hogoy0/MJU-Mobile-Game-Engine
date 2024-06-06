using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatDrop : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D Collision)
    {
        string objectName = Collision.gameObject.name;
        string myName = this.name.Replace("(Clone)", "").Trim();
        int otherLastInt = int.Parse(objectName[objectName.Length - 1].ToString());
        int myLastInt = int.Parse(myName[myName.Length - 1].ToString());

        if (Collision.gameObject.tag == "Drop")
        {
            if (otherLastInt == myLastInt)
            {
                Collision.gameObject.SetActive(false);
            }
        }
    }
}
