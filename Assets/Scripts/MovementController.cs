using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class MovementController : MonoBehaviour
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
    public bool HasDoubleJumped = false;
    public bool canDoubleJumped = false;
    public Text DoubleJumpedText;
    private Animator animator;
    float speed = 0f;
    public GameObject jumpParticlePrefab;
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

        if (groundedPlayer) {
            if (Input.GetButtonDown("Jump")){
                gravity.y += Mathf.Sqrt(jumpHeight * -4.0f * gravityValue);
                animator.SetBool("IsGrounded", !groundedPlayer);
            } else {
                gravity.y = -1.0f;
                HasDoubleJumped = false;
                animator.SetBool("IsGrounded", groundedPlayer);
            }
        } else {
            gravity.y += gravityValue * Time.deltaTime;
            if (Input.GetButtonDown("Jump") && HasDoubleJumped != true && canDoubleJumped){
                gravity.y += Mathf.Sqrt(jumpHeight * -4.0f * gravityValue);
                HasDoubleJumped = true;
                canDoubleJumped = !HasDoubleJumped;
                DoubleJumpedText.text = "No";
                animator.SetTrigger("DoubleJump");
                GameObject particleSystemObject = Instantiate(jumpParticlePrefab, transform.position - new Vector3(0, -0.6f, 0), Quaternion.identity);
            }
        }  
        Vector3 movement = move.z *transform.forward  + move.x * transform.right;
        playerVelocity = gravity * Time.deltaTime + movement * Time.deltaTime * speed;
        controller.Move(playerVelocity);
    }
    void UpdateAnimator() {
        isOnGround = controller.isGrounded;
        Vector3 characterXandZMotion = new Vector3(playerVelocity.x, 0.0f, playerVelocity.z);

        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.0f || Mathf.Abs(Input.GetAxis("Vertical")) > 0.0f) {
            if (Input.GetButton("Fire3") && Input.GetAxis("Vertical") > 0 && isOnGround == true) { // Left shift and Forward
                speed = runSpeed;
                TransitionAnimation("PlayerAnimationSpeed", 1.0f);
            } else if (Input.GetAxis("Vertical") < 0) {
                speed = walkSpeed;
                TransitionAnimation("PlayerAnimationSpeed", -0.5f);
            } else {
                speed = walkSpeed;
                TransitionAnimation("PlayerAnimationSpeed", 0.5f);
            } 
        } else {
            TransitionAnimation("PlayerAnimationSpeed", 0.0f);
        }
    }
    void TransitionAnimation(String AnimationStringName, float AnimationFloatValue){
        animator.SetFloat(AnimationStringName, AnimationFloatValue);
    }
}

