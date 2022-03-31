using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WhiteRoomManager : MonoBehaviour
{
    public Trigger[] alphaPortal;
    public Trigger[] betaPortal;
    public Trigger finalPortal;

    public bool alphaStage = true;
    private static int portalsComplete;
    private bool finalStage;

    private static bool[] alphaPortalUsed = {false, false, false, false, false};
    private static bool[] betaPortalUsed = {false, false};


    // Update is called once per frame
    async void Update()
    {
        if (!finalStage)
        {
            for (int i = 0; i < alphaPortal.Length; i++)
            {
                if (alphaPortal [i].isTriggered)
                {
                    if (i == 0)
                    {
                        SceneManager.LoadScene (4);
                        portalsComplete++;
                    }
                    else if (i == 1)
                    {
                        SceneManager.LoadScene (6);
                        portalsComplete++;
                    }
                    else if (i == 2)
                    {
                        SceneManager.LoadScene (7);
                        portalsComplete++;
                    }
                    else if (i == 3)
                    {
                        SceneManager.LoadScene (8);
                        portalsComplete++;
                    }
                    else if (i == 4)
                    {
                        SceneManager.LoadScene (9);
                        portalsComplete++;
                    }

                    await Task.Delay (500);
                    alphaPortalUsed [i] = true;
                }
                else if (alphaPortalUsed [i] == true)
                {
                    alphaPortal [i].gameObject.SetActive (false);
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
                        SceneManager.LoadScene (10);
                        portalsComplete++;
                    }
                    else if (i == 1)
                    {
                        SceneManager.LoadScene (11);
                        portalsComplete++;
                    }

                    await Task.Delay (500);
                    betaPortalUsed [i] = true;
                }
                else if (betaPortalUsed [i] == true)
                {
                    betaPortal [i].gameObject.SetActive (false);
                }
            }
        }

        if (portalsComplete == 7)
        {
            finalStage = true;
        }

        if (finalStage && finalPortal.isTriggered)
        {
            SceneManager.LoadScene (12);
        }
    }
}
