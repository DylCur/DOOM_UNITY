using UnityEngine;

public class playerController : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float mouseSensitivity = 2f;

    private float verticalRotation = 0f;
    private CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        // Handle player movement
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * horizontalMovement + transform.forward * verticalMovement;
        movement.Normalize();
        characterController.SimpleMove(movement * movementSpeed);

        // Handle mouse camera movement
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.Rotate(0f, mouseX, 0f); // Horizontal rotation

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f); // Limit vertical rotation

        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f); // Vertical rotation
    }
}
