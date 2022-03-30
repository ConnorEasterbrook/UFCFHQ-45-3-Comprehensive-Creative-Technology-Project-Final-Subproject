using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Jumpscare : MonoBehaviour
{
    public Trigger triggerScript;
    public Image scareImage;
    private bool oneTime;

    // Update is called once per frame
    void Update()
    {  
        if (triggerScript.isTriggered && !oneTime)
        {
            JumpScare();
        }
        
    }

    private async void JumpScare()
    {
        oneTime = true;
            
        scareImage.gameObject.SetActive (true);

        await Task.Delay (1000);

        scareImage.gameObject.SetActive (false);
    }
}
