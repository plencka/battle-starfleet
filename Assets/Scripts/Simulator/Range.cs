using System.Collections;
using System.Collections.Generic;

public class Range
{
    public float a { get; }
    public float b { get; }

    public Range(float a, float b)
    {
        this.a = a;
        this.b = b;
    }

    public bool Contains(float a)
    {
        if (a >= this.a && a <= this.b)
            return true;
        return false;
    }
}
