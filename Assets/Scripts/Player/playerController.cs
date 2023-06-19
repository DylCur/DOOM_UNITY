using System;
using UnityEngine;



[RequireComponent(typeof(CharacterController))]
public class playerController : MonoBehaviour
{
    [Header("Movement Parameters")]
    public float movementSpeed = 5f;
    public float jumpForce = 10f;
    public float groundCheckDistance = 0.1f;
    public LayerMask groundLayer;


    public float mouseSensitivity = 2f;

    private float verticalRotation = 0f;
    [HideInInspector] public CharacterController characterController;
    public Animator animator;

    [Header("Keycodes")]

    public KeyCode jumpKey = KeyCode.Space;

    public float horizontalMovement;
    public float verticalMovement;

    


    private bool IsGrounded()
    {
        // Cast a ray downwards from the character's position
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, groundCheckDistance, groundLayer))
        {
            return true;
        }
        return false;
    }


    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        
        // Handle player movement
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");
  

        Vector3 movement = transform.right * horizontalMovement + transform.forward * verticalMovement;
        movement.Normalize();
        characterController.SimpleMove(movement * movementSpeed);

        // Handle walking animation
        bool isWalking = Mathf.Abs(horizontalMovement) > 0f || Mathf.Abs(verticalMovement) > 0f;
        animator.SetBool("isWalking", isWalking);
        isWalking = false;

        if(isWalking){
            Debug.Log(isWalking);
        }
        else{
            Debug.Log("You arent walking");
        }


        // Handle mouse camera movement
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.Rotate(0f, mouseX, 0f); // Horizontal rotation

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f); // Limit vertical rotation

        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f); // Vertical rotation


    }

    
    void print(string i){
        Debug.Log(i);
    }
}
