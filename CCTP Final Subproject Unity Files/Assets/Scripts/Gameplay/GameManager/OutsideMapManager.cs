using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutsideMapManager : MonoBehaviour
{
    public bool playerDetected = false;
    public Trigger progressScene;

    // Update is called once per frame
    void Update()
    {
        if (playerDetected)
        {
            SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
        }

        if (progressScene.isTriggered)
        {
            SceneManager.LoadScene (2);
        }
    }
}
