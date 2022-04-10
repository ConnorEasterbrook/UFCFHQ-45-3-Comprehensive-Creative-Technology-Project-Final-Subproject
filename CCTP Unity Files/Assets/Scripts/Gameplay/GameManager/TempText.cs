using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TempText : MonoBehaviour
{
    private bool oneTime;
    public string tempTextString_1;
    public string tempTextString_2;
    public string tempTextString_3;
    public Text tempText;
    public GameObject textPanel;

    public bool whiteRoom;

    // Start is called before the first frame update
    void Start()
    {
        if (oneTime)
        {
            textPanel.gameObject.SetActive (false);
            tempText.gameObject.SetActive (false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!oneTime)
        {
            TempShowText();
        }

        if (Input.GetKeyDown (KeyCode.P) && oneTime == true)
        {
            oneTime = false;
        }

        if (Input.GetKeyDown (KeyCode.LeftControl) && !whiteRoom)
        {
            SceneManager.LoadScene (3);
        }
    }

    private async void TempShowText()
    {
        if (tempText != null)
        {
            oneTime = true;
            textPanel.gameObject.SetActive (true);
            tempText.gameObject.SetActive (true);

            tempText.text = tempTextString_1;
            await Task.Delay (7000);

            tempText.text = tempTextString_2;
            await Task.Delay (7000);

            tempText.text = tempTextString_3;
            await Task.Delay (7000);

            textPanel.gameObject.SetActive (false);
            tempText.gameObject.SetActive (false);
        }
    }
}
