using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleAround : MonoBehaviour
{
    public Transform targetToCircle;
    [Range (1.0f, 15.0f)] public float circleSpeed = 1;
    [Range (0.0f, 5.0f)] public float circleRadius = 1;
    [Range (-10.0f, 10.0f)] public float heightOffset = 0;
    public bool circleAway;
    private Vector3 circleOffset;
    private float degree;

    private void LateUpdate() 
    {
        if (targetToCircle != null)
        {
            if (circleAway)
            {
                circleOffset.Set (Mathf.Cos (degree) * circleRadius, heightOffset, Mathf.Sin (degree) * circleRadius);
                transform.position = targetToCircle.position + circleOffset;
                
                degree += Time.deltaTime * circleSpeed;
            }
            else
            {
                Vector3 positionOffset = CalculateCircling (degree);
                transform.position = targetToCircle.position + positionOffset;
                
                degree += Time.deltaTime * circleSpeed * 10;
            }

            transform.LookAt (targetToCircle.transform.position);
        }

    }

    private Vector3 CalculateCircling (float degreeAngle)
    {
        degreeAngle *= Mathf.Deg2Rad;

        // Calculate the circling position of the target
        Vector3 positionOffset = new Vector3 (Mathf.Cos (degreeAngle) * circleRadius, heightOffset, Mathf.Sin (degreeAngle) * circleRadius);

        // Change the position relevant to the circleTarget's localPosition
        positionOffset = targetToCircle.TransformVector (positionOffset);

        return positionOffset;
    }
}
