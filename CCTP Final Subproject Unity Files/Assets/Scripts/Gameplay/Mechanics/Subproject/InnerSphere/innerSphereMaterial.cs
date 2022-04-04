using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class innerSphereMaterial : MonoBehaviour
{
    public PlayerController playerController;

    private Renderer innerSphereRenderer; 
    public Material innerSphereMat;
    public Material standardMat;
    public bool useSetMaterial;

    private void Awake() 
    {
        innerSphereRenderer = GetComponent <Renderer>();

        if (useSetMaterial)
        {
            standardMat = innerSphereRenderer.material;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.insideSphere)
        {
            innerSphereRenderer.material = innerSphereMat; 
        }
        else
        {
            innerSphereRenderer.material = standardMat;
        }
    }
}
