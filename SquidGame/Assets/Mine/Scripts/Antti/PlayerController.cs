using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(CharacterController))]


public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private SOPlayerSettings playerSettings; 
    private Animator animator;
    private CharacterController characterController;
    
    [SerializeField] private float movementTime = 0.2f;
    
    [SerializeField] private Vector3 velocity;
    [SerializeField] private float gravity = -9.8f; 
    private float speed;

    [SerializeField] private AudioClip[] sounds;

    public bool isMoving;
    public bool isJumping;

    private void Awake()
    {
        isMoving = true;
        isJumping = true;
    }
    void Start()
    {        
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        speed = playerSettings.PlayerSpeed;
    }

    void Update()
    {       
        if (isMoving) CharacterMovement();
        else
        {
            animator.SetFloat("X", 0, movementTime, Time.deltaTime);
            animator.SetFloat("Y", 0, movementTime, Time.deltaTime);
        }       
    }

    private void CharacterMovement()
    {
        if (isJumping) Jump();
        if (playerSettings.JumpForce == 0) isJumping = false;
        else isJumping = true;

        //näppäimet
        Vector2 movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        animator.SetFloat("X", movementDirection.x, movementTime, Time.deltaTime); // määritellään animaatiot x suuntaan. kun x =1 ->kävelee eteenpäin, kun x =-1 -> kävelee taaksepäin
        animator.SetFloat("Y", movementDirection.y, movementTime, Time.deltaTime); //strafe/liikutaan sivuille

        Vector3 move = transform.forward * movementDirection.y + transform.right * movementDirection.x;
        //characterController.Move(move * speed * Time.deltaTime); // hahmo liikkuu eteen

        velocity.y += gravity * Time.deltaTime;
        characterController.Move((move * speed * Time.deltaTime) + (velocity * Time.deltaTime));

        if (characterController.isGrounded && velocity.y < -2)
        {
            velocity.y = -2;
        }


        if (characterController.isGrounded == false) speed = playerSettings.PlayerSpeedInAir;
        else speed = playerSettings.PlayerSpeed;      

 
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && characterController.isGrounded)
        {
            velocity.y = Mathf.Sqrt(playerSettings.JumpForce * -2f * gravity);
            animator.SetBool("Jump", true);
        }
    }
  
}
