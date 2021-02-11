using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveOffset : MonoBehaviour
{
    private Material currentMaterial; 
    public float velocity;
    private float offset; 

    void Start()
    {
        currentMaterial = GetComponent<Renderer>().material;
    }

    void FixedUpdate()
    {
        offset += 0.001f;
        currentMaterial.SetTextureOffset("_MainTex", new Vector2(offset * velocity, 0));
    }
}
