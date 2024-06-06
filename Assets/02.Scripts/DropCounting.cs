using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCounting : MonoBehaviour
{

    public GameObject EscapeDoor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable()
    {
        
        Debug.Log("´«¹° ¸Ô¾ú´ç");
        EscapeDoor.GetComponent<EscapeDoor>().DropCounting += 1;
        
    }
}
