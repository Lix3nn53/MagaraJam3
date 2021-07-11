using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public IntegerVariable score;
    public TMP_Text scoreText;
    public IntegerVariable customerSatisfaction;
    public Slider customerSatisfactionSlider;

    // Start is called before the first frame update
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

    void Start() {
        customerSatisfaction.SetValue(GlobalSettings.Instance.maxCustomerSatisfaction);
        score.SetValue(0);

        customerSatisfactionSlider.value = (float) GlobalSettings.Instance.maxCustomerSatisfaction / (float) customerSatisfaction.value;
    }

    public void AddScore(int s) {
        score.ApplyChange(s);
        scoreText.text = "Money: " + score.value;
    }

    public void AddCustomerSatisfaction(int add) {
        customerSatisfaction.ApplyChange(add);

        if (customerSatisfaction.value < 0) {
            customerSatisfaction.SetValue(0);
            customerSatisfactionSlider.value = 0;
            return;
        } else if (customerSatisfaction.value > GlobalSettings.Instance.maxCustomerSatisfaction) {
            customerSatisfaction.SetValue(GlobalSettings.Instance.maxCustomerSatisfaction);
        }

        customerSatisfactionSlider.value = (float) customerSatisfaction.value / (float) GlobalSettings.Instance.maxCustomerSatisfaction;
    }
}
