using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacement : MonoBehaviour
{
    public bool randomRotate;
    public bool modelOffset;
    private bool oneTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!oneTime)
        {
            if (randomRotate)
            {
                float randomRotation = Random.Range (0, 180);

                if (modelOffset)
                {
                    transform.Rotate(transform.localRotation.x, transform.localRotation.y, transform.localRotation.z + randomRotation);
                }
                else
                {
                    transform.Rotate(transform.localRotation.x, transform.localRotation.y + randomRotation, transform.localRotation.z);
                }  
            }

            oneTime = true;
        }
    }
}
