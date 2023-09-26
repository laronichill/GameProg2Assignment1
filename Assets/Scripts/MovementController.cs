using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    /* public Vector3 gravity;
    public Vector3 playerVelocity;

    public bool isOnGround = false;
    public float gravityValue = -9.81f;

    public float walkSpeed = 5;
    public float runSpeed = 8;

    private CharacterController controller;
    private Animator animator;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
    public void Update()
    {
        ProcessMovement();
    }
    public void LateUpdate()
    {
        UpdateAnimator();
    }
    void DisableRootMotion()
    {
        animator.applyRootMotion = false;
    }
    void UpdateAnimator()
    {
        isOnGround = controller.isGrounded;
        Vector3 characterXandZMotion = new Vector3(playerVelocity.x, 0.0f, playerVelocity.z);

        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.0f || Mathf.Abs(Input.GetAxis("Vertical")) > 0.0f)
        {
             if (Input.GetButton("Fire3"))// Left shift
            {
                animator.SetFloat("Speed", 1.0f);
            }
            else
            {
                animator.SetFloat("Speed", 0.5f);
            } 
        }
        else
        {
            animator.SetFloat("Speed", 0.0f);
        }

    }
    void ProcessMovement()
    {
        float speed = GetMovementSpeed();
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
        playerVelocity = move * Time.deltaTime * speed;
        playerVelocity.y = gravityValue * Time.deltaTime;
        controller.Move(playerVelocity);
        isOnGround = controller.isGrounded;
    }

    float GetMovementSpeed()
    {
        if (Input.GetButton("Fire3"))// Left shift
        {
            return runSpeed;
        }
        else
        {
            return walkSpeed;
        }
    } */

    public Vector3 gravity;
    public Vector3 playerVelocity;
    public bool groundedPlayer;
    public float mouseSensitivy = 5.0f;
    private float jumpHeight = 1f;
    private float gravityValue = -9.81f;
    private CharacterController controller;
    private float walkSpeed = 5;
    private float runSpeed = 8; 
 
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    public void Update()
    {
       UpdateRotation();
       ProcessMovement();
    }
    void UpdateRotation()
    {
        transform.Rotate(0, Input.GetAxis("Mouse X")* mouseSensitivy, 0, Space.Self);
    }
    
    
    void ProcessMovement()
    { 
        // Moving the character foward according to the speed
        float speed = GetMovementSpeed();

        Vector3 move = Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward;// new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        // Making sure we dont have a Y velocity if we are grounded
        // controller.isGrounded tells you if a character is grounded ( IE Touches the ground)
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer)
        {
            if (Input.GetButtonDown("Jump") )
            {
                gravity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            }
            else 
            {
                // Dont apply gravity if grounded and not jumping
                gravity.y = -1.0f;
            }
        }
        else 
        {
            // Since there is no physics applied on character controller we have this applies to reapply gravity
            gravity.y += gravityValue * Time.deltaTime;
        }  
        Vector3 movement = move.z *transform.forward  + move.x * transform.right;
        playerVelocity = gravity * Time.deltaTime + movement * Time.deltaTime * speed;
        controller.Move(playerVelocity);
    }
    
    float GetMovementSpeed()
    {
        if (Input.GetButton("Fire3"))// Left shift
        {
            return runSpeed;
        }
        else
        {
            return walkSpeed;
        }
    }
}

