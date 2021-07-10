using System;

[Serializable]
public class IntegerReference
{
    public bool useConstant = true;
    public int constantValue;
    public IntegerVariable variable;

    public IntegerReference() { }

    public IntegerReference(int v)
    {
        this.useConstant = true;
        this.constantValue = v;
    }

    public int Value
    {
        get
        {
            return this.useConstant ? this.constantValue : this.variable.value;
        }

        set
        {
            if (this.useConstant)
            {
                this.constantValue = value;
            } else
            {
                this.variable.SetValue(value);
            }
        }
    }

    public static implicit operator int(IntegerReference reference)
    {
        return reference.Value;
    }
}
