using System.Diagnostics;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class characterController : MonoBehaviour
{

    bool capsLock = false;
    float sprintSpeed =  20f;
    float ogSpeed = 15f;
    public float movementSpeed = 5f;
    public float mouseSensitivity = 2f;
    public float jumpForce = 10f;
    public float groundedRange = 5f;

    private Rigidbody rb;
    private Camera playerCamera;
    private float verticalRotation = 0f;
    public Animator animator;


    private void Start()
    {
        movementSpeed = ogSpeed;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        playerCamera = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // Handle mouse movement for looking around
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.Rotate(0f, mouseX, 0f);
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);
        playerCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);

        // Handle player movement
        float horizontalInput = Input.GetAxis("Horizontal") * movementSpeed;
        float zInput = Input.GetAxis("Vertical") * movementSpeed;

        Vector3 movement = transform.right * horizontalInput + transform.forward * zInput;
        movement.y = rb.velocity.y;
        rb.velocity = movement;

        // Handle jumping
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if(!IsGrounded()){
            animator.SetBool("isWalking", false);
        }

        if(capsLock){
            movementSpeed = sprintSpeed;
        }

        else
        {
            movementSpeed = ogSpeed;
        }


        if(Input.GetKeyDown(KeyCode.CapsLock)){
            if(capsLock){
                capsLock = false;
            }

            else{
                capsLock = true;
            }
            
        }
        

      

        bool isWalking = Mathf.Abs(horizontalInput) > 0f || Mathf.Abs(zInput) > 0f;
        animator.SetBool("isWalking", isWalking);
        isWalking = false;
    }

    private bool IsGrounded()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, groundedRange))
        {
            return true;
        }

        return false;
    }
}
