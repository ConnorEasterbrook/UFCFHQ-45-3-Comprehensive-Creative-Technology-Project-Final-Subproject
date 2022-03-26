using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveObject : MonoBehaviour
{
    public Transform spiritObject;
    public Vector3 initialScale;
    public Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        initialScale = transform.localScale;
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float scaleMultiplier = 3.5f;

        float distanceFromSpirit = Vector3.Distance (spiritObject.position, transform.position);
        float distanceFromCamera = Vector3.Distance (Camera.main.transform.position, transform.position);

        if (distanceFromCamera > 5.0f)
        {
            if (distanceFromSpirit <= 14.0f && distanceFromSpirit > 5.0f)
            {
                // Set scale to vary based on distance. Below sets the height based on distance
                Vector3 objectScale = initialScale / distanceFromSpirit * scaleMultiplier;

                transform.localScale = objectScale;
            }
            else if (distanceFromSpirit > 14.0f && distanceFromCamera > 5.05f)
            {
                transform.localScale = new Vector3 (0, 0, 0);
            }

            if (distanceFromCamera <= 5.05f)
            {
                transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3 (transform.position.x, distanceFromSpirit - 5.0f, transform.position.z);
            }
        }
        else
        {

            transform.localScale = Vector3.Lerp (transform.localScale, initialScale, Time.deltaTime * scaleMultiplier);

            transform.position = Vector3.Lerp (transform.position, initialPosition, Time.deltaTime * 5.0f);
        }
    }
}
