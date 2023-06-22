using UnityEngine;

public class stepGravityController : MonoBehaviour
{
    public CharacterController characterController;
    public float defaultGravityScale = 2f; // Default gravity scale
    public float stepGravityScale = 20f;   // Gravity scale for going down a step
    public float stepHeight = 0.5f;        // Height threshold for detecting a step

    private bool isDescendingStep = false;  // Flag to track if character is descending a step

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Check if the character is descending a step
        if (characterController.isGrounded && characterController.velocity.y < 0f)
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(transform.position, Vector3.down, out hitInfo, stepHeight))
            {
                isDescendingStep = true;
            }
        }
        else
        {
            isDescendingStep = false;
        }

        // Apply gravity based on the current situation
        if (isDescendingStep)
        {
            characterController.Move(Vector3.down * (Physics.gravity.y * stepGravityScale * Time.deltaTime));
        }
        
    }
}
