using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentAccess : MonoBehaviour
{
    public Trigger triggerScript;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerScript.isTriggered && Input.GetKey (KeyCode.Space) && player.transform.position.y < transform.position.y)
        {
            player.transform.position = new Vector3 (transform.position.x, transform.position.y + 1.0f, transform.position.z);
        }

        if (triggerScript.isTriggered && Input.GetKeyDown (KeyCode.LeftControl) && player.transform.position.y > transform.position.y)
        {
            player.transform.position = new Vector3 (transform.position.x, transform.position.y - 2.0f, transform.position.z);
        }
    }
}
