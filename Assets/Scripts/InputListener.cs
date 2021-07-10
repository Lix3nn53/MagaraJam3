using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputListener : MonoBehaviour
{
    private IsometricPlayerMovementController controller;

    private void Awake() {
        controller = GetComponent<IsometricPlayerMovementController>();
    }

    public void OnInterract(InputAction.CallbackContext context)
    {
        if (context.performed) {
            Debug.Log("Interract!");
        }
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        if (context.performed) {
            Vector2 movement = context.ReadValue<Vector2>();
            controller.OnMovement(movement);
        } else if (context.canceled) {
            controller.OnMovementCancel();
        }
    }
}
