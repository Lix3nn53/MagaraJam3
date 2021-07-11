using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricCharacterAnimation : MonoBehaviour
{
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
        
        if (magnitude > 0.0f) {
            animator.SetBool("Walking", true);
        } else {
            animator.SetBool("Walking", false);
        }

        if (movementVector.y > 0) {
            animator.SetBool("FaceFront", false);
        } else if (movementVector.y < 0) {
            animator.SetBool("FaceFront", true);
        }

        if (movementVector.x > 0) {
            characterRenderer.flipX = true;
        } else if (movementVector.x < 0) {
            characterRenderer.flipX = false;
        }
    }
}
