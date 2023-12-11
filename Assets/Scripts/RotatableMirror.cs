using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatableMirror : MonoBehaviour, IInteractable
{
    [SerializeField] float rotationSpeed = 30f;

    public void Interact()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        Debug.Log("Interacting with " + gameObject.name);
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.I))
        {
            Interact();
        }
    }
}
