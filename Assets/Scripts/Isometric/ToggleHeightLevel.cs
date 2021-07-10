using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ToggleHeightLevel : MonoBehaviour
{
    public int fromLevel = 0;
    public Collider2D[] toLevelCollider;
    public Collider2D[] fromLevelCollider;
    private bool upActive = false;
    private bool downActive = false;

    public void onEnter(bool up) {
        if (up) {
            upActive = true;
        } else {
            downActive = true;
        }
    }

    public void onExit(bool up, Collider2D other) {
        if (up) { // Exited from up
            upActive = false;

            // Walking upwards only if down is not active
            if (!downActive) {
                var go = other.gameObject;

                int currentLevel = (int) (go.transform.parent.position.z / GlobalSettings.Instance.heightPerLevel) - 1;
                if (currentLevel == fromLevel + 1) return; // Return if already at up level

                var position = go.transform.position;

                var newPosition = new Vector3(position.x, position.y, go.transform.parent.position.z + GlobalSettings.Instance.heightPerLevel);
                go.transform.parent.position = newPosition;

                if (toLevelCollider != null)
                {
                    foreach (var collider in toLevelCollider)
                        collider.gameObject.SetActive(true);
                }
                if (fromLevelCollider != null)
                {
                    foreach (var collider in fromLevelCollider)
                        collider.gameObject.SetActive(false);
                }
            }
        } else { // Exited from down
            downActive = false;

            // Walking downwards only if up is not active
            if (!upActive) {
                var go = other.gameObject;

                int currentLevel = (int) (go.transform.parent.position.z / GlobalSettings.Instance.heightPerLevel) - 1;
                Debug.Log("currentLevel: " + currentLevel);
                if (currentLevel == fromLevel) return; // Return if already at down level

                var position = go.transform.position;

                var newPosition = new Vector3(position.x, position.y, go.transform.parent.position.z - GlobalSettings.Instance.heightPerLevel);
                go.transform.parent.position = newPosition;

                if (fromLevelCollider != null)
                {
                    foreach (var collider in fromLevelCollider)
                        collider.gameObject.SetActive(true);
                }
                if (toLevelCollider != null)
                {
                    foreach (var collider in toLevelCollider)
                        collider.gameObject.SetActive(false);
                }
            }
        }
    }
}
