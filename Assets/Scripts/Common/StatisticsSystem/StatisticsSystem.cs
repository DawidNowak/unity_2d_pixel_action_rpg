public class StatisticsSystem
{
    public StrengthStat Strength { get; }
    public IntelligenceStat Intelligence { get; }
    public HitPointsStat HitPoints { get; }
    public ManaPointsStat ManaPoints { get; }

    public StatisticsSystem(int strength, int intelligence, int hitPoints, int manaPoints)
    {
        Strength = new StrengthStat(strength);
        Intelligence = new IntelligenceStat(intelligence);
        HitPoints = new HitPointsStat(hitPoints);
        ManaPoints = new ManaPointsStat(manaPoints);
    }
}
