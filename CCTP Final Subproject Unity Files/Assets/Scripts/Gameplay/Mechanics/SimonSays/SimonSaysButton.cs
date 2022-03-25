using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class SimonSaysButton : MonoBehaviour
{
    [HideInInspector] public bool correctButton;
    private Renderer buttonRenderer;

    public Material baseColour;
    public Material showColour;
   
    private void Awake()
    { 
        buttonRenderer = GetComponent<Renderer>();
    }

    public async void ChangeColour()
    {
        await Task.Delay (1000);
        buttonRenderer.material = showColour;

        await Task.Delay (1000);
        buttonRenderer.material = baseColour;
    }
}
