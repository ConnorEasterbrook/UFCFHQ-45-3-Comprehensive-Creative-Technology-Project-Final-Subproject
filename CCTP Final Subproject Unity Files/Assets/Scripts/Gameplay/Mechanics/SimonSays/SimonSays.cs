using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimonSays : MonoBehaviour
{
    [Tooltip ("How many buttons to start with.")]
    public int startButtonCount = 1; //start with 1 buttons
    public SimonSaysButton[] simonButton; //objects containing the LightUp script.
    public Renderer[] panelLights;
    public int checkLight = 0;
    public List <int> sequence = new List <int>(); //list of chosen buttons in order
    public int desiredResult = 1;

    public async void StartOrder()//choose first 2 buttons
    {    
        for (int i = 0; i < startButtonCount; i++)
        {
            SelectRandomButton();
        }

        await Task.Delay (1000);

        ShowRandomButton();
    } 

    public void SelectRandomButton()
    {
        float buttonSelect = Random.Range (0, simonButton.Length);

        int select = (int)buttonSelect;

        sequence.Add (select + 1);
    }

    public async void ShowRandomButton()
    {
        for (int i = 0; i < sequence.Count; i++)
        {
            await Task.Delay (1000);

            int sequenceNumber = sequence [i] - 1;
            simonButton [sequenceNumber].ChangeColour();
        }
    }

    public async void SimonSaysResult (int resultOption)
    {
        await Task.Delay (1000);

        if (resultOption == 0)
        {
            SceneManager.LoadScene (1);
        }
        else
        {
            return;
        }
    }
}
