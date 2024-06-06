using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindTrigger2 : MonoBehaviour
{

    public GameObject WindObject;

    [SerializeField]
    GameObject o_trigger;
    Lever_and_Button Trigger;

    // Start is called before the first frame update
    void Start()
    {
        Trigger = o_trigger.GetComponent<Lever_and_Button>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Trigger.Active)
        {
            WindObject.SetActive(false);
        }
        else
        {
            WindObject.SetActive(true);
        }
    }
}
