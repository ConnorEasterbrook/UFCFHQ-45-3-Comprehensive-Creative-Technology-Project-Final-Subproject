using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    public static bool pausedGame = false;
    public GameObject gameMenuUI;
    public GameObject settingsUI;
    public PlayerController playerScript;
    private float volume;
    private AudioSource music;
    private bool mute;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find ("Audio").GetComponent <AudioSource>() != null) music = GameObject.Find ("Audio").GetComponent <AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown (KeyCode.Escape))
        {
            if (pausedGame)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    private void Pause()
    {
        gameMenuUI.SetActive (true);
        pausedGame = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0.0f;
    }

    private void Resume()
    {
        gameMenuUI.SetActive (false);
        pausedGame = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Time.timeScale = 1.0f;
    }

    public void Continue()
    {
        gameMenuUI.SetActive (false);
        pausedGame = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Time.timeScale = 1.0f;
    }

    public void OpenSettings()
    {
        settingsUI.SetActive (true);
    }

    public void muteSound()
    {
        if (playerScript != null)
        {
            if (playerScript.useSound)
            {
                playerScript.useSound = mute;
                music.volume = 0.00f;

            }
            else
            {
                playerScript.useSound = mute;
                music.volume = volume;
            }
        }
        else
        {
            if (mute)
            {
                mute = false;
                music.volume = 0.00f;
            }
            else
            {
                mute = true;
                music.volume = volume;
            }
        }
    }

    public void SetVolume (float sliderValue)
    {
        volume = 1.0f * sliderValue;

        if (playerScript != null) playerScript.footstepVolume *= sliderValue;

        music.volume = 1.0f * sliderValue;
    }

    public void SetSensitivity (float sliderValue)
    {
        if (playerScript != null) playerScript.mouseSensitivity *= sliderValue;
    }

    public void CloseSettings()
    {
        settingsUI.SetActive (false);
    }

    public void LoadWhiteRoom()
    {
        SceneManager.LoadScene (3);

        gameMenuUI.SetActive (false);
        pausedGame = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Time.timeScale = 1.0f;
    }

    public void ExitGame()
    {
        SceneManager.LoadScene (0);
        
        gameMenuUI.SetActive (false);
        pausedGame = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Time.timeScale = 1.0f;
    }
}
