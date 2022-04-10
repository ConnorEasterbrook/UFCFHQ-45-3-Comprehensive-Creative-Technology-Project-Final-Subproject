using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EToInteract : MonoBehaviour
{
    [Tooltip ("0=Temp Text... 1=LoadWhiteScene... 2=ReloadScene")]
    public int desiredResult = 0;
    public string tempTextString;
    public Text tempText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance (transform.position, Camera.main.transform.position);

        if (Input.GetKeyDown (KeyCode.E) && distanceToPlayer < 3.0f)
        {
            if (desiredResult == 0)
            {
                TempShowText();
            }
            else if (desiredResult == 1)
            {
                SceneManager.LoadScene (3);
            }
            else if (desiredResult == 2)
            {
                SceneManager.LoadScene (5);
            }
        }
    }

    private async void TempShowText()
    {
        if (tempText != null)
        {
            tempText.text = tempTextString;
            tempText.gameObject.SetActive (true);

            await Task.Delay (5000);
            tempText.gameObject.SetActive (false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere (transform.position, 3.0f);
    }
}
