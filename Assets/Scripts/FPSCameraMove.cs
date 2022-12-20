using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FPSCameraMove : MonoBehaviour
{
    [SerializeField] Transform cameraTransform;
    [SerializeField] public float mouseSensetivity = 5f;

    [SerializeField] float mass = 1f;
    Vector2 look;
    
    [SerializeField] public float speed = 12f;
    [SerializeField] public float jumpSpeed = 24f;
    // Input system
    PlayerInput playerInput;
    InputAction moveAction;
    InputAction lookAction;
    InputAction jumpAction;

    //flying
    public enum State
    {
        Walking,
        Flying
    }
    public State state;
    Vector3 velocity;

    
    CharacterController controller;
    private void Awake() 
    {
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["move"];
        lookAction = playerInput.actions["look"];
        jumpAction = playerInput.actions["jump"];
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {   
        switch (state)
        {
            // Walking
            case State.Walking:
            UpdateGravity();
            UpdateMovement();
            UpdateLook();
            break;

            // Flying
            case State.Flying:
            UpdateMovementFlying();
            UpdateLook();
            break;
        }
        UpdateLook();
        
    }

    void UpdateLook()
    {
        // Get mouse moves
        var lookInput = lookAction.ReadValue<Vector2>();
        look.x += lookInput.x * mouseSensetivity; 
        look.y += lookInput.y * mouseSensetivity; 

        // Rotation limits
        look.y = Mathf.Clamp(look.y, -90f, 80f);

        cameraTransform.localRotation = Quaternion.Euler(-look.y, 0f, 0f);
        transform.localRotation = Quaternion.Euler(0f, look.x, 0f);
    }

    Vector3 GetMovementInput(bool horizontal = true)
    {
        var moveInput = moveAction.ReadValue<Vector2>();
        var input = new Vector3();
        var referenceTransform = horizontal ? transform : cameraTransform;
        input += referenceTransform.forward * moveInput.y;
        input += referenceTransform.right * moveInput.x;
        input = Vector3.ClampMagnitude(input, 1f);
        return input;
    }

     void UpdateMovement()
     {
        
         // Move inputs
        //var x = Input.GetAxis("Horizontal");
        //var z = Input.GetAxis("Vertical");
        var input = GetMovementInput();

        // Jummping
        var jumpInput = jumpAction.ReadValue<float>();
        if(jumpInput > 0 && controller.isGrounded)
        {
            velocity.y += jumpSpeed;
        }
        controller.Move((input * speed + velocity) * Time.deltaTime);
     }

    void UpdateMovementFlying()
     {
        
         // Move inputs
        //var x = Input.GetAxis("Horizontal");
        //var z = Input.GetAxis("Vertical");
        var input = GetMovementInput(false);

        // Jummping
        velocity = Vector3.Lerp(velocity, input, 1f);
        controller.Move((input * speed + velocity) * Time.deltaTime);
     }

     void UpdateGravity()
     {
        var gravity = Physics.gravity * mass * Time.deltaTime;
        velocity.y = controller.isGrounded ? -1f : velocity.y + gravity.y;
     }

     void OnToggleFlying()
     {
        state = state == State.Flying ? State.Walking : State.Flying;
     }
}
