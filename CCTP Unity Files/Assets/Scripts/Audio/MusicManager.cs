using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    // Music
    public AudioSource playMusic;
    public AudioClip[] musicTracks;
    public bool oneTime;
    private int oldScene;
    private bool group1;
    private bool group2;
    private bool group3;

    [Space (10)] // Ambience
    public AudioSource playAmbience;

    private void Awake() 
    {
        DontDestroyOnLoad (transform.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        oneTime = false;

        oldScene = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != oldScene)
        {
            oneTime = false;
            oldScene = SceneManager.GetActiveScene().buildIndex; 
        }

        if (Input.GetKeyDown (KeyCode.O))
        {
            SceneManager.LoadScene (4);
        }

        if (!oneTime)
        {
            if (SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 1 || SceneManager.GetActiveScene().buildIndex == 2 || SceneManager.GetActiveScene().buildIndex == 10)
            {
                if (!group1)
                {
                    playMusic.clip = musicTracks [0];
                    playMusic.Play ();
                }

                group1 = true;
                group2 = false;
                group3 = false;
            }
            else if (SceneManager.GetActiveScene().buildIndex == 4 || SceneManager.GetActiveScene().buildIndex == 5 || SceneManager.GetActiveScene().buildIndex == 9)
            {
                if (!group2)
                {
                    playMusic.clip = musicTracks [1];
                    playMusic.Play ();
                }

                group1 = false;
                group2 = true;
                group3 = false;
            }
            else
            {
                if (!group3)
                {
                    playMusic.clip = musicTracks [2];
                    playMusic.Play ();
                }

                group1 = false;
                group2 = false;
                group3 = true;
            }
            
            oneTime = true;
        }
    }
}
