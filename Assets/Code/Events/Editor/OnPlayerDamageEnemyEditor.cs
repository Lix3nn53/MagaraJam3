using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(OnPlayerDamageEnemy))]
public class OnPlayerDamageEnemyEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GUI.enabled = Application.isPlaying;

        OnPlayerDamageEnemy delegateEvent = target as OnPlayerDamageEnemy;

        if (GUILayout.Button("Raise"))
        {
            delegateEvent.Delegate(1);
        }
    }
}
