using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SphericalExplorationManager : MonoBehaviour
{
    public List <Trigger> triggerObjectives;
    public Text objectiveText;
    private int objectives = 0;
    
    private bool oneTime2;

    // Update is called once per frame.
    void Update()
    {
        for (int i = 0; i < triggerObjectives.Count; i++)
        {
            if (triggerObjectives [i].isTriggered)
            {
                objectives++;
                triggerObjectives [i].gameObject.SetActive (false);
            }
        }

        if (objectives == triggerObjectives.Count)
        {
            LoadNextScene();
        }

        objectiveText.text = "Explore the planet and find the warp shards... They're smoking skulls? Shards found: " + objectives + " / " + triggerObjectives.Count;
    }

    private async void LoadNextScene()
    {
        await Task.Delay (5000);
        if (!oneTime2)
        {
            SceneManager.LoadScene (3);
            oneTime2 = true;
        }
    }
}
