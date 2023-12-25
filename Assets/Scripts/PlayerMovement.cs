using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    public float rotationSpeed = 5;
    public float gravity = 9.81f;

    public Animator animator;
    CharacterController _characterController;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }


    private void Update()
    {
        float horizontalRot = Input.GetAxis("Mouse X") * rotationSpeed;
        transform.Rotate(0, horizontalRot, 0);

        float D = (Input.GetKey(KeyCode.D)) ? 1 : 0;
        float A = (Input.GetKey(KeyCode.A)) ? -1 : 0;
        float W = (Input.GetKey(KeyCode.W)) ? 1 : 0;
        float S = (Input.GetKey(KeyCode.S)) ? -1 : 0;


        Vector3 moveX = (D+A) * transform.right;
        Vector3 moveZ = (W+S) * transform.forward;

        //Vector3 move = moveX + moveZ;
        Vector3 move = moveZ;
        move = move.normalized;

        if (!_characterController.isGrounded)
        {
            move.y -= gravity * Time.deltaTime;
        }

        _characterController.Move(move * speed * Time.deltaTime);

        float horizontalRotation = (D + A) * rotationSpeed; 
        transform.Rotate(0, horizontalRotation, 0);

        if (moveZ.z != 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);

        }
    }

    /*
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
    */
}
