using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Float")]
public class FloatVariable : ScriptableObject
{

#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif

    public float value;

    public void SetValue(float v)
    {
        this.value = v;
    }

    public void SetValue(FloatVariable floatVariable)
    {
        this.value = floatVariable.value;
    }

    public void ApplyChange(float v)
    {
        this.value += v;
    }

    public void ApplyChange(FloatVariable floatVariable)
    {
        this.value += floatVariable.value;
    }
}
