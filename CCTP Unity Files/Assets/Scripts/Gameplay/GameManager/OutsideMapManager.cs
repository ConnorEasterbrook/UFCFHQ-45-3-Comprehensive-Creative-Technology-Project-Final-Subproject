using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutsideMapManager : MonoBehaviour
{
    public bool playerDetected = false;
    public Trigger progressScene;
    public int result;
    private bool oneTime;

    // Update is called once per frame
    void Update()
    {
        if (playerDetected)
        {
            SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
        }

        if (progressScene != null)
        {
            if (progressScene.isTriggered)
            {
                if (!oneTime && result == 0)
                {
                    SceneManager.LoadScene (2);
                    oneTime = true;
                }
                else if (!oneTime && result != 0)
                {
                    SceneManager.LoadScene (3);
                    oneTime = true;
                }
            }
        }
    }
}
