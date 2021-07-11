using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricPlayerMovementController : MonoBehaviour
{
    public FloatVariable movementSpeed;
    IsometricCharacterAnimation isoAnimation;

    Rigidbody2D rbody;

    private bool isMoving = false;
    private Vector2 movementInput;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        isoAnimation = GetComponentInChildren<IsometricCharacterAnimation>();
    }

    void FixedUpdate()
    {
        if (!isMoving) {
            isoAnimation.SetDirection(new Vector2());
            return;
        }

        Vector2 currentPos = rbody.position;
        Vector2 clamp = Vector2.ClampMagnitude(movementInput, 1);
        Vector2 movement = clamp * movementSpeed.value;
        Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
        
        isoAnimation.SetDirection(movement);
        
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
