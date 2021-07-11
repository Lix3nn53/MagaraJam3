using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public static Player Instance;
    public GameObject keyGuide;
    private TMP_Text keyGuideText;

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

    private void Start() {
        keyGuideText = keyGuide.GetComponentInChildren<TMP_Text>();
        keyGuide.SetActive(false);
    }
    public void KeyGuideChange(string text) {
        keyGuideText.text = text;
    }
    public void KeyGuideEnable() {
        keyGuide.SetActive(true);
        // RectTransform rectTransform keyGuide.transform.x = 1f;
    }
    public void KeyGuideDisable() {
        keyGuide.SetActive(false);
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
