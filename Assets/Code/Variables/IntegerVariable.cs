using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Integer")]
public class IntegerVariable : ScriptableObject
{

#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif

    public int value;

    public void SetValue(int v)
    {
        this.value = v;
    }

    public void SetValue(IntegerVariable intVariable)
    {
        this.value = intVariable.value;
    }

    public void ApplyChange(int v)
    {
        this.value += v;
    }

    public void ApplyChange(IntegerVariable intVariable)
    {
        this.value += intVariable.value;
    }
}
