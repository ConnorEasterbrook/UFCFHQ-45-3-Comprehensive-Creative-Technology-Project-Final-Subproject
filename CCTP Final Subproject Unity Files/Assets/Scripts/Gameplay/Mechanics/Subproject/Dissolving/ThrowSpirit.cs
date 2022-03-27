using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSpirit : MonoBehaviour
{
    public Transform target;
    public float spiritSpeed = 8.0f;
    private float floatSpeed = 8f;
    public bool flying = false;
    private bool check;
    private Vector3 finalPosition;

    private void Update() 
    {
        if (Input.GetMouseButtonDown (1))
        {
            flying = true;
            check = true;
        }

        Vector3 forwardOffset = Camera.main.transform.forward * 1.5f;
        Vector3 rightOffset = Camera.main.transform.right * 1.0f;
        Vector3 upOffset = Camera.main.transform.up * 0.5f;

        finalPosition = Camera.main.transform.position + forwardOffset + rightOffset + upOffset;

        if (check == true)
        {
            target.position = Camera.main.transform.position + (Camera.main.transform.forward * 20.0f);

            check = false;
        }
    }

    // Update is called once per frame.
    void FixedUpdate()
    {
        if (flying)
        {
            if (transform.position != target.position)
            {
                transform.position = Vector3.MoveTowards (transform.position, target.position, floatSpeed * Time.fixedDeltaTime);
            }
            else
            {
                flying = false;
            }
        }

        if (!flying)
        {
            transform.rotation = Camera.main.transform.rotation;

            transform.position = Vector3.Lerp
            (
                transform.position,
                finalPosition, 
                Time.deltaTime * floatSpeed
            );
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        Debug.Log ("dfsknmf");
        flying = false;
    }
}
