using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyIfTouched : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            other.gameObject.SetActive (false);
        }
    }
}
