public class Health
{
    private int maxValue = 0;
    private int currentValue = 0;
    private bool isChangeAllowed = true;

    public Health(int max)
    {
        maxValue = max;
        currentValue = max;
    }

    public int Points
    {
        get
        {
            return currentValue;
        }

        set
        {
            if (isChangeAllowed)
            {
                if (value < 0)
                {
                    currentValue = 0;
                }
                else if (value > maxValue)
                {
                    currentValue = maxValue;
                }
                else
                {
                    currentValue = value;
                }
            }
        }
    }

    public void AllowValueChanges(bool shouldAllow)
    {
        isChangeAllowed = shouldAllow;
    }

    /// <summary>1 represents 100%</summary>
    public float GetPercentage()
    {
        return currentValue / maxValue;
    }

    public bool IsDepleted()
    {
        return currentValue <= 0;
    }

    public bool IsAtMax()
    {
        return currentValue >= maxValue;
    }
}
