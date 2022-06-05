using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField] private CharacterController chController;

    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpHeight = 5f;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;
    private bool isGrounded;

    private float gravity = -10f;

    Vector3 gravityVelocity;

    private void Update() {

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * x + transform.forward * z;

        chController.Move(movement * speed * Time.deltaTime);

        gravityVelocity.y += gravity * Time.deltaTime;

        chController.Move(gravityVelocity * Time.deltaTime);

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && gravityVelocity.y < 0){
            gravityVelocity.y = -2f;
        }

        if(Input.GetButtonDown("Jump")&& isGrounded)
        {
            gravityVelocity.y=Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

}
