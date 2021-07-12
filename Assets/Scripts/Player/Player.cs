using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player Instance;
    public Image toolElectricUI;
    public Image toolDiskUI;
    private ArcadeMachine.FaultType currentTool = ArcadeMachine.FaultType.Electric;

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

    public void SetCurrentTool(ArcadeMachine.FaultType tool) {
        currentTool = tool;
        if (currentTool == ArcadeMachine.FaultType.Electric) {
            toolElectricUI.gameObject.SetActive(true);
            toolDiskUI.gameObject.SetActive(false);
        } else if (currentTool == ArcadeMachine.FaultType.Disk) {
            toolElectricUI.gameObject.SetActive(false);
            toolDiskUI.gameObject.SetActive(true);
        }
    }

    public ArcadeMachine.FaultType GetCurrentTool() {
        return currentTool;
    }
}
