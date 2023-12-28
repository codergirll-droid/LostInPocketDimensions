using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatableMirror : MonoBehaviour, IInteractable
{
    [SerializeField] float rotationSpeed = 30f;

    float right, left, up, down;

    public void Interact(float up, float right)
    {
        if(up > 0)
        {
            transform.Rotate(-transform.up, rotationSpeed * Time.deltaTime);
        }
        else if (up < 0)
        {
            transform.Rotate(transform.up, rotationSpeed * Time.deltaTime);
        }

        if (right > 0)
        {
            transform.Rotate(transform.right, rotationSpeed * Time.deltaTime);
        }
        else if (right < 0)
        {
            transform.Rotate(-transform.right, rotationSpeed * Time.deltaTime);
        }

    }

    private void OnTriggerStay(Collider other)
    {
        right = (Input.GetKey(KeyCode.RightArrow)) ? 1 : 0;
        left = (Input.GetKey(KeyCode.LeftArrow)) ? -1 : 0;
        up = (Input.GetKey(KeyCode.UpArrow)) ? 1 : 0;
        down = (Input.GetKey(KeyCode.DownArrow)) ? -1 : 0;

        Interact(right + left, up + down);
    }
}
