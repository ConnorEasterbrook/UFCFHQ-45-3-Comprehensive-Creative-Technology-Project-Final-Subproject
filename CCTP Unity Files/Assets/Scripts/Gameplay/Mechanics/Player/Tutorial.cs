using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public Image wKey;
    public Image aKey;
    public Image sKey;
    public Image dKey;
    public Image spaceKey;
    public Image lShiftKey;

    public Trigger tutTrigger;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey (KeyCode.W))
        {
            wKey.color = new Color (0.5f, 0.5f, 0.5f);
        }
        else
        {
            wKey.color = new Color (1.0f, 1.0f, 1.0f);
        }

        if (Input.GetKey (KeyCode.A))
        {
            aKey.color = new Color (0.5f, 0.5f, 0.5f);
        }
        else
        {
            aKey.color = new Color (1.0f, 1.0f, 1.0f);
        }

        if (Input.GetKey (KeyCode.S))
        {
            sKey.color = new Color (0.5f, 0.5f, 0.5f);
        }
        else
        {
            sKey.color = new Color (1.0f, 1.0f, 1.0f);
        }

        if (Input.GetKey (KeyCode.D))
        {
            dKey.color = new Color (0.5f, 0.5f, 0.5f);
        }
        else
        {
            dKey.color = new Color (1.0f, 1.0f, 1.0f);
        }

        if (Input.GetKey (KeyCode.Space))
        {
            spaceKey.color = new Color (0.5f, 0.5f, 0.5f);
        }
        else
        {
            spaceKey.color = new Color (1.0f, 1.0f, 1.0f);
        }

        if (Input.GetKey (KeyCode.LeftShift))
        {
            lShiftKey.color = new Color (0.5f, 0.5f, 0.5f);
        }
        else
        {
            lShiftKey.color = new Color (1.0f, 1.0f, 1.0f);
        }

        if (tutTrigger.isTriggered)
        {
            gameObject.SetActive (false);
        }
    }
}
