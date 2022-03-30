using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A2BPatrol : MonoBehaviour
{
    public GameObject patrolPoint;
    private Vector3 patrolStartPoint;
    public float rotationSpeed = 5.0f;
    public float patrolSpeed = 2.5f;

    private bool atPointB;

    // Start is called before the first frame update
    void Start()
    {
        patrolStartPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!atPointB)
        {
            Vector3 lookDirection = patrolPoint.transform.position - transform.position;

            Quaternion lookAtTarget = Quaternion.LookRotation (lookDirection);

            transform.rotation = Quaternion.Lerp (transform.rotation, lookAtTarget, rotationSpeed * Time.deltaTime);

            transform.position = Vector3.MoveTowards (transform.position, patrolPoint.transform.position, patrolSpeed * Time.deltaTime);
        }
        else
        {
            Vector3 lookDirection = patrolStartPoint - transform.position;

            Quaternion lookAtTarget = Quaternion.LookRotation (lookDirection);

            transform.rotation = Quaternion.Lerp (transform.rotation, lookAtTarget, rotationSpeed * Time.deltaTime);

            transform.position = Vector3.MoveTowards (transform.position, patrolStartPoint, patrolSpeed * Time.deltaTime);
        }

        if (transform.position == patrolPoint.transform.position)
        {
            atPointB = true;
        }

        if (transform.position == patrolStartPoint)
        {
            atPointB = false;
        }
        
    }
}
