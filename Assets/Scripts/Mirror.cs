using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    RenderTexture targetTexture;
    public Camera cam;

    private void Awake()
    {
        targetTexture = new RenderTexture(256, 256, 24);
    }

    private void Start()
    {
        this.GetComponent<Renderer>().material.mainTexture = targetTexture;
        cam.targetTexture = targetTexture;
    }
}
