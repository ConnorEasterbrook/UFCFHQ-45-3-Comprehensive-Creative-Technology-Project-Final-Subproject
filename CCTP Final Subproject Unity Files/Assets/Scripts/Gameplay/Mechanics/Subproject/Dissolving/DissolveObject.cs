using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveObject : MonoBehaviour
{
    public Transform spiritObject;
    public GameObject lightParent;
    private Vector3 initialScale;
    private Vector3 initialPosition;
    private List <GameObject> lightObjects = new List<GameObject>(); // Keep track of all gameobjects that bring light to the map
    private float scaleMultiplier = 3.5f;
    private bool ranOnce;
    private bool inLight;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3 (transform.position.x, transform.position.y + Random.Range (0.4f, -0.4f), transform.position.z);

        // Get the initial transforms of the dissolvable objects
        initialScale = transform.localScale;
        initialPosition = transform.position;

        // Get each light object in the scene
        foreach (Transform children in lightParent.transform)
        {
            lightObjects.Add (children.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Run this function once
        if (!ranOnce)
        {
            runFunctionOnce();
        }

        // Get the relevant distances
        float distanceFromSpirit = Vector3.Distance (spiritObject.position, transform.position);
        float distanceFromCamera = Vector3.Distance (Camera.main.transform.position, transform.position);

        // If the environment is outside of cameraRange then use spirit code, otherwise set position and scale to default
        if (distanceFromCamera > 5.0f && !inLight)
        {
            // If the environment is within spirit range then manipulate its transform based on the distance
            if (distanceFromSpirit <= 14.0f && distanceFromSpirit > 5.05f)
            {
                // Set scale to vary based on distance
                Vector3 objectScale = initialScale / distanceFromSpirit * scaleMultiplier;
                transform.localScale = objectScale;

                transform.position = new Vector3 (transform.position.x, distanceFromSpirit - 5.0f, transform.position.z);
            }
            else if (distanceFromSpirit > 14.0f)
            {
                // If environment is outside of spirit range and an extra padding range then hide it
                transform.localScale = new Vector3 (0, 0, 0);
            }
            // If the environment is within the padding range then make sure it is set to its default positioning
            else if (distanceFromCamera <= 5.05f && distanceFromCamera > 5.0f)
            {
                transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
            }
            else if (distanceFromSpirit <= 5.0f)
            {
                // Set position and scale to default
                transform.localScale = Vector3.Lerp (transform.localScale, initialScale, Time.deltaTime * scaleMultiplier);

                transform.position = Vector3.Lerp (transform.position, initialPosition, Time.deltaTime * 5.0f);
            }
        }
        else
        {
            // Set position and scale to default
            transform.localScale = Vector3.Lerp (transform.localScale, initialScale, Time.deltaTime * scaleMultiplier);

            transform.position = Vector3.Lerp (transform.position, initialPosition, Time.deltaTime * 5.0f);
        }
    }

    private void runFunctionOnce()
    {
        // Run through every light object in list
        for (int o = 0; o < lightObjects.Count; o++)
        {
            // Establish the transform of the current light object in the list
            Vector3 currentLightObject = lightObjects [o].transform.position;

            // Calculate the distance of light object from environment objects
            float distance = Vector3.Distance (currentLightObject, transform.position);

            if (distance < 4.0f)
            {
                // Set scale and position to the default
                transform.localScale = Vector3.Lerp (transform.localScale, initialScale, Time.deltaTime * scaleMultiplier);

                transform.position = Vector3.Lerp (transform.position, initialPosition, Time.deltaTime * 5.0f);

                // Stop the floor from being affected by the spirit
                inLight = true;
            }
        }

        // Ensure this only runs once
        ranOnce = true;
    }
}
