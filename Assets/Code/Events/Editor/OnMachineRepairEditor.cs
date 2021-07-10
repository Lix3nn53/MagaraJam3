using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(OnMachineRepair))]
public class OnMachineRepairEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GUI.enabled = Application.isPlaying;

        OnMachineRepair delegateEvent = target as OnMachineRepair;

        if (GUILayout.Button("Raise"))
        {
            delegateEvent.Delegate();
        }
    }
}
