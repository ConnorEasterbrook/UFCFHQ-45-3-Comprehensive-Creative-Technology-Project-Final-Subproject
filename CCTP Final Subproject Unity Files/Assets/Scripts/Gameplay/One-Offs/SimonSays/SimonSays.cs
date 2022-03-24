using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class SimonSays : MonoBehaviour
{
    [Tooltip ("How many buttons to start with.")]
    public int startButtonCount = 1; //start with 1 buttons
    public SimonSaysButton[] simonButton; //objects containing the LightUp script.
    public List <int> sequence = new List <int>(); //list of chosen buttons in order

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

        // if (buttonSelect == 0)
        // {
        //     sequence.Add (1);
        // }
        // else if (buttonSelect == 1)
        // {
        //     sequence.Add (2);
        // }
        // else if (buttonSelect == 2)
        // {
        //     sequence.Add (3);
        // }
        // else if (buttonSelect == 3)
        // {
        //     sequence.Add (4);
        // }
        // else if (buttonSelect == 4)
        // {
        //     sequence.Add (5);
        // }
        // else if (buttonSelect == 5)
        // {
        //     sequence.Add (6);
        // }
        // else if (buttonSelect == 6)
        // {
        //     sequence.Add (7);
        // }
        // else if (buttonSelect == 7)
        // {
        //     sequence.Add (8);
        // }
        // else if (buttonSelect == 8)
        // {
        //     sequence.Add (9);
        // }
        // else
        // {
        //     sequence.Add (9);
        // }
    }

    public async void ShowRandomButton()
    {
        for (int i = 0; i < sequence.Count; i++)
        {
            await Task.Delay (1000);

            int sequenceNumber = sequence [i] - 1;
            simonButton [sequenceNumber].ChangeColour();
            
            // if (sequenceNumber == 1)
            // {
            //     simonButton [0].ChangeColour();
            // }
            // else if (sequenceNumber == 2)
            // {
            //     simonButton [1].ChangeColour();
            // }
            // else if (sequenceNumber == 3)
            // {
            //     simonButton [2].ChangeColour();
            // }
            // else if (sequenceNumber == 4)
            // {
            //     simonButton [3].ChangeColour();
            // }  
            // else if (sequenceNumber == 5)
            // {
            //     simonButton [4].ChangeColour();
            // }  
            // else if (sequenceNumber == 6)
            // {
            //     simonButton [5].ChangeColour();
            // }  
            // else if (sequenceNumber == 7)
            // {
            //    simonButton [6].ChangeColour();
            // }        
            // else if (sequenceNumber == 8)
            // {
            //    simonButton [7].ChangeColour();
            // }  
            // else if (sequenceNumber == 9)
            // {
            //     simonButton [8].ChangeColour();
            // }  
            // else
            // {
            //     simonButton [8].ChangeColour();
            // }
        }
    }
}
