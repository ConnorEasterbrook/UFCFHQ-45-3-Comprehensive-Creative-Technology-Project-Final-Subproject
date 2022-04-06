using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public bool reverse;

    // Update is called once per frame
    void Update()
    {
        if (!reverse)
        {
            transform.Rotate (5 * Time.deltaTime, 20 * Time.deltaTime, 0);
        }
        else
        {
            transform.Rotate (-5 * Time.deltaTime, -20 * Time.deltaTime, 0);
        }
    }
}
