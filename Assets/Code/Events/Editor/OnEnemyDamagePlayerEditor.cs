using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(OnEnemyDamagePlayer))]
public class OnEnemyDamagePlayerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GUI.enabled = Application.isPlaying;

        OnEnemyDamagePlayer delegateEvent = target as OnEnemyDamagePlayer;

        if (GUILayout.Button("Raise"))
        {
            delegateEvent.Delegate(1);
        }
    }
}
