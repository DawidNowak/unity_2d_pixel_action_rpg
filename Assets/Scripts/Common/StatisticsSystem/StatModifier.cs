public abstract class StatModifier
{
    public readonly int Value;
    public readonly object Source;

    public StatModifier(int value, object source)
    {
        Value = value;
        Source = source;
    }
}

public sealed class StrengthModifier : StatModifier
{
    public StrengthModifier(int value, object source) : base(value, source)
    {
    }
}

public sealed class IntelligenceModifier : StatModifier
{
    public IntelligenceModifier(int value, object source) : base(value, source)
    {
    }
}

public sealed class HitPointsModifier : StatModifier
{
    public HitPointsModifier(int value, object source) : base(value, source)
    {
    }
}

public sealed class ManaPointsModifier : StatModifier
{
    public ManaPointsModifier(int value, object source) : base(value, source)
    {
    }
}
