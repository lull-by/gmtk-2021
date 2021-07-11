using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float acceleration = 1f;
    public Rigidbody2D rb;
    public Animator animator;


    private Vector2 direction;
    private Vector2 input;
    private float currentWalkSpeed = 0f;

    void Update()
    {
        // Input
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        bool isWalking = input.x != 0 || input.y != 0;

        Debug.Log($"walkSpeed: {currentWalkSpeed} hor: {input.x} vert: {input.y}");

        if (isWalking) {
            // accelerate
            currentWalkSpeed = walkSpeed;

            direction = input.normalized;
            animator.SetFloat("dirHorizontal", direction.x);
            animator.SetFloat("dirVertical", direction.y);
        }
        else {
            // decelerate
            currentWalkSpeed = 0;
        }

        animator.SetBool("isWalking", isWalking);
        animator.SetFloat("walkSpeed", currentWalkSpeed);
    }

    void FixedUpdate() {
        // Movement
        rb.velocity = direction * currentWalkSpeed;
    }
}