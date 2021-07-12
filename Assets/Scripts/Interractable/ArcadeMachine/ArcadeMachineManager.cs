using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeMachineManager : MonoBehaviour
{
    public static ArcadeMachineManager Instance;

    private ArcadeMachine[] arcadeMachines;

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

        arcadeMachines = GetComponentsInChildren<ArcadeMachine>();
    }

    public ArcadeMachine GetAvailable() {
        foreach (ArcadeMachine arcade in arcadeMachines) {
            if (arcade.isAvailable()) {
                return arcade;
            }
        }

        return null;
    }

    public int GetAvailableCount() {
        int count = 0;
        foreach (ArcadeMachine arcade in arcadeMachines) {
            if (arcade.isAvailable()) {
                count++;
            }
        }

        return count;
    }
}
