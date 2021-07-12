using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolStand : Interractable
{
    public ArcadeMachine.FaultType faultType;
    public override void OnInterract() {
        Player.Instance.SetCurrentTool(faultType);
    }
}
