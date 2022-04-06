using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    private bool oneTime;
    private float fallSpeed = 1.0f;
    private Vector3 fallPoint;

    // Start is called before the first frame update
    void Start()
    {
        fallPoint = new Vector3 (transform.position.x, transform.position.y - 20, transform.position.z);
        fallPoint = fallPoint + -Vector3.up * 20.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (oneTime)
        {
            FallAndDeactivate();
        }
    }

    private async void OnCollisionExit(Collision other) 
    {
        if (other.gameObject.tag == "Player")
        {
            await Task.Delay (500);
            oneTime = true;
        }
    }

    private async void FallAndDeactivate()
    {
        transform.position = Vector3.Lerp (transform.position, fallPoint, fallSpeed * Time.deltaTime);

        await Task.Delay (3000);
        oneTime = false;
        gameObject.SetActive(false);
    }
}
