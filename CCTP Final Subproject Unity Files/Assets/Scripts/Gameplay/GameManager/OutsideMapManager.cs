using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutsideMapManager : MonoBehaviour
{
    public bool playerDetected = false;
    public Trigger progressScene;
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
                if (!oneTime)
                {
                    SceneManager.LoadScene (1);
                    oneTime = true;
                }
            }
        }
    }
}
