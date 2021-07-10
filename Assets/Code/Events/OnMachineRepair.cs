using UnityEngine;

[CreateAssetMenu(menuName = "DelegateEvents/OnMachineRepair")]
public class OnMachineRepair : ScriptableObject
{
    public delegate void OnMachineRepairDelegate();
    public OnMachineRepairDelegate Delegate;

}
