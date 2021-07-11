using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public GameObject keyGuide;
    private TMP_Text keyGuideText;

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
}
