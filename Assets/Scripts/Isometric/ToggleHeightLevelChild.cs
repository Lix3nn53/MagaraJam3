using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleHeightLevelChild : MonoBehaviour
{
    public bool up;
    ToggleHeightLevel toggleHeightLevel;
    private void Awake() {
        toggleHeightLevel = GetComponentInParent<ToggleHeightLevel>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        var go = other.gameObject;
        if (go == null || !other.gameObject.CompareTag("Player"))
            return;

        toggleHeightLevel.onEnter(up);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        var go = other.gameObject;
        if (go == null || !other.gameObject.CompareTag("Player"))
            return;

        toggleHeightLevel.onExit(up, other);
    }
}
