using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
    public CharacterController controller;
    public float jumpForce = 5f;
    public float jumpDuration = 1f;
    public float groundCheckDistance = 0.1f;
    public LayerMask groundLayer;

    private bool isJumping = false;
    private float currentJumpTime = 0f;
    private const float InitialJumpForce = 10f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            StartJump();
        }

        if (isJumping)
        {
            UpdateJump();
        }
        else if (IsGrounded())
        {
            ResetJumpForce();
        }
    }

    private void StartJump()
    {
        isJumping = true;
        currentJumpTime = 0f;
        jumpForce = InitialJumpForce;
    }

    private void UpdateJump()
    {
        currentJumpTime += Time.deltaTime;
        if (currentJumpTime < jumpDuration)
        {
            float t = currentJumpTime / jumpDuration;
            jumpForce = Mathf.Lerp(InitialJumpForce, 0f, t);
            controller.Move(Vector3.up * jumpForce * Time.deltaTime);
        }
        else
        {
            isJumping = false;
        }
    }

    private void ResetJumpForce()
    {
        jumpForce = InitialJumpForce;
    }

    private bool IsGrounded()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, groundCheckDistance, groundLayer))
        {
            return true;
        }
        return false;
    }
}
