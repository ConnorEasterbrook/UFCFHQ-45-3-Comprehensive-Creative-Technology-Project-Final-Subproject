using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HorrorMapTrigger : MonoBehaviour
{
    public Trigger triggerScript;
    public int result;
    private bool oneTime;

    // Update is called once per frame
    void Update()
    {
        if (triggerScript.isTriggered && Input.GetKeyDown (KeyCode.W) && result == 0)
        {
            LoadNextScene (5000, 2);
        }

        if (triggerScript.isTriggered && result == 1)
        {
            LoadNextScene (15000, 4);
        }
    }

    private async void LoadNextScene (int timer, int scene)
    {
        await Task.Delay (timer);
        if (!oneTime)
        {
            SceneManager.LoadScene (scene);
            oneTime = true;
        }
    }
}
