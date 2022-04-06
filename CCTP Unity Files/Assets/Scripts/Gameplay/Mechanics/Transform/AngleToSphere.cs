using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class AngleToSphere : MonoBehaviour
{
    public bool isCamera;
    public GameObject planetGameObject;
    public bool SphereMove;
    public bool isModel;
    public bool swapSide;
    public bool rotate180;

    private float yDistance;

    private void Start() 
    {
        if (!isCamera)
        {
            SphereMove = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt (planetGameObject.transform);

        if (!isModel && !rotate180)
        {
            transform.Rotate (-90, 0, 0);
        }
        else if (isModel && rotate180)
        {
            transform.Rotate (0, 0, 0);
        }
        else if (isModel && !rotate180)
        {
            transform.Rotate (180, 0, 0);
        }
        else if (rotate180 && !isModel)
        {
            transform.Rotate (90, 180, 0);
        }

        if (SphereMove)
        {
            transform.position = (transform.position - planetGameObject.transform.position).normalized * yDistance + planetGameObject.transform.position;
        }

        yDistance = Vector3.Distance (transform.position, planetGameObject.transform.position);

        if (swapSide)
        {
            if (isModel)
            {
                float desiredOffset = transform.position.z * 2;
                transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z - desiredOffset);

                swapSide = false;
            }
            else
            {
                float desiredOffset = transform.position.y * 2;
                transform.position = new Vector3 (transform.position.x, transform.position.y - desiredOffset, transform.position.z);

                swapSide = false;
            }  
        }
    }
}
