using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public static Player Instance;

    private Interractable selectedInterractable;
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
        }
    }

    public void SetSelectedInterractable(Interractable interractable) {
        selectedInterractable = interractable;
    }

    public void Interract() {
        if (selectedInterractable != null) {
            selectedInterractable.OnInterract();
        }
    }
}
