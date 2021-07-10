using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricPlayerMovementController : MonoBehaviour
{
    public float movementSpeed = 1f;
    // IsometricCharacterRenderer isoRenderer;

    Rigidbody2D rbody;

    private bool isMoving = false;
    private Vector2 movementInput;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        // isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();
    }

    void FixedUpdate()
    {
        if (!isMoving) return;

        Vector2 currentPos = rbody.position;
        Vector2 clamp = Vector2.ClampMagnitude(movementInput, 1);
        Vector2 movement = clamp * movementSpeed;
        Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
        // isoRenderer.SetDirection(movement);
        rbody.MovePosition(newPos);
        transform.position = new Vector3(newPos.x, newPos.y, transform.position.z);
    }

    public void OnMovement(Vector2 movement) {
        movementInput = movement;
        isMoving = true;
    }

    public void OnMovementCancel() {
        isMoving = false;
    }
}
