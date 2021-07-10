using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOnPlay : MonoBehaviour
{
    void Awake()
    {
        if (!GlobalSettings.Instance.hideOnPlay) return;

        Renderer colliderRenderer = GetComponent<Renderer>();
        colliderRenderer.enabled = false;
    }
}
