using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public enum KeyType { red, yellow, blue};
    public KeyType keyType;

    MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        if(keyType == KeyType.red)
        {
            meshRenderer.material.color = Color.red;
        }
        else if (keyType == KeyType.yellow)
        {
            meshRenderer.material.color = Color.yellow;
        }
        else if (keyType == KeyType.blue)
        {
            meshRenderer.material.color = Color.blue;
        }
    }

}
