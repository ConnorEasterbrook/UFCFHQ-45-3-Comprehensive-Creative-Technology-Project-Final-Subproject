using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TargetUI : MonoBehaviour
{
    public Text objectiveText;
    [HideInInspector] public int targetsDestroyed;
    [HideInInspector] public bool endGame;
    private string initialText;

    // Start is called before the first frame update
    void Start()
    {  
       initialText = objectiveText.text; 
    }

    // Update is called once per frame
    void Update()
    {
        objectiveText.text = initialText + "\n Targets destroyed: " + targetsDestroyed + "/3 "; 

        if (targetsDestroyed == 3)
        {
            SceneManager.LoadScene (2);
        }
    }
}
