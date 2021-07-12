using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSettings : MonoBehaviour
{
    public static GlobalSettings Instance;
    public bool hideOnPlay = true;
    public int heightPerLevel = 2;
    public int maxCustomerSatisfaction = 20;
    public int startCustomerSatisfaction = 10;

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
}
