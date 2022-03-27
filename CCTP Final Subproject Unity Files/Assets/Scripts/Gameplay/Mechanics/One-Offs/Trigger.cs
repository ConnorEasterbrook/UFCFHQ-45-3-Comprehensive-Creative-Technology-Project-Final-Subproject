using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public bool isTriggered = false;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player" || other.tag == "TriggerIt")
        {
            isTriggered = true;
            gameObject.SetActive (false);
        }
    }
}
