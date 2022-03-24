using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSaysActivator : MonoBehaviour
{
    public Material BaseColour;
    public Material showColour;
    public Material positiveCheck;
    public Material negativeCheck;

    private GameObject targetObject; // The transform for the target interactible object
    private Renderer targetObjectRenderer;
    private SimonSays simonSaysScript;
    private SimonSaysButton simonSaysButtonScript;

    // Inspector variables
    [Tooltip ("The layer of the interactible objects.")]
    public LayerMask interactibleLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check for E button press
        if (Input.GetKeyDown (KeyCode.E))
        {
            UpdateInput();
        }
    }

    void UpdateInput()
    {
        // Raycast onto interactible layer
        RaycastHit hitObject;

        if (Physics.Raycast (transform.position, transform.forward, out hitObject, 5.0f, interactibleLayer))
        {
            // Set target object to hit object
            targetObject = hitObject.transform.gameObject;

            if (targetObject.tag == "PuzzlePanel")
            {
                UpdatePuzzlePanel();
            }
            else
            {
                UpdatePanelButton();
            }
        }
    }

    void UpdatePuzzlePanel()
    {   
        // Disable panel collider to avoid further raycast hits
        Collider panelCollider = targetObject.GetComponent <BoxCollider>();
        panelCollider.enabled = false;

        // Begin SimonSays game
        simonSaysScript = targetObject.GetComponent <SimonSays>();
        simonSaysScript.beginGame = true;
    }

    void UpdatePanelButton()
    {
        // Get the button script
        simonSaysButtonScript = targetObject.GetComponent <SimonSaysButton>();
        simonSaysButtonScript.buttonPressed = true;

        // Get the button renderer
        targetObjectRenderer = targetObject.GetComponent <Renderer>();

        if (simonSaysButtonScript.correctButton)
        {
            targetObjectRenderer.material = positiveCheck;
        }
        else
        {
            targetObjectRenderer.material = negativeCheck;
        }
    }
}
