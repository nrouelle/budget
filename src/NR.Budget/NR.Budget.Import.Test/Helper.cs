namespace NR.Budget.Import.Test;

public static class Helper
{
    public static bool IsEqualTo(this float a, float b)
    {
        return Math.Abs(a - b) < 0.1f;
    }
}