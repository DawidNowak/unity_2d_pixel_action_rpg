using System;

public class StatisticsSystem
{
    public event EventHandler OnStatsToSpendChanged;

    public StrengthStat Strength { get; }
    public IntelligenceStat Intelligence { get; }
    public VitalityStat Vitality { get; }
    public int MaxHitPoints => Vitality.CurrentValue * 2;
    public int MaxManaPoints => Intelligence.CurrentValue * 2;

    public int HitPoints;
    public int ManaPoints;

    public int StatsToSpend { get; private set; }

    public StatisticsSystem(int strength, int intelligence, int vitality)
    {
        Strength = new StrengthStat(strength);
        Intelligence = new IntelligenceStat(intelligence);
        Vitality = new VitalityStat(vitality);

        HitPoints = MaxHitPoints;
        ManaPoints = MaxManaPoints;
    }

    public void LevelSystem_OnLevelChanged(object sender, EventArgs e)
    {
        StatsToSpend += 5;
        OnStatsToSpendChanged?.Invoke(this, EventArgs.Empty);
    }

    public void SetStatsToSpend(int value)
    {
        StatsToSpend = value;
        OnStatsToSpendChanged?.Invoke(this, EventArgs.Empty);
    }
}
