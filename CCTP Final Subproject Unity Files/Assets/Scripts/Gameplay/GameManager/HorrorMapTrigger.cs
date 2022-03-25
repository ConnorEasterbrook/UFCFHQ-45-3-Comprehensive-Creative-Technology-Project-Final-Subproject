using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HorrorMapTrigger : MonoBehaviour
{
    public Trigger triggerScript;

    // Update is called once per frame
    void Update()
    {
        if (triggerScript.isTriggered && Input.GetKeyDown (KeyCode.W))
        {
            Debug.Log ("Load WhiteRoom");
            LoadNextScene();
        }
    }

    private async void LoadNextScene()
    {
        await Task.Delay (5000);
        SceneManager.LoadScene (2);
    }
}
