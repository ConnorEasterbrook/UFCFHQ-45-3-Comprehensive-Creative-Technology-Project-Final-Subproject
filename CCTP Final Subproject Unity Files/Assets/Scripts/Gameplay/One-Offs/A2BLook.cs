using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A2BLook : MonoBehaviour
{
    public GameObject lookPoint;
    private Quaternion lookStartPoint;
    private Quaternion lookPointRot;
    public float rotationSpeed = 5.0f;

    public bool atPointB;

    // Start is called before the first frame update
    void Start()
    {
        lookStartPoint = transform.rotation;
        lookPointRot = Quaternion.LookRotation (lookPoint.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (!atPointB)
        {
            transform.rotation = Quaternion.Lerp (transform.rotation, lookPointRot, rotationSpeed * Time.deltaTime);

            Debug.Log (Quaternion.Dot(transform.rotation, lookPointRot));

            if (Quaternion.Dot(transform.rotation, lookPointRot) == -1f)
            {
                atPointB = true;
            }
        }
        else
        {
            transform.rotation = Quaternion.Lerp (transform.rotation, lookStartPoint, rotationSpeed * Time.deltaTime);

            if (transform.rotation == lookStartPoint)
            {
                atPointB = false;
            }
        }
    }
}
