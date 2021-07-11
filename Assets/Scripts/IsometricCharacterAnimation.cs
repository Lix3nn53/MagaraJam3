using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricCharacterAnimation : MonoBehaviour
{
    public static readonly string[] staticDirections = { "Static NW", "Static SW", "Static SE", "Static NE" };
    public static readonly string[] runDirections = {"Run NW", "Run SW", "Run SE", "Run NE"};

    Animator animator;
    SpriteRenderer characterRenderer;

    private void Awake()
    {
        //cache the animator component
        animator = GetComponent<Animator>();
        characterRenderer = GetComponent<SpriteRenderer>();
    }
    public void SetDirection(Vector2 movementVector)
    {
        float magnitude = movementVector.magnitude;
        
        animator.SetFloat("Speed", magnitude);

        if (movementVector.y > 0) {
            animator.SetBool("FaceFront", false);
        } else if (movementVector.y < 0) {
            animator.SetBool("FaceFront", true);
        }

        if (movementVector.x > 1) {
            characterRenderer.flipX = true;
        } else if (movementVector.x < 1) {
            characterRenderer.flipX = false;
        }
    }
}
