using System.Collections.Generic;

public abstract class CharacterStat<T> where T : StatModifier
{
    private bool _isDirty = true;
    private int _currentStat;
    private readonly List<T> _modifiers;

    public int BaseValue { get; private set; }
    public int CurrentValue => GetCurrentStat();

    public CharacterStat(int baseValue)
    {
        _modifiers = new List<T>();
        BaseValue = baseValue;
    }

    public void SetBaseValue(int newValue)
    {
        BaseValue = newValue;
        _isDirty = true;
    }

    public void AddModifier(T modifier)
    {
        _modifiers.Add(modifier);
        _isDirty = true;
    }

    public void RemoveModifiersFromSource(object source)
    {
        _modifiers.RemoveAll(mod => mod.Source == source);
        _isDirty = true;
    }

    private int GetCurrentStat()
    {
        if (!_isDirty)
        {
            return _currentStat;
        }

        _currentStat = BaseValue;
        _modifiers.ForEach(mod => ApplyModifier(mod));
        _isDirty = false;

        return _currentStat;
    }

    private void ApplyModifier(T mod)
    {
        _currentStat += mod.Value;
    }
}

public sealed class StrengthStat : CharacterStat<StrengthModifier>
{
    public StrengthStat(int baseValue) : base(baseValue) { }
}

public sealed class IntelligenceStat : CharacterStat<IntelligenceModifier>
{
    public IntelligenceStat(int baseValue) : base(baseValue) { }
}

public sealed class HitPointsStat : CharacterStat<HitPointsModifier>
{
    public HitPointsStat(int baseValue) : base(baseValue) { }
}

public sealed class ManaPointsStat : CharacterStat<ManaPointsModifier>
{
    public ManaPointsStat(int baseValue) : base(baseValue) { }
}
