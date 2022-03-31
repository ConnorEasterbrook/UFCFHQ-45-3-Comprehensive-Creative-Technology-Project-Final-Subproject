using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InnerSphereManager : MonoBehaviour
{
    private bool oneTime2;
    public TempText tempTextScript;
    private Text tempText;

    [Space (10)]
    public PlayerController playerScript;
    public Vector2 decreaseIncreaseView;
    public Trigger[] decreaseViewTrigger;
    public Trigger[] increaseViewTrigger;
    private float lerpSpeed = 5.0f;

    [Space (10)]
    public Trigger[] objectives;

    private void Awake() 
    {
        tempText = tempTextScript.tempText;
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < objectives.Length; i++)
        {
            if (i > 0)
            {
                objectives [i].gameObject.SetActive (false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < decreaseViewTrigger.Length; i++)
        {
            if (decreaseViewTrigger [i].isTriggered)
            {
                playerScript.insideSphereRadius = Mathf.Lerp (playerScript.insideSphereRadius, decreaseIncreaseView.x, Time.deltaTime * lerpSpeed);
            }
        }

        for (int i = 0; i < increaseViewTrigger.Length; i++)
        {
            if (increaseViewTrigger [i].isTriggered)
            {
                playerScript.insideSphereRadius = Mathf.Lerp (playerScript.insideSphereRadius, decreaseIncreaseView.y, Time.deltaTime * lerpSpeed);
            }
        }

        for (int i = 0; i < objectives.Length; i++)
        {
            if (objectives [i].isTriggered)
            {
                Objectives (i);
            }
        }
    }

    private async void Objectives (int triggeredObjective)
    {
        if (triggeredObjective == 0)
        {
            tempText.gameObject.SetActive (true);
            
            tempText.text = "It is I, the mystical plant pot. I'm owed some money by that gravestone fellow. Go find him for me.";
            await Task.Delay (7500);

            objectives [triggeredObjective + 1].gameObject.SetActive (true);
            tempText.gameObject.SetActive (false);
        }
        else if (triggeredObjective == 1)
        {
            tempText.gameObject.SetActive (true);
            
            tempText.text = "Ah... I know I owe planty some money but I was recently mugged by the big tree. Not these small ones around you. He's huge."; 
            await Task.Delay (7500);

            objectives [triggeredObjective + 1].gameObject.SetActive (true);
            tempText.gameObject.SetActive (false);
        }
        else if (triggeredObjective == 2)
        {
            tempText.gameObject.SetActive (true);
            
            tempText.text = "Gravestone... Lying... Shelves.. Know..."; 
            await Task.Delay (7500);

            objectives [triggeredObjective + 1].gameObject.SetActive (true);
            tempText.gameObject.SetActive (false);
        }
        else if (triggeredObjective == 3)
        {
            tempText.gameObject.SetActive (true);
            
            tempText.text = "The big guy said what now? Nah, that's a lie. Time for you to go now. Go on. Scoot."; 
            await Task.Delay (7500);

            if (!oneTime2) 
            {
                SceneManager.LoadScene (3);
                oneTime2 = true;
            }

            objectives [triggeredObjective].gameObject.SetActive (false);
        }
    }
}
