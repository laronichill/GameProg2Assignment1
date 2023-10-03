using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Movement : MonoBehaviour
{
    public Vector3 gravity;
    public Vector3 playerVelocity;
    public bool groundedPlayer;
    public float mouseSensitivy = 5.0f;
    private float jumpHeight = 1f;
    private float gravityValue = -9.81f;
    private CharacterController controller;
    private float walkSpeed = 5;
    private float runSpeed = 8;
    public bool isOnGround = false;
    private Animator animator;
    float speed = 0f;
    private void Start() {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    public void Update() {
       UpdateRotation();
       ProcessMovement();
       UpdateAnimator();
    }
    void UpdateRotation(){
        transform.Rotate(0, Input.GetAxis("Mouse X")* mouseSensitivy, 0, Space.Self);
    }
    void ProcessMovement(){ 
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        groundedPlayer = controller.isGrounded;

        if (groundedPlayer)
        {
            if (Input.GetButtonDown("Jump") ){
                gravity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            } else {
                gravity.y = -1.0f;
            }
        } else {
            gravity.y += gravityValue * Time.deltaTime;
        }  
        Vector3 movement = move.z *transform.forward  + move.x * transform.right;
        playerVelocity = gravity * Time.deltaTime + movement * Time.deltaTime * speed;
        controller.Move(playerVelocity);
    }
    void UpdateAnimator() {
        isOnGround = controller.isGrounded;
        Vector3 characterXandZMotion = new Vector3(playerVelocity.x, 0.0f, playerVelocity.z);


        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.0f || Mathf.Abs(Input.GetAxis("Vertical")) > 0.0f) {
            if (Input.GetButton("Fire3") && Input.GetAxis("Vertical") > 0) { // Left shift and Forward
                speed = runSpeed;
                animator.SetFloat("PlayerAnimationSpeed", 1.0f);
            } else if (characterXandZMotion.z < 0) {
                speed = walkSpeed;
                animator.SetFloat("PlayerAnimationSpeed", -0.5f);
            } else {
                speed = walkSpeed;
                animator.SetFloat("PlayerAnimationSpeed", 0.5f);
            } 
        } else {
            animator.SetFloat("PlayerAnimationSpeed", 0.0f);
        }
    }
}

