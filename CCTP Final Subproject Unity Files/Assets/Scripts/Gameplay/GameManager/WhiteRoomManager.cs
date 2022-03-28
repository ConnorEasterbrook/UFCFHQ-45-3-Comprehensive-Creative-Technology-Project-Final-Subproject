using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WhiteRoomManager : MonoBehaviour
{
    public Trigger[] alphaPortal;
    public Trigger[] betaPortal;

    public bool alphaStage = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (alphaStage)
        {
            for (int i = 0; i < alphaPortal.Length; i++)
            {
                if (alphaPortal [i].isTriggered)
                {
                    if (i == 0)
                    {
                        alphaPortal [i].gameObject.SetActive (false);
                        SceneManager.LoadScene (3);
                    }
                    else if (i == 1)
                    {
                        alphaPortal [i].gameObject.SetActive (false);
                        SceneManager.LoadScene (5);
                    }
                    else if (i == 2)
                    {
                        alphaPortal [i].gameObject.SetActive (false);
                        SceneManager.LoadScene (6);
                    }
                    else if (i == 3)
                    {
                        alphaPortal [i].gameObject.SetActive (false);
                        SceneManager.LoadScene (7);
                    }
                    else if (i == 4)
                    {
                        alphaPortal [i].gameObject.SetActive (false);
                        SceneManager.LoadScene (8);
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < betaPortal.Length; i++)
            {
                if (betaPortal [i].isTriggered)
                {
                    if (i == 0)
                    {
                        alphaPortal [i].gameObject.SetActive (false);
                        SceneManager.LoadScene (9);
                    }
                    else if (i == 1)
                    {
                        alphaPortal [i].gameObject.SetActive (false);
                        SceneManager.LoadScene (10);
                    }
                }
            }
        }
    }
}
