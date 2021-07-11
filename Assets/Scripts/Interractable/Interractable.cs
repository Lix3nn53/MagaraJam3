using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interractable : MonoBehaviour
{
    public virtual void OnTriggerEnter2D(Collider2D other) {
        var go = other.gameObject;
        if (go == null || !other.gameObject.CompareTag("Player"))
            return;

        Player player = go.GetComponent<Player>();
        
        player.KeyGuideChange("E");
        player.KeyGuideEnable();

        player.SetSelectedInterractable(this);
    }
    
    public virtual void OnTriggerExit2D(Collider2D other) {
        var go = other.gameObject;
        if (go == null || !other.gameObject.CompareTag("Player"))
            return;

        Player player = go.GetComponent<Player>();
        
        player.KeyGuideDisable();
    }

    public virtual void OnInterract() {
        
    }
}
