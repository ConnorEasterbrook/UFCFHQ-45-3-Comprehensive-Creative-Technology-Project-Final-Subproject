using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class SimonSaysActivator : MonoBehaviour
{
    // Inspector variables
    [Tooltip ("The layer of the interactible objects.")]
    public LayerMask interactibleLayer;
    public Material baseColour;
    public Material positiveCheck;
    public Material negativeCheck;

    public Renderer[] panelLights;
    private int checkLight = 0;

    private GameObject targetObject; // The transform for the target interactible object
    private Renderer targetObjectRenderer;
    private SimonSays simonSaysScript;
    private SimonSaysButton simonSaysButtonScript;
    private int buttonPressCount = 0;
    private List<int> buttonPressSequence = new List<int>();
    private bool pressCooldown = false;

    // Update is called once per frame
    async void Update()
    {
        if (!pressCooldown)
        {
            // Check for E button press
            if (Input.GetKeyDown (KeyCode.E))
            {
                pressCooldown = true;
                UpdateInput();

                await Task.Delay (500);
                pressCooldown = false;
            }
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
            else if (targetObject.tag == "PuzzlePanel")
            {
                
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
        simonSaysScript.StartOrder();
    }

    void UpdatePanelButton()
    {
        // Get the button renderer
        targetObjectRenderer = targetObject.GetComponent <Renderer>();

        for (int i = 0; i < simonSaysScript.simonButton.Length; i++)
        {
            Debug.Log ("Loop");

            if (targetObject.GetComponent <SimonSaysButton>() == simonSaysScript.simonButton[i])
            {
                buttonPressSequence.Add (i + 1);
            }
        }

        ButtonPressed();
    }

    async void ButtonPressed()
    {
        // Check if pressed button matches the chosen button
        if (buttonPressSequence [buttonPressCount] == simonSaysScript.sequence [buttonPressCount])
        {
            buttonPressCount += 1; // Increase button press count

            targetObjectRenderer.material = positiveCheck;
            ChangeColour(); // Wait before setting colour back to default

            await Task.Delay (1000);
            // Check if the buttonPressCount matches the amount of shown buttons
            if (simonSaysScript.sequence.Count == buttonPressSequence.Count)
            {
                // Select and show random buttons to continue game
                simonSaysScript.SelectRandomButton();
                simonSaysScript.ShowRandomButton();

                // Clear all data for the button presses
                buttonPressSequence.Clear();
                buttonPressCount = 0;

                // Update check light and move on to the next
                panelLights [checkLight].material = positiveCheck;
                checkLight++;
            }
        }
        else
        {
            // Clear all data for the shown button sequence
            simonSaysScript.sequence.Clear();

            // Select and show random buttons to continue game
            simonSaysScript.SelectRandomButton();
            simonSaysScript.ShowRandomButton();

            // Clear all data for the button presses
            buttonPressSequence.Clear();
            buttonPressCount = 0;

            // Clear all data for the check lights
            for (int i = 0; i < panelLights.Length; i++)
            {
                panelLights [i].material = baseColour;
            }
            checkLight = 0;

            // Set incorrect colour to button
            targetObjectRenderer.material = negativeCheck;
            ChangeColour(); // Wait before setting colour back to default
        }
    }

    private async void ChangeColour()
    {
        await Task.Delay (500);
        targetObjectRenderer.material = baseColour;
    }
}
