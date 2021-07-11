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
    }
    public void KeyGuideChange(string text) {
        keyGuideText.text = text;
    }
    public void KeyGuideEnable() {
        keyGuide.SetActive(true);
    }
    public void KeyGuideDisable() {
        keyGuide.SetActive(false);
    }
}
