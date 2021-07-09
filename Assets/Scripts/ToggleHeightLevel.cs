using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ToggleHeightLevel : MonoBehaviour
{
    public int setHeight = 0;
    public Collider2D[] enableCollider;
    public Collider2D[] disableCollider;

    private void OnTriggerExit2D(Collider2D other)
    {
        var go = other.gameObject;
        if (go == null || !other.gameObject.CompareTag("Player") || go.transform.parent.position.z == setHeight)
            return;

        if (enableCollider != null)
        {
            foreach (var collider in enableCollider)
                collider.gameObject.SetActive(true);
        }
        if (disableCollider != null)
        {
            foreach (var collider in disableCollider)
                collider.gameObject.SetActive(false);
        } 

        SortingGroup sg = go.GetComponentInParent<SortingGroup>();
        sg.sortingOrder = setHeight;

        var position = go.transform.position;
        var newPosition = new Vector3(position.x, position.y, setHeight);
        go.transform.parent.position = newPosition;
    }
}
