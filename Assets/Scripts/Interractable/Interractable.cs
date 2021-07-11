using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interractable : MonoBehaviour
{
    public GameObject keyGuide;
    public virtual void OnTriggerEnter2D(Collider2D other) {
        var go = other.gameObject;
        if (go == null || !other.gameObject.CompareTag("Player"))
            return;

        Player player = go.GetComponent<Player>();
        
        if (keyGuide != null) {
            keyGuide.SetActive(true);
        }

        player.SetSelectedInterractable(this);
    }
    
    public virtual void OnTriggerExit2D(Collider2D other) {
        var go = other.gameObject;
        if (go == null || !other.gameObject.CompareTag("Player"))
            return;

        Player player = go.GetComponent<Player>();
        
        if (keyGuide != null) {
            keyGuide.SetActive(false);
        }
    }

    public virtual void OnInterract() {

    }
}
