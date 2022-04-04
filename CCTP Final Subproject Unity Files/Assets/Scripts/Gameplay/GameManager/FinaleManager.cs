using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinaleManager : MonoBehaviour
{
    public float completedPuzzles;
    public PlayerController playerScript;
    public Text objectiveText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (completedPuzzles == 2)
        {
            playerScript.insideSphere = true;
        }
        else if (completedPuzzles == 5)
        {
            SceneManager.LoadScene (0);
        }

        objectiveText.text = "Explore and solve the Simon Says Puzzles. Puzzles solved: " + completedPuzzles + " / 5";
    }
}
