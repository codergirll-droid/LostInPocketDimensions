using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableMirror : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0.1f;
    [SerializeField] float maxMoveRange = 5f;

    Vector3 originalPos;
    Vector3 maxPos;
    Vector3 minPos;

    float right, left;

    private void Start()
    {
        originalPos = transform.position;
        maxPos = originalPos + transform.TransformDirection(Vector3.right) * maxMoveRange;
        minPos = originalPos - transform.TransformDirection(Vector3.right) * maxMoveRange;
    }

    public void Interact(float dir)
    {

        if (dir > 0)
        {
            if(Vector3.Distance(transform.position, maxPos) > 0.5f)
            {
                transform.position = Vector3.Lerp(transform.position, transform.position + transform.TransformDirection(Vector3.right) * moveSpeed, 0.1f);
            }
        }
        else if(dir < 0)
        {
            if (Vector3.Distance(transform.position, minPos) > 0.5f)
            {
                transform.position = Vector3.Lerp(transform.position, transform.position - transform.TransformDirection(Vector3.right) * moveSpeed, 0.1f);

            }
        }

        

    }

    private void OnTriggerStay(Collider other)
    {
        right = (Input.GetKey(KeyCode.RightArrow)) ? 1 : 0;
        left = (Input.GetKey(KeyCode.LeftArrow)) ? -1 : 0;

        Interact(right + left);
    }

}
