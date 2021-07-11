using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public IntegerVariable score;
    public IntegerVariable customerSatisfaction;
    public int customerSatisfactionStart = 10;

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

        customerSatisfaction.SetValue(customerSatisfactionStart);
    }
}
