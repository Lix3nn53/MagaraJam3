using System;

[Serializable]
public class FloatReference
{
    public bool useConstant = true;
    public float constantValue;
    public FloatVariable variable;

    public FloatReference() { }

    public FloatReference(float v)
    {
        this.useConstant = true;
        this.constantValue = v;
    }

    public float value
    {
        get
        {
            return this.useConstant ? this.constantValue : this.variable.value;
        }
    }

    public static implicit operator float(FloatReference reference)
    {
        return reference.value;
    }
}
