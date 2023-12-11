using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotationSpeed = 180f;
    public Animator animator;

    float rotation;
    bool movementZ;
    bool movementReverseZ;

    Vector3 movementFinal;

    private void Update()
    {
        rotation = Input.GetAxisRaw("Mouse X") * rotationSpeed;
        movementZ = Input.GetKey(KeyCode.W);
        movementReverseZ = Input.GetKey(KeyCode.S);
        
    }

    void FixedUpdate()
    {
        if(movementZ)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);

        }

        transform.Rotate(Vector3.up, rotation * Time.deltaTime);

        if (movementZ)
        {
            movementFinal = transform.forward * moveSpeed * Time.deltaTime;

        }else if (movementReverseZ)
        {
            movementFinal = -transform.forward * moveSpeed * Time.deltaTime;

        }
        else
        {
            movementFinal = Vector3.zero;
        }
        transform.position += movementFinal;


    }
}
