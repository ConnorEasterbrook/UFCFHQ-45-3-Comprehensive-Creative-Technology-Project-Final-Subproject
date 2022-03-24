using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSaysButton : MonoBehaviour
{
    [HideInInspector] public bool buttonPressed;
    [HideInInspector] public bool correctButton;

    Material mat;
   
    private void Start()
    { 
        mat = GetComponent<Renderer>().material;
    }

    public IEnumerator Blink(float color,float onTime)//change color value of the buttons so they flash
    {
        yield return new WaitForEndOfFrame();//for fixing an reference error
        mat.color = Color.HSVToRGB(color, 1f, 1f);
        yield return new WaitForSeconds(onTime);
        mat.color = Color.HSVToRGB(color, 1f, 0.55f);
    }
}
