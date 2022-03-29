using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class AngleToSphere : MonoBehaviour
{
    public GameObject planetGameObject;
    public bool SphereMove;
    public bool isModel;
    public bool swapSide;

    private float yDistance;

    private void Start() 
    {
        SphereMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt (planetGameObject.transform);

        if (!isModel)
        {
            transform.Rotate (-90, 0, 0);
        }
        else if (isModel)
        {
            transform.Rotate (180, 0, 0);
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
