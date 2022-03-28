using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SphericalExplorationManager : MonoBehaviour
{
    public List <Trigger> triggerObjectives;
    private int objectives = 0;
    
    private bool oneTime;
    public string tempTextString_1;
    public string tempTextString_2;
    public string tempTextString_3;
    public Text tempText;

    // Update is called once per frame.
    void Update()
    {
        for (int i = 0; i < triggerObjectives.Count; i++)
        {
            if (triggerObjectives [i].isTriggered)
            {
                objectives++;

                triggerObjectives.Remove (triggerObjectives [i]);
            }
        }

        if (objectives == triggerObjectives.Count)
        {
            LoadNextScene();
        }

        if (!oneTime)
        {
            TempShowText();
        }

        if (Input.GetKeyDown (KeyCode.P) && oneTime == true)
        {
            oneTime = false;
        }
    }

    private async void LoadNextScene()
    {
        await Task.Delay (5000);
        SceneManager.LoadScene (2);
    }

    private async void TempShowText()
    {
        if (tempText != null)
        {
            oneTime = true;
            
            tempText.gameObject.SetActive (true);

            tempText.text = tempTextString_1;
            await Task.Delay (5000);

            tempText.text = tempTextString_2;
            await Task.Delay (5000);

            tempText.text = tempTextString_3;
            await Task.Delay (5000);

            tempText.gameObject.SetActive (false);

        }
    }
}
