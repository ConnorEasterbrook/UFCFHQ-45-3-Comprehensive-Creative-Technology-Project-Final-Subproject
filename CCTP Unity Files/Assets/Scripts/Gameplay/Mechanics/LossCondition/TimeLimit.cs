using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeLimit : MonoBehaviour
{
    public Text timerText;
    public float timer = 120;
    private float initialTimer;
    private Color green;
    private Color yellow;
    private Color red;
    
    // Start is called before the first frame update
    void Start()
    {
        initialTimer = timer;

        green = new Color (0.5f, 1.0f, 0.5f);
        yellow = new Color (1.0f, 0.75f, 0.5f);
        red = new Color (1.0f, 0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        float timerRounded = Mathf.Round (timer);

        timerText.text = timerRounded.ToString();

        timerText.color = Color.Lerp (red, green, timer / initialTimer);

        if (timer == 0)
        {
            SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
        }
    }
}
