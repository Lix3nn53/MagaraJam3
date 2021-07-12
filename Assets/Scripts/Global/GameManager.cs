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
    public TMP_Text customerSatisfactionText;

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
        customerSatisfaction.SetValue(GlobalSettings.Instance.startCustomerSatisfaction);
        score.SetValue(0);
        scoreText.text = "" + score.value;

        customerSatisfactionSlider.value = (float) customerSatisfaction.value / (float) GlobalSettings.Instance.maxCustomerSatisfaction;
    }

    public void AddScore(int add) {
        add = add * customerSatisfaction.value;

        score.ApplyChange(add);
        scoreText.text = "" + score.value;
    }

    public void AddCustomerSatisfaction(int add) {
        customerSatisfaction.ApplyChange(add);

        if (customerSatisfaction.value < 1) {
            customerSatisfaction.SetValue(1);
            customerSatisfactionSlider.value = 1;
            return;
        } else if (customerSatisfaction.value > GlobalSettings.Instance.maxCustomerSatisfaction) {
            customerSatisfaction.SetValue(GlobalSettings.Instance.maxCustomerSatisfaction);
        }

        customerSatisfactionText.text = "" + customerSatisfaction.value;

        customerSatisfactionSlider.value = (float) customerSatisfaction.value / (float) GlobalSettings.Instance.maxCustomerSatisfaction;
    }
}
