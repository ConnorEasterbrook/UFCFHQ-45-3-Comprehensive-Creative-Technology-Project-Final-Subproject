using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLookAt : MonoBehaviour
{
    public Trigger triggerScript;
    public Transform target;
    public float rotationSpeed = 5.0f;

    private void FixedUpdate() 
    {
        Vector3 lookDirection = target.position - transform.position;

        Quaternion lookAtTarget = Quaternion.LookRotation (lookDirection);

        if (triggerScript.isTriggered)
        {
            transform.rotation = Quaternion.Lerp (transform.rotation, lookAtTarget, rotationSpeed * Time.deltaTime);
        }
    }
}
