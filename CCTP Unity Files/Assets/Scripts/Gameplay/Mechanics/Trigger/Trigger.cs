using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public bool isTriggered = false;
    public int result = 0;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player" || other.tag == "TriggerIt")
        {
            isTriggered = true;
            if (result == 0) gameObject.SetActive (false);
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.tag == "Player" || other.tag == "TriggerIt")
        {
            isTriggered = false;
        }
    }
}
