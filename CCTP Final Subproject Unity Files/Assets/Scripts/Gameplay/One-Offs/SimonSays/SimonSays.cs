using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSays : MonoBehaviour
{
    [Tooltip ("How many buttons to start with.")]
    public int startButtonCount = 1; //start with 1 buttons
    public SimonSaysButton[] simonButton; //objects containing the LightUp script.
    public bool beginGame;
    public List<int> sequence = new List<int>(); //list of chosen buttons in order

    // Update is called once per frame
    void Update()
    {
        if (beginGame == true)
        {
            Debug.Log ("DEBUG");

            StartCoroutine (StartOrder());
            beginGame = false;
        }
    }

    public IEnumerator StartOrder()//choose first 2 buttons
    {    
        for (int i = 0; i < startButtonCount; i++)
        {
            ChooseButton();
        }

        yield return new WaitForSeconds(1f);

        StartCoroutine (ShowOrder());
    }   

    public void ChooseButton()//choose a random button
    {
        float buttonSelect = Random.Range(0, simonButton.Length); 

        if (buttonSelect == 0)
        {
            sequence.Add (1);
        }

        if (buttonSelect == 1)
        {
            sequence.Add (2);
        }

        if (buttonSelect == 2)
        {
            sequence.Add (3);
        }

        if (buttonSelect == 3)
        {
            sequence.Add (4);
        }
    }

    public IEnumerator ShowOrder()//blink the buttons in order
    {
        for (int i = 0; i < sequence.Count; i++)
        {
            yield return new WaitForSeconds(1f);

            if (sequence[i] == 1)
            {
                //red 0.01f
                StartCoroutine (simonButton [0].Blink (0.01f, 0.6f));
            }
            if (sequence[i] == 2)
            {
                //green 0.41f
                StartCoroutine (simonButton [1].Blink (0.41f, 0.6f));
            }
            if (sequence[i] == 3)
            {
                //blue 0.66f
                StartCoroutine (simonButton [2].Blink (0.66f, 0.6f));
            }
            if (sequence[i] == 4)
            {
                //yellow 0.16f
                StartCoroutine (simonButton [3].Blink (0.16f, 0.6f));
            }        
        }
    }
}
